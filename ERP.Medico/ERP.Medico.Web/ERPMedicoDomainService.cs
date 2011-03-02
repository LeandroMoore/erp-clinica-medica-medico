
namespace Erp.Medico.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


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
        // To support paging you will need to add ordering to the 'Anamneses' query.
        public IQueryable<Anamnese> GetAnamneses()
        {
            return this.ObjectContext.Anamneses;
        }

        public void InsertAnamnes(Anamnese anamnese)
        {
            if ((anamnese.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(anamnese, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Anamneses.AddObject(anamnese);
            }
        }

        public void UpdateAnamnes(Anamnese currentAnamnese)
        {
            this.ObjectContext.Anamneses.AttachAsModified(currentAnamnese, this.ChangeSet.GetOriginal(currentAnamnese));
        }

        public void DeleteAnamnes(Anamnese anamnese)
        {
            if ((anamnese.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Anamneses.Attach(anamnese);
            }
            this.ObjectContext.Anamneses.DeleteObject(anamnese);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Atendimentos' query.
        public IQueryable<Atendimento> GetAtendimentos()
        {
            return this.ObjectContext.Atendimentos;
        }

        public void InsertAtendimento(Atendimento atendimento)
        {
            if ((atendimento.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(atendimento, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Atendimentos.AddObject(atendimento);
            }
        }

        public void UpdateAtendimento(Atendimento currentAtendimento)
        {
            this.ObjectContext.Atendimentos.AttachAsModified(currentAtendimento, this.ChangeSet.GetOriginal(currentAtendimento));
        }

        public void DeleteAtendimento(Atendimento atendimento)
        {
            if ((atendimento.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Atendimentos.Attach(atendimento);
            }
            this.ObjectContext.Atendimentos.DeleteObject(atendimento);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Diagnosticos' query.
        public IQueryable<Diagnostico> GetDiagnosticos()
        {
            return this.ObjectContext.Diagnosticos;
        }

        public void InsertDiagnostico(Diagnostico diagnostico)
        {
            if ((diagnostico.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(diagnostico, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Diagnosticos.AddObject(diagnostico);
            }
        }

        public void UpdateDiagnostico(Diagnostico currentDiagnostico)
        {
            this.ObjectContext.Diagnosticos.AttachAsModified(currentDiagnostico, this.ChangeSet.GetOriginal(currentDiagnostico));
        }

        public void DeleteDiagnostico(Diagnostico diagnostico)
        {
            if ((diagnostico.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Diagnosticos.Attach(diagnostico);
            }
            this.ObjectContext.Diagnosticos.DeleteObject(diagnostico);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Medicos' query.
        public IQueryable<Medico> GetMedicos()
        {
            return this.ObjectContext.Medicos;
        }

        public void InsertMedico(Medico medico)
        {
            if ((medico.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(medico, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Medicos.AddObject(medico);
            }
        }

        public void UpdateMedico(Medico currentMedico)
        {
            this.ObjectContext.Medicos.AttachAsModified(currentMedico, this.ChangeSet.GetOriginal(currentMedico));
        }

        public void DeleteMedico(Medico medico)
        {
            if ((medico.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Medicos.Attach(medico);
            }
            this.ObjectContext.Medicos.DeleteObject(medico);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pacientes' query.
        public IQueryable<Paciente> GetPacientes()
        {
            return this.ObjectContext.Pacientes;
        }

        public void InsertPaciente(Paciente paciente)
        {
            if ((paciente.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(paciente, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pacientes.AddObject(paciente);
            }
        }

        public void UpdatePaciente(Paciente currentPaciente)
        {
            this.ObjectContext.Pacientes.AttachAsModified(currentPaciente, this.ChangeSet.GetOriginal(currentPaciente));
        }

        public void DeletePaciente(Paciente paciente)
        {
            if ((paciente.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Pacientes.Attach(paciente);
            }
            this.ObjectContext.Pacientes.DeleteObject(paciente);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TiposAtendimentos' query.
        public IQueryable<TiposAtendimento> GetTiposAtendimentos()
        {
            return this.ObjectContext.TiposAtendimentos;
        }

        public void InsertTiposAtendimento(TiposAtendimento tiposAtendimento)
        {
            if ((tiposAtendimento.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tiposAtendimento, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TiposAtendimentos.AddObject(tiposAtendimento);
            }
        }

        public void UpdateTiposAtendimento(TiposAtendimento currentTiposAtendimento)
        {
            this.ObjectContext.TiposAtendimentos.AttachAsModified(currentTiposAtendimento, this.ChangeSet.GetOriginal(currentTiposAtendimento));
        }

        public void DeleteTiposAtendimento(TiposAtendimento tiposAtendimento)
        {
            if ((tiposAtendimento.EntityState == EntityState.Detached))
            {
                this.ObjectContext.TiposAtendimentos.Attach(tiposAtendimento);
            }
            this.ObjectContext.TiposAtendimentos.DeleteObject(tiposAtendimento);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TiposSangues' query.
        public IQueryable<TiposSangue> GetTiposSangues()
        {
            return this.ObjectContext.TiposSangues;
        }

        public void InsertTiposSangue(TiposSangue tiposSangue)
        {
            if ((tiposSangue.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tiposSangue, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TiposSangues.AddObject(tiposSangue);
            }
        }

        public void UpdateTiposSangue(TiposSangue currentTiposSangue)
        {
            this.ObjectContext.TiposSangues.AttachAsModified(currentTiposSangue, this.ChangeSet.GetOriginal(currentTiposSangue));
        }

        public void DeleteTiposSangue(TiposSangue tiposSangue)
        {
            if ((tiposSangue.EntityState == EntityState.Detached))
            {
                this.ObjectContext.TiposSangues.Attach(tiposSangue);
            }
            this.ObjectContext.TiposSangues.DeleteObject(tiposSangue);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Tratamentos' query.
        public IQueryable<Tratamento> GetTratamentos()
        {
            return this.ObjectContext.Tratamentos;
        }

        public void InsertTratamento(Tratamento tratamento)
        {
            if ((tratamento.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tratamento, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Tratamentos.AddObject(tratamento);
            }
        }

        public void UpdateTratamento(Tratamento currentTratamento)
        {
            this.ObjectContext.Tratamentos.AttachAsModified(currentTratamento, this.ChangeSet.GetOriginal(currentTratamento));
        }

        public void DeleteTratamento(Tratamento tratamento)
        {
            if ((tratamento.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Tratamentos.Attach(tratamento);
            }
            this.ObjectContext.Tratamentos.DeleteObject(tratamento);
        }
    }
}


