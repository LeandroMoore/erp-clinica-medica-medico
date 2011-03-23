using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ERP.Medico.Views.Atendimento
{
    public partial class DadosAtendimento : Page
    {
        public DadosAtendimento()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void atendimentoDomainDataSource_LoadedData(object sender, System.Windows.Controls.LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
    }
}
