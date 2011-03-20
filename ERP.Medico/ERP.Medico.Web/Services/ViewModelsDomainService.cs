using System;
using ERP.Medico.Web.ExternalData;
using ERP.Medico.Web.Models;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;

namespace ERP.Medico.Web
{
    [EnableClientAccess]
    public class ViewModelsDomainService : DomainService
    {
        readonly Entities _objectContext = new Entities();

        public IQueryable<ItemPaciente> GetExamesPaciente(int pacienteId)
        {

            return from e in _objectContext.Exame
                   where e.Atendimento.PacienteId == pacienteId
                   select new ItemPaciente { Key = e.Id, Horario = e.Atendimento.Horario, Descricao = e.Descricao, Observacoes = e.Observacoes };
        }

        public IQueryable<ItemPaciente> GetPrescricoesPaciente(int pacienteId)
        {
            return from p in _objectContext.Prescricao
                   where p.Atendimento.PacienteId == pacienteId
                   select new ItemPaciente { Key = p.Id, Horario = p.Atendimento.Horario, Descricao = p.Descricao, Observacoes = p.Observacoes };
        }

        public IQueryable<ItemPaciente> GetTratamentosPaciente(int pacienteId)
        {
            return from t in _objectContext.Tratamento
                   where t.Atendimento.PacienteId == pacienteId
                   select new ItemPaciente { Key = t.Id, Horario = t.Atendimento.Horario, Descricao = t.Descricao, Observacoes = t.Observacoes };
        }

        public IQueryable<ItemPaciente> GetDiagnosticosPaciente(int pacienteId)
        {
            return from d in _objectContext.Diagnostico
                   where d.Atendimento.PacienteId == pacienteId
                   select new ItemPaciente { Key = d.Id, Horario = d.Atendimento.Horario, Descricao = d.Descricao, Observacoes = d.Observacoes };
        }

        private Medico GetMedico(int medicoId)
        {
            return _objectContext.Medico.FirstOrDefault(m => m.Id == medicoId);
        }

        public IQueryable<Agendamento> GetAgendamentosMedico(int medicoId)
        {
            var medico = GetMedico(medicoId);
            if (medico == null)
                return null;

            return AgendamentosManager.GetAgendamentos(medico.Codigo).AsQueryable();
        }

        public IQueryable<Agendamento> GetAgendamentosMedicoData(int medicoId, DateTime data)
        {
            var medico = GetMedico(medicoId);
            if (medico == null)
                return null;

            return AgendamentosManager.GetAgendamentos(medico.Codigo, data).AsQueryable();
        }

        public IQueryable<Paciente> GetPacientesMedico(int medicoId)
        {
            var agendamentos = GetAgendamentosMedico(medicoId);
            if (agendamentos == null)
                return null;

            return agendamentos.Select(a => a.Paciente).Distinct().AsQueryable();
        }
    }
}


