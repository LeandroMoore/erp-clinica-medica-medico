using System.Linq;
using Erp.Medico.Web;

namespace Erp.Medico
{
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Home page for the application.
    /// </summary>
    public partial class Home : Page
    {
        /// <summary>
        /// Creates a new <see cref="Home"/> instance.
        /// </summary>
        public Home()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.HomePageTitle;
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void pacienteDomainDataSource_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var view = pacienteDataGrid.ItemsSource as DomainDataSourceView;
            var paciente = new Paciente() { Codigo = "1", Anamnese = new Anamnese() { TipoSangue_Id = 1 } };
            view.Add(paciente);
            pacienteDataGrid.Focus();
            pacienteDataGrid.SelectedItem = paciente;
            pacienteDataGrid.CurrentColumn = pacienteDataGrid.Columns[0];
            pacienteDataGrid.ScrollIntoView(pacienteDataGrid.SelectedItem, pacienteDataGrid.CurrentColumn);
            pacienteDataGrid.BeginEdit();
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            var view = pacienteDataGrid.ItemsSource as DomainDataSourceView;
            var removeItems = pacienteDataGrid.SelectedItems.Cast<Paciente>().ToArray();
            foreach (Paciente paciente in removeItems)
                view.Remove(paciente);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            pacienteDomainDataSource.SubmitChanges();
        }

        private void pacienteDomainDataSource_LoadedData_1(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
    }
}