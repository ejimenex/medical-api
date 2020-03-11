using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interface
{
   public interface ICurrency
    {
        IQueryable<Currency> GetAll();
    }
}
