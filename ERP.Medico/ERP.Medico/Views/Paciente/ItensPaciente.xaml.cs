using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Controls;
using System.Windows.Navigation;
using ERP.Medico.Web;
using ERP.Medico.Web.Models;

namespace ERP.Medico.Views.Paciente
{
    public partial class ItensPaciente : Page
    {
        public ItensPaciente()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var ctx = new ViewModelsDomainContext();

            EntityQuery<ItemPaciente> itens;

            var pacienteId = int.Parse(NavigationContext.QueryString["Paciente"]);

            if (!NavigationContext.QueryString.ContainsKey("Tipo")) return;

            switch (NavigationContext.QueryString["Tipo"])
            {
                case "Exames":
                    itens = ctx.GetExamesPacienteQuery(pacienteId);
                    break;
                case "Prescricoes":
                    itens = ctx.GetPrescricoesPacienteQuery(pacienteId);
                    break;
                case "Tratamentos":
                    itens = ctx.GetTratamentosPacienteQuery(pacienteId);
                    break;
                case "Diagnosticos":
                    itens = ctx.GetDiagnosticosPacienteQuery(pacienteId);
                    break;
                default:
                    throw new ArgumentException("Parametros incorretos.");
            }

            ctx.Load(itens, x => itemPacienteDataGrid.ItemsSource = x.Entities, null);
        }

        private void itemPacienteDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

     

    }
}
