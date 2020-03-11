
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class DocumentService : BaseService<Documents>
    {
        
        public DocumentService(IRepository<Documents> repository) :base(repository)
        {
           
        }
       

    }
}
