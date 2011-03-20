using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Medico.Web.Models
{
    public partial class ItemPaciente
    {
        [Key, Display(AutoGenerateField = false)]
        public int Key { get; set; }

        [Display(Name="Data e hora")]
        public DateTime Horario { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }
    }
}