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
        private static IList<Paciente> GetPacientes()
        {
            var pacientes = new Entities().Paciente;
            return pacientes.ToList();
        }

        private static readonly IList<Paciente> PacientesFake = GetPacientes();

        private static readonly IList<Agendamento> AgendamentosFake = new List<Agendamento>
                {
                    new Agendamento(DateTime.Now, PacientesFake[0], 1),
                    new Agendamento(DateTime.Now, PacientesFake[1], 1),
                    new Agendamento(DateTime.Now, PacientesFake[2], 1),
                    new Agendamento(DateTime.Now, PacientesFake[3], 1),
                    new Agendamento(DateTime.Now, PacientesFake[4], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(1), PacientesFake[0], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(1), PacientesFake[2], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(1), PacientesFake[4], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(2), PacientesFake[1], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(2), PacientesFake[3], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(3), PacientesFake[0], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(3), PacientesFake[1], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(3), PacientesFake[2], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(3), PacientesFake[3], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(3), PacientesFake[4], 1),
                    new Agendamento(DateTime.Now + TimeSpan.FromDays(3), PacientesFake[5], 1),
               };

        public static IEnumerable<Agendamento> GetAgendamentos(string codigoMedico)
        {
            // fake
            return (codigoMedico == "abc001") ? AgendamentosFake : null;
        }

        public static IEnumerable<Agendamento> GetAgendamentos(string codigoMedico, DateTime data)
        {
            // fake
            return (codigoMedico == "abc001") ? 
                AgendamentosFake.Where(a => a.Horario.Date == data.Date) : null;
        }
    }
}