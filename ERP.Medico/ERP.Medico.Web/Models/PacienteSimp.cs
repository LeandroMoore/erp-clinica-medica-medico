using System.ComponentModel.DataAnnotations;

namespace ERP.Medico.Web.Models
{
    public class PacienteSimp
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string HistoricoFamiliar { get; set; }
        public string HistoricoPessoal { get; set; }
        public string Observacoes { get; set; }
        public string TipoSangue { get; set; }
    }
}