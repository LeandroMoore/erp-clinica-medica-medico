using System;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ERP.Medico.Web;

namespace ERP.Medico.Views
{
    public partial class AtendimentoFrame : Page
    {
        public AtendimentoFrame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// After the Frame navigates, ensure the <see cref="HyperlinkButton"/> representing the current page is selected
        /// </summary>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (UIElement child in LinksStackPanel.Children)
            {
                HyperlinkButton hb = child as HyperlinkButton;
                if (hb != null && hb.NavigateUri != null)
                {
                    if (hb.NavigateUri.ToString().Equals(e.Uri.ToString()))
                    {
                        VisualStateManager.GoToState(hb, "ActiveLink", true);
                    }
                    else
                    {
                        VisualStateManager.GoToState(hb, "InactiveLink", true);
                    }
                }
            }
        }

        ERPMedicoDomainContext ctx = new ERPMedicoDomainContext();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.Current.ContextoAtual = ctx;
            if (App.Current.AtendimentoAtual < 0)
            {
                Web.Atendimento atendimento = new Web.Atendimento
                                                  {
                                                      PacienteId = App.Current.PacienteAtual,
                                                      MedicoId = 1,
                                                      Horario = DateTime.Now
                                                  };
                ctx.Atendimentos.Add(atendimento);
                DataContext = atendimento;
            }
            else
            {
                var operation = ctx.Load(ctx.GetAtendimentoQuery().Where(a => a.Id == App.Current.AtendimentoAtual));
                operation.Completed += (s, ex) =>
                                           {
                                               if (operation.HasError)
                                               {
                                                   MessageBox.Show(operation.Error.Message);
                                                   return;
                                               }
                                               if (operation.Entities.Count() == 0)
                                               {
                                                   MessageBox.Show("Erro ao carregar atendimento");
                                                   return;
                                               }
                                               DataContext = operation.Entities.First();

                                           };
            }
        }

        /// <summary>
        /// If an error occurs during navigation, show an error window
        /// </summary>
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ErrorWindow.CreateNew(e.Exception);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ctx.SubmitChanges();
        }

        private void VoltarLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Paciente", UriKind.Relative));
        }

    }
}
