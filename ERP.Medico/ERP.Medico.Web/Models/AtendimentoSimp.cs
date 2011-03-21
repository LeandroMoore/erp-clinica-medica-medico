using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Medico.Web.Models
{
    public class AtendimentoSimp
    {
        [Key]
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime Horario { get; set; }
    }
}