using System;
using ERP.Medico.Web.Models;

namespace ERP.Medico
{
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Home page for the application.
    /// </summary>
    public partial class Agendamentos : Page
    {
        /// <summary>
        /// Creates a new <see cref="Agendamentos"/> instance.
        /// </summary>
        public Agendamentos()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.HomePageTitle;
            abrirFicha.IsEnabled = false;
            agendamentoDataGrid.SelectionChanged +=
                (s, e) => abrirFicha.IsEnabled = (agendamentoDataGrid.SelectedItem != null);
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dataPicker.SelectedDate = DateTime.Now.Date;
        }

        private void agendamentoDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (agendamentoDataGrid.SelectedItem != null)
            {
                App.Current.PacienteAtual = ((Agendamento) agendamentoDataGrid.SelectedItem).PacienteId;
                NavigationService.Navigate(new Uri("/Paciente", UriKind.Relative));
            }
        }
    }
}