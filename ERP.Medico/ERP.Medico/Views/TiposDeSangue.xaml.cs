using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Erp.Medico.Web;

namespace Erp.Medico.Views
{
    public partial class TiposDeSangue : Page
    {
        public TiposDeSangue()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void tiposSangueDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private ERPMedicoDomainContext ctx = new ERPMedicoDomainContext();

        private void NovoClick(object sender, RoutedEventArgs e)
        {
            var view = tiposSangueDataGrid.ItemsSource as DomainDataSourceView;
            var tipoSangue = new TiposSangue() { Descricao = "B" };
            view.Add(tipoSangue);
            tiposSangueDataGrid.Focus();
            tiposSangueDataGrid.SelectedItem = tipoSangue;
            tiposSangueDataGrid.CurrentColumn = tiposSangueDataGrid.Columns[0];
            tiposSangueDataGrid.ScrollIntoView(tiposSangueDataGrid.SelectedItem, tiposSangueDataGrid.CurrentColumn);
            tiposSangueDataGrid.BeginEdit();
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            var view = tiposSangueDataGrid.ItemsSource as DomainDataSourceView;
            var removeItems = tiposSangueDataGrid.SelectedItems.Cast<TiposSangue>().ToArray();
            foreach (TiposSangue tipoDeSangue in removeItems)
                view.Remove(tipoDeSangue);
        }

        private void SalvarClick(object sender, RoutedEventArgs e)
        {
            tiposSangueDomainDataSource.SubmitChanges();
        }
    }
}