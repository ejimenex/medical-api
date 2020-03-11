
using Entities.Entity;
using Repository.Interface;
namespace BussinesLogic.Service
{
    public class PersonalScheduleService : BaseService<PersonalSchedule>
    {
        
        public PersonalScheduleService(IRepository<PersonalSchedule> repository):base(repository)
        {
        
        }
        public override int Create(PersonalSchedule entity)
        {
            entity.Patient = null;
            entity.EventTypes = null;
            entity.State = true;
            return base.Create(entity);
        }
        public override PersonalSchedule Update(PersonalSchedule entity)
        {
            entity.Patient = null;
            entity.EventTypes = null;
            return base.Update(entity);
        }

    }
}
