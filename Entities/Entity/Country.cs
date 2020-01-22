using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity
{
   public class Country:BaseClass
    {

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
