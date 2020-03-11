using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiMedical.Dtos
{
   public class HealthManagerDto : BaseDto
    {
        [Required(ErrorMessage ="Required Field Name")]
     public string Name { get; set; }
     public int CountryId { get; set; }
     public string Country { get; set; }
    }
}
