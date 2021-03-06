﻿using Entities;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
   public class UserRepository:RepositoryBase<Users>
    {
        public UserRepository(MedicalContext ctx) : base(ctx) {

        }

        public override IQueryable<Users> FindAll()
        {
            return base.FindAll().Include(c=> c.Role);
        }

    }
}
