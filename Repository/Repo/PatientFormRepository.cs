using Entities;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository.Repo
{
    public class PatientFormRepository : RepositoryBase<PatientForm>
    {
        public PatientFormRepository(MedicalContext ctx) : base(ctx) {

        }
        public override int Create(PatientForm entity)
        {
            entity.MedicalForm = null;
            return base.Create(entity);
        }
        public override IQueryable<PatientForm> FindAll()
        {
            return base.FindAll().Include(c=> c.MedicalForm);
        }
    }
}
