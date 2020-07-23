
using Entities.Entity;
using Repository.Interface;
namespace BussinesLogic.Service
{
    public class MedicalFileService : BaseService<MedicalFile>
    {
        
        public MedicalFileService(IRepository<MedicalFile> repository):base(repository)
        {
        
        }
        public override int Create(MedicalFile entity)
        {
            return base.Create(entity);
        }


    }
}
