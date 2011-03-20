
namespace ERP.Medico.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies AtendimentoMetadata as the class
    // that carries additional metadata for the Atendimento class.
    [MetadataTypeAttribute(typeof(Atendimento.AtendimentoMetadata))]
    public partial class Atendimento
    {

        // This class allows you to attach custom attributes to properties
        // of the Atendimento class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class AtendimentoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private AtendimentoMetadata()
            {
            }

            public Nullable<double> Altura { get; set; }

            public string Descricao { get; set; }

            public string DescricaoDoencaAtual { get; set; }

            public EntityCollection<Diagnostico> Diagnostico { get; set; }

            public EntityCollection<Exame> Exame { get; set; }

            public DateTime Horario { get; set; }

            public int Id { get; set; }

            public Medico Medico { get; set; }

            public Nullable<int> MedicoId { get; set; }

            public string Observacoes { get; set; }

            public Paciente Paciente { get; set; }

            public int PacienteId { get; set; }

            public Nullable<double> Peso { get; set; }

            public EntityCollection<Prescricao> Prescricao { get; set; }

            public string QueixaPrincipal { get; set; }

            public EntityCollection<Tratamento> Tratamento { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DiagnosticoMetadata as the class
    // that carries additional metadata for the Diagnostico class.
    [MetadataTypeAttribute(typeof(Diagnostico.DiagnosticoMetadata))]
    public partial class Diagnostico
    {

        // This class allows you to attach custom attributes to properties
        // of the Diagnostico class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DiagnosticoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DiagnosticoMetadata()
            {
            }

            public Atendimento Atendimento { get; set; }

            public int AtendimentoId { get; set; }

            public string Descricao { get; set; }

            public int Id { get; set; }

            public string Observacoes { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ExameMetadata as the class
    // that carries additional metadata for the Exame class.
    [MetadataTypeAttribute(typeof(Exame.ExameMetadata))]
    public partial class Exame
    {

        // This class allows you to attach custom attributes to properties
        // of the Exame class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ExameMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ExameMetadata()
            {
            }

            public Atendimento Atendimento { get; set; }

            public int AtendimentoId { get; set; }

            public string Descricao { get; set; }

            public int Id { get; set; }

            public string Observacoes { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MedicoMetadata as the class
    // that carries additional metadata for the Medico class.
    [MetadataTypeAttribute(typeof(Medico.MedicoMetadata))]
    public partial class Medico
    {

        // This class allows you to attach custom attributes to properties
        // of the Medico class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MedicoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MedicoMetadata()
            {
            }

            public EntityCollection<Atendimento> Atendimento { get; set; }

            public string Codigo { get; set; }

            public int Id { get; set; }

            public string Nome { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PacienteMetadata as the class
    // that carries additional metadata for the Paciente class.
    [MetadataTypeAttribute(typeof(Paciente.PacienteMetadata))]
    public partial class Paciente
    {

        // This class allows you to attach custom attributes to properties
        // of the Paciente class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PacienteMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PacienteMetadata()
            {
            }

            public EntityCollection<Atendimento> Atendimento { get; set; }

            public string Codigo { get; set; }

            public string HistoricoFamiliar { get; set; }

            public string HistoricoPessoal { get; set; }

            public int Id { get; set; }

            public string Observacoes { get; set; }

            public string TipoSangue { get; set; }

            public string Nome { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PrescricaoMetadata as the class
    // that carries additional metadata for the Prescricao class.
    [MetadataTypeAttribute(typeof(Prescricao.PrescricaoMetadata))]
    public partial class Prescricao
    {

        // This class allows you to attach custom attributes to properties
        // of the Prescricao class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PrescricaoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PrescricaoMetadata()
            {
            }

            public Atendimento Atendimento { get; set; }

            public int AtendimentoId { get; set; }

            public string Descricao { get; set; }

            public int Id { get; set; }

            public string Observacoes { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TratamentoMetadata as the class
    // that carries additional metadata for the Tratamento class.
    [MetadataTypeAttribute(typeof(Tratamento.TratamentoMetadata))]
    public partial class Tratamento
    {

        // This class allows you to attach custom attributes to properties
        // of the Tratamento class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TratamentoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TratamentoMetadata()
            {
            }

            public Atendimento Atendimento { get; set; }

            public int AtendimentoId { get; set; }

            public string Descricao { get; set; }

            public int Id { get; set; }

            public string Observacoes { get; set; }
        }
    }
}
