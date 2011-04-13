using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Medico.Web.Models;

namespace ERP.Medico.Web.ExternalData
{
    /// <summary>
    /// Pega agendamentos do serviço de agendamentos, e cria pacientes no banco local se necessário.
    /// </summary>
    public static class AgendamentosManager
    {
        private static Paciente VerificaPaciente(int pacienteId, string pacienteName)
        {
            var entities = new Entities();

            var pacienteIdString = pacienteId.ToString();

            var pacientes = from p in entities.Paciente
                            where p.Codigo == pacienteIdString
                            select p;

            if (!pacientes.Any())
            {
                var novoPaciente = new Paciente { Codigo = pacienteId.ToString(), Nome = pacienteName };
                entities.Paciente.AddObject(novoPaciente);
                return novoPaciente;
            }
            return pacientes.First();
        }

        private static Medico VerificaMedico(int medicoId, string medicoName)
        {
            var entities = new Entities();

            var medicos = from m in entities.Medico
                          where m.Codigo == medicoId.ToString()
                          select m;

            if (!medicos.Any())
            {
                var novoMedico = new Medico { Codigo = medicoId.ToString(), Nome = medicoName };
                entities.Medico.AddObject(novoMedico);
                return novoMedico;
            }

            return medicos.First();
        }

        private static IList<Paciente> GetPacientes()
        {
            var pacientes = new Entities().Paciente;
            return pacientes.ToList();
        }

        public static IEnumerable<Agendamento> GetAgendamentos(string codigoMedico)
        {
            var client = new ERPAgendamento.FornecedorServicosSoapClient();

            return from a in client.AgendamentosByMedicos(1)
                   select new Agendamento(a.dataAtendimento, VerificaPaciente(a.paciente_id, a.paciente_nome), 1);
        }

        public static IEnumerable<Agendamento> GetAgendamentos(string codigoMedico, DateTime data)
        {
            return from a in GetAgendamentos(codigoMedico)
                   where a.Data.Date == data
                   select a;
        }
    }
}