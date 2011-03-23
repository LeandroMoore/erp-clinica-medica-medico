using System;
using System.Collections;
using ERP.Medico.ERPMedicoServiceReference;

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
            dataPicker.SelectedDateChanged += (s, e) => SelecionaAgendamentos();
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dataPicker.SelectedDate = DateTime.Now.Date;
            SelecionaAgendamentos();
        }

        private void SelecionaAgendamentos()
        {
            if (dataPicker.SelectedDate != null)
            {
                var proxy = new ERPMedicoServiceClient();
                proxy.GetAgendamentosMedicoDataCompleted += (s, ex) =>
                                                                {
                                                                    agendamentoDataGrid.ItemsSource = ex.Result;
                                                                };

                proxy.GetAgendamentosMedicoDataAsync(1, (DateTime) dataPicker.SelectedDate);
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