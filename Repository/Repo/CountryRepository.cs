using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
   public class CountryRepository:RepositoryBase<Country>,ICountryReposotory
    {
        public CountryRepository(MedicalContext ctx) : base(ctx) {

        }
   
    }
}
