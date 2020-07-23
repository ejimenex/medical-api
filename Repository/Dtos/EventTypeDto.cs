using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class EventTypeDto:BaseDto
    {
        public string Name { get; set; }
        public string DoctorId { get; set; }
    }
}
