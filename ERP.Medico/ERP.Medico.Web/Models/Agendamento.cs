using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Medico.Web.Models
{
    public class Agendamento
    {
        // Necessario pois é uma entity
        public Agendamento() { }

        public Agendamento(DateTime horario, Paciente paciente, int medicoId)
        {
            Id = Guid.NewGuid();
            Horario = horario;
            Paciente = paciente;
            MedicoId = medicoId;
        }

        [Key, Display(AutoGenerateField = false)]
        public Guid Id { get; private set; }

        [Display(AutoGenerateField = false)]
        public DateTime Horario { get; private set; }

        [Display(AutoGenerateField = false)]
        public Paciente Paciente { get; private set; }

        [Display(AutoGenerateField = false)]
        public int MedicoId { get; private set; }

        [Display(Name = "Paciente")]
        public string NomePaciente { get { return Paciente.Nome; } }

        [Display(AutoGenerateField = false)]
        public int PacienteId { get { return Paciente.Id; } }
        
        public DateTime Data { get { return Horario.Date; } }

        public TimeSpan Hora { get { return Horario.TimeOfDay; } }
    }
}