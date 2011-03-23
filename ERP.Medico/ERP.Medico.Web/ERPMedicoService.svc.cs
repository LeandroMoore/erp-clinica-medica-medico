using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ERP.Medico.Web.ExternalData;
using ERP.Medico.Web.Models;

namespace ERP.Medico.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ERPMedicoService
    {
        [OperationContract]
        public IEnumerable<Agendamento> GetAgendamentosMedico(int medicoId)
        {
            var ctx = new ERPMedicoDomainService();
            var medico = ctx.GetMedico().Where(m => m.Id == medicoId).FirstOrDefault();
            if (medico == null)
                return null;

            return AgendamentosManager.GetAgendamentos(medico.Codigo).ToList();
        }

        [OperationContract]
        public IEnumerable<Agendamento> GetAgendamentosMedicoData(int medicoId, DateTime data)
        {
            var ctx = new ERPMedicoDomainService();
            var medico = ctx.GetMedico().Where(m => m.Id == medicoId).FirstOrDefault();
            if (medico == null)
                return null;

            return AgendamentosManager.GetAgendamentos(medico.Codigo, data).ToList();
        }

    }
}
