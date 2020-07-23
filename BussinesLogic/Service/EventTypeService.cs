
using Entities.Entity;
using Repository.Interface;
namespace BussinesLogic.Service
{
    public class EventTypeService : BaseService<EventTypes>
    {
        
        public EventTypeService(IRepository<EventTypes> repository) :base(repository)
        {
           
        }
       

    }
}
