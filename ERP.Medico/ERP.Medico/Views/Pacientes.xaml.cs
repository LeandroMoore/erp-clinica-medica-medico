using ERP.Medico.Web;

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
            /*
            var ctx = new ViewModelsDomainContext();
            ctx.Load(ctx.GetPacientesMedicoQuery(1)); // FAKE

           pacienteDataGrid.ItemsSource = ctx.Pacientes;
             * */
        }

        private void pacienteDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
    }
}