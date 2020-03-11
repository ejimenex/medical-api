
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class EventTypeService : BaseService<EventTypes>
    {
        
        public EventTypeService(IRepository<EventTypes> repository) :base(repository)
        {
           
        }
       

    }
}
