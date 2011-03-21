using System;
using System.Windows;
using ERP.Medico.Web;
using ERP.Medico.Web.Models;

namespace ERP.Medico
{
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Home page for the application.
    /// </summary>
    public partial class Pacientes : Page
    {
        /// <summary>
        /// Creates a new <see cref="Pacientes"/> instance.
        /// </summary>
        public Pacientes()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.HomePageTitle;
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            var ctx = new ViewModelsDomainContext();
            var operation = ctx.Load(ctx.GetPacientesMedicoQuery(1)); // FAKE

            operation.Completed += (s, ex) =>
                                       {
                                           if (operation.HasError)
                                           {
                                               MessageBox.Show(operation.Error.Message);
                                               return;
                                           }
                                           pacienteDataGrid.ItemsSource = ctx.PacienteSimps;
                                       };
           
           
        }

        private void pacienteDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (pacienteDataGrid.SelectedItem != null)
            {
                App.Current.PacienteAtual = ((PacienteSimp)pacienteDataGrid.SelectedItem).Id;
                NavigationService.Navigate(new Uri("/Paciente", UriKind.Relative));
            }
        }
    }
}