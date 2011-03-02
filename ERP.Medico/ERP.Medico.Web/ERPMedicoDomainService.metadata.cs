
namespace Erp.Medico.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies AnamnesMetadata as the class
    // that carries additional metadata for the Anamnese class.
    [MetadataTypeAttribute(typeof(Anamnese.AnamneseMetadata))]
    public partial class Anamnese
    {

        // This class allows you to attach custom attributes to properties
        // of the Anamnese class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class AnamneseMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private AnamneseMetadata()
            {
            }

            public string DescricaoDoencaAtual { get; set; }

            public string DescricaoMedicaPregressa { get; set; }

            public string HistoricoFamiliar { get; set; }

            public string HistoricoPessoalSocial { get; set; }

            public int Id { get; set; }

            public string Observacoes { get; set; }

            public EntityCollection<Paciente> Pacientes { get; set; }

            public string QueixaPrincipal { get; set; }

            public int TipoSangue_Id { get; set; }

            public TiposSangue TiposSangue { get; set; }
        }
    }

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

            public string Descricao { get; set; }

            public EntityCollection<Diagnostico> Diagnosticos { get; set; }

            public bool Emergencia { get; set; }

            public DateTime Horario { get; set; }

            public int Id { get; set; }

            public Medico Medico { get; set; }

            public int Medico_Id { get; set; }

            public Paciente Paciente { get; set; }

            public int Paciente_Id { get; set; }

            public int TipoAtendimento_Id { get; set; }

            public TiposAtendimento TiposAtendimento { get; set; }

            public EntityCollection<Tratamento> Tratamentos { get; set; }
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

            public EntityCollection<Atendimento> Atendimentos { get; set; }

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

            public float Altura { get; set; }

            public Anamnese Anamnese { get; set; }

            public int Anamnese_Id { get; set; }

            public EntityCollection<Atendimento> Atendimentos { get; set; }

            public string Codigo { get; set; }

            public int Id { get; set; }

            public float Peso { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TiposAtendimentoMetadata as the class
    // that carries additional metadata for the TiposAtendimento class.
    [MetadataTypeAttribute(typeof(TiposAtendimento.TiposAtendimentoMetadata))]
    public partial class TiposAtendimento
    {

        // This class allows you to attach custom attributes to properties
        // of the TiposAtendimento class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TiposAtendimentoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TiposAtendimentoMetadata()
            {
            }

            public EntityCollection<Atendimento> Atendimentos { get; set; }

            public string Descricao { get; set; }

            public int Id { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TiposSangueMetadata as the class
    // that carries additional metadata for the TiposSangue class.
    [MetadataTypeAttribute(typeof(TiposSangue.TiposSangueMetadata))]
    public partial class TiposSangue
    {

        // This class allows you to attach custom attributes to properties
        // of the TiposSangue class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TiposSangueMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TiposSangueMetadata()
            {
            }

            public EntityCollection<Anamnese> Anamneses { get; set; }

            public string Descricao { get; set; }

            public int Id { get; set; }
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
