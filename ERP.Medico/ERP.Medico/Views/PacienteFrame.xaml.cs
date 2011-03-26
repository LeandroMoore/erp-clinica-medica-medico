using System;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ERP.Medico.Web;

namespace ERP.Medico.Views
{
    public partial class PacienteFrame : Page
    {
        public PacienteFrame()
        {
            InitializeComponent();
        }

        ERPMedicoDomainContext ctx = new ERPMedicoDomainContext();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var pacienteId = App.Current.PacienteAtual;
            var query = ctx.GetAtendimentoQuery().Where(a => a.PacienteId == pacienteId);
            var operation = ctx.Load(query);
            operation.Completed += (s, ex) =>
                                       {
                                           if (operation.HasError)
                                           {
                                               MessageBox.Show(operation.Error.Message);
                                               return;
                                           }
                                           atendimentosList.ItemsSource = operation.Entities;
                                       };
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
            if (atendimentosList.SelectedItem != null)
            {
                App.Current.AtendimentoAtual = ((Web.Atendimento) atendimentosList.SelectedItem).Id;
                NavigationService.Navigate(new Uri("/Atendimento", UriKind.Relative));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Current.AtendimentoAtual = -1; //criar novo
            NavigationService.Navigate(new Uri("/Atendimento", UriKind.Relative));
        }

    }
}
