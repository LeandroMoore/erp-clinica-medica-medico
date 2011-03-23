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

        ERPMedicoDomainContext ctx = new ERPMedicoDomainContext();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var pacienteId = App.Current.PacienteAtual;

            var operation = ctx.Load(ctx.GetPacienteQuery().Where(p => p.Id == pacienteId));
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ctx.SubmitChanges();
        }

    }
}
