using Entities;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Repo
{
   public class EventTypeRepository : RepositoryBase<EventTypes>
    {
        public EventTypeRepository(MedicalContext ctx) : base(ctx)
        {

        }

    }
}
