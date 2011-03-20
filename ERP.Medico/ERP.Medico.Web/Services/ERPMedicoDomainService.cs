using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.ServiceModel.DomainServices.EntityFramework;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using ERP.Medico.Web.Models;

namespace ERP.Medico.Web
{
    
    // Implements application logic using the Entities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class ERPMedicoDomainService : LinqToEntitiesDomainService<Entities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Atendimento' query.
        public IQueryable<Atendimento> GetAtendimento()
        {
            return this.ObjectContext.Atendimento;
        }

        public void InsertAtendimento(Atendimento atendimento)
        {
            if ((atendimento.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(atendimento, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Atendimento.AddObject(atendimento);
            }
        }

        public void UpdateAtendimento(Atendimento currentAtendimento)
        {
            this.ObjectContext.Atendimento.AttachAsModified(currentAtendimento, this.ChangeSet.GetOriginal(currentAtendimento));
        }

        public void DeleteAtendimento(Atendimento atendimento)
        {
            if ((atendimento.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(atendimento, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Atendimento.Attach(atendimento);
                this.ObjectContext.Atendimento.DeleteObject(atendimento);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Diagnostico' query.
        public IQueryable<Diagnostico> GetDiagnostico()
        {
            return this.ObjectContext.Diagnostico;
        }

        public void InsertDiagnostico(Diagnostico diagnostico)
        {
            if ((diagnostico.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(diagnostico, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Diagnostico.AddObject(diagnostico);
            }
        }

        public void UpdateDiagnostico(Diagnostico currentDiagnostico)
        {
            this.ObjectContext.Diagnostico.AttachAsModified(currentDiagnostico, this.ChangeSet.GetOriginal(currentDiagnostico));
        }

        public void DeleteDiagnostico(Diagnostico diagnostico)
        {
            if ((diagnostico.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(diagnostico, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Diagnostico.Attach(diagnostico);
                this.ObjectContext.Diagnostico.DeleteObject(diagnostico);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Exame' query.
        public IQueryable<Exame> GetExame()
        {
            return this.ObjectContext.Exame;
        }

        public void InsertExame(Exame exame)
        {
            if ((exame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(exame, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Exame.AddObject(exame);
            }
        }

        public void UpdateExame(Exame currentExame)
        {
            this.ObjectContext.Exame.AttachAsModified(currentExame, this.ChangeSet.GetOriginal(currentExame));
        }

        public void DeleteExame(Exame exame)
        {
            if ((exame.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(exame, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Exame.Attach(exame);
                this.ObjectContext.Exame.DeleteObject(exame);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Medico' query.
        public IQueryable<Medico> GetMedico()
        {
            return this.ObjectContext.Medico;
        }

        public void InsertMedico(Medico medico)
        {
            if ((medico.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(medico, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Medico.AddObject(medico);
            }
        }

        public void UpdateMedico(Medico currentMedico)
        {
            this.ObjectContext.Medico.AttachAsModified(currentMedico, this.ChangeSet.GetOriginal(currentMedico));
        }

        public void DeleteMedico(Medico medico)
        {
            if ((medico.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(medico, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Medico.Attach(medico);
                this.ObjectContext.Medico.DeleteObject(medico);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Paciente' query.
        public IQueryable<Paciente> GetPaciente()
        {
            return this.ObjectContext.Paciente;
        }

        public void InsertPaciente(Paciente paciente)
        {
            if ((paciente.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(paciente, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Paciente.AddObject(paciente);
            }
        }

        public void UpdatePaciente(Paciente currentPaciente)
        {
            this.ObjectContext.Paciente.AttachAsModified(currentPaciente, this.ChangeSet.GetOriginal(currentPaciente));
        }

        public void DeletePaciente(Paciente paciente)
        {
            if ((paciente.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(paciente, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Paciente.Attach(paciente);
                this.ObjectContext.Paciente.DeleteObject(paciente);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Prescricao' query.
        public IQueryable<Prescricao> GetPrescricao()
        {
            return this.ObjectContext.Prescricao;
        }

        public void InsertPrescricao(Prescricao prescricao)
        {
            if ((prescricao.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(prescricao, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Prescricao.AddObject(prescricao);
            }
        }

        public void UpdatePrescricao(Prescricao currentPrescricao)
        {
            this.ObjectContext.Prescricao.AttachAsModified(currentPrescricao, this.ChangeSet.GetOriginal(currentPrescricao));
        }

        public void DeletePrescricao(Prescricao prescricao)
        {
            if ((prescricao.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(prescricao, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Prescricao.Attach(prescricao);
                this.ObjectContext.Prescricao.DeleteObject(prescricao);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Tratamento' query.
        public IQueryable<Tratamento> GetTratamento()
        {
            return this.ObjectContext.Tratamento;
        }

        public void InsertTratamento(Tratamento tratamento)
        {
            if ((tratamento.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tratamento, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Tratamento.AddObject(tratamento);
            }
        }

        public void UpdateTratamento(Tratamento currentTratamento)
        {
            this.ObjectContext.Tratamento.AttachAsModified(currentTratamento, this.ChangeSet.GetOriginal(currentTratamento));
        }

        public void DeleteTratamento(Tratamento tratamento)
        {
            if ((tratamento.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tratamento, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Tratamento.Attach(tratamento);
                this.ObjectContext.Tratamento.DeleteObject(tratamento);
            }
        }



    }
}


