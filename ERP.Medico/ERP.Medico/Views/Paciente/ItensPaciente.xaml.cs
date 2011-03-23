using System;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;
using System.Windows.Navigation;
using ERP.Medico.Web;

namespace ERP.Medico.Views.Paciente
{
    public partial class ItensPaciente : Page
    {
        public ItensPaciente()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var ctx = new ERPMedicoDomainContext();

            var pacienteId = App.Current.PacienteAtual;

            if (!NavigationContext.QueryString.ContainsKey("Tipo")) return;

            switch (NavigationContext.QueryString["Tipo"])
            {
                case "Exames":
                    ctx.Load(ctx.GetExameQuery().Where(ex => ex.Atendimento.PacienteId == pacienteId), x => itemPacienteDataGrid.ItemsSource = x.Entities, null);
                    titulo.Text = "Exames";
                    break;
                case "Prescricoes":
                    ctx.Load(ctx.GetPrescricaoQuery().Where(p => p.Atendimento.PacienteId == pacienteId), x => itemPacienteDataGrid.ItemsSource = x.Entities, null);
                    titulo.Text = "Prescrições";
                    break;
                case "Tratamentos":
                    ctx.Load(ctx.GetTratamentoQuery().Where(t => t.Atendimento.PacienteId == pacienteId), x => itemPacienteDataGrid.ItemsSource = x.Entities, null);
                    titulo.Text = "Trartamentos";
                    break;
                case "Diagnosticos":
                    ctx.Load(ctx.GetDiagnosticoQuery().Where(ex => ex.Atendimento.PacienteId == pacienteId), x => itemPacienteDataGrid.ItemsSource = x.Entities, null);
                    titulo.Text = "Diagnósticos";
                    break;
                default:
                    throw new ArgumentException("Parametros incorretos.");
            }
        }
    }
}
