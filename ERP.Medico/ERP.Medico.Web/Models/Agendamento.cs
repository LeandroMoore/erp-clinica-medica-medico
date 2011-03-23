using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ERP.Medico.Web.Models
{
    [DataContract]
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

        [DataMember]
        public Guid Id { get; private set; }

        [Display(AutoGenerateField = false)]
        [DataMember]
        public DateTime Horario { get; private set; }

        [Display(AutoGenerateField = false)]
        public Paciente Paciente { get; private set; }

        [Display(AutoGenerateField = false)]
        [DataMember]
        public int MedicoId { get; private set; }

        [Display(Name = "Paciente")]
        [DataMember]
        public string NomePaciente 
        { 
            get { return Paciente.Nome; }
            private set { }
        }

        [Display(AutoGenerateField = false)]
        [DataMember]
        public int PacienteId
        {
            get { return Paciente.Id; }
            private set { }
        }

        [DataMember]
        public DateTime Data
        {
            get { return Horario.Date; }
            private set { }
        }

        [DataMember]
        public TimeSpan Hora
        {
            get { return Horario.TimeOfDay; }
            private set { }

        }
    }
}