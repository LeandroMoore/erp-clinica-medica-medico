using System;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;
using System.Windows.Navigation;
using ERP.Medico.Web;

namespace ERP.Medico.Views.Paciente
{
    public partial class ItensAtendimento : Page
    {
        public ItensAtendimento()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var ctx = App.Current.ContextoAtual;

            var atendimentoId = App.Current.AtendimentoAtual;

            if (!NavigationContext.QueryString.ContainsKey("Tipo")) return;

            switch (NavigationContext.QueryString["Tipo"])
            {
                case "Exames":
                    ctx.Load(ctx.GetExameQuery().Where(ex => ex.Atendimento.Id == atendimentoId), x => itemPacienteDataGrid.ItemsSource = x.Entities, null);
                    titulo.Text = "Exames";
                    break;
                case "Prescricoes":
                    ctx.Load(ctx.GetPrescricaoQuery().Where(p => p.Atendimento.Id == atendimentoId), x => itemPacienteDataGrid.ItemsSource = x.Entities, null);
                    titulo.Text = "Prescrições";
                    break;
                case "Tratamentos":
                    ctx.Load(ctx.GetTratamentoQuery().Where(t => t.Atendimento.Id == atendimentoId), x => itemPacienteDataGrid.ItemsSource = x.Entities, null);
                    titulo.Text = "Trartamentos";
                    break;
                case "Diagnosticos":
                    ctx.Load(ctx.GetDiagnosticoQuery().Where(ex => ex.Atendimento.Id == atendimentoId), x => itemPacienteDataGrid.ItemsSource = x.Entities, null);
                    titulo.Text = "Diagnósticos";
                    break;
                default:
                    throw new ArgumentException("Parametros incorretos.");
            }
        }

        private void exameDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var ctx = App.Current.ContextoAtual;
            var atendimentoId = App.Current.AtendimentoAtual;
            switch (NavigationContext.QueryString["Tipo"])
            {
                case "Exames":
                    ctx.Exames.Add(new Exame {AtendimentoId = atendimentoId, RealizadoNaClinica = true});
                    ctx.SubmitChanges(
                        o =>
                        ctx.Load(ctx.GetExameQuery().Where(ex => ex.Atendimento.Id == atendimentoId),
                                 x => itemPacienteDataGrid.ItemsSource = x.Entities, null), null);
                    break;
                case "Prescricoes":
                    ctx.Prescricaos.Add(new Prescricao { AtendimentoId = atendimentoId, RealizadoNaClinica = true });
                    ctx.SubmitChanges(
                        o =>
                        ctx.Load(ctx.GetPrescricaoQuery().Where(p => p.Atendimento.Id == atendimentoId),
                                 x => itemPacienteDataGrid.ItemsSource = x.Entities, null), null);
                    break;
                case "Tratamentos":
                    ctx.Tratamentos.Add(new Tratamento { AtendimentoId = atendimentoId, RealizadoNaClinica = true });
                    ctx.SubmitChanges(
                        o =>
                        ctx.Load(ctx.GetTratamentoQuery().Where(t => t.Atendimento.Id == atendimentoId),
                                 x => itemPacienteDataGrid.ItemsSource = x.Entities, null), null);
                    break;
                case "Diagnosticos":
                    ctx.Diagnosticos.Add(new Diagnostico { AtendimentoId = atendimentoId, RealizadoNaClinica = true });
                    ctx.SubmitChanges(
                        o =>
                        ctx.Load(ctx.GetDiagnosticoQuery().Where(d => d.Atendimento.Id == atendimentoId),
                                 x => itemPacienteDataGrid.ItemsSource = x.Entities, null), null);
                    break;
                default:
                    throw new ArgumentException("Parametros incorretos.");
            }
        }
    }
}
