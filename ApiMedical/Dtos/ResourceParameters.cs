using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Dtos
{
    public class ResourceParameters
    {

        const int maxPageSize = 10;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public string parameters { get; set; }
        public DateTime? datefrom { get; set; }
        public DateTime? dateto { get; set; }
        public int? param { get; set; }
        public Guid? DoctorGuid { get; set; }
        public int? DoctorId { get; set; }
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
    }
}
