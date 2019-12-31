using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMedical.Dtos
{
   public class HealthManagerDto : BaseDto
    {
     public string Name { get; set; }
     public int CountryId { get; set; }
     public string Country { get; set; }
    }
}
