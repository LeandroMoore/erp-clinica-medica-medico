using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ERP.Medico.Web;

namespace ERP.Medico.Views.Paciente
{
    public partial class DadosPaciente : Page
    {
        public DadosPaciente()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var pacienteId = App.Current.PacienteAtual;

            var ctx = new ViewModelsDomainContext();
            var operation = ctx.Load(ctx.GetPacientesQuery(pacienteId));
            operation.Completed += (s, ex) =>
                                       {
                                           if (operation.HasError)
                                           {
                                               MessageBox.Show(operation.Error.Message);
                                               return;
                                           }
                                           grid1.DataContext = operation.Entities.FirstOrDefault();
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
    }
}
