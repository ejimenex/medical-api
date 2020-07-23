﻿using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
   public class MedicalFileRepository : RepositoryBase<MedicalFile>
    {
        public MedicalFileRepository(MedicalContext ctx) : base(ctx) {

        }   
    }
}
