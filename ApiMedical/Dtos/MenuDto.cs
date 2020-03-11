using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Dtos
{

    public class MenuDto
    {

        public string name { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public bool? display { get; set; }
      
        public List<ChildrenDto> children { get; set; }

    }
    public class ChildrenDto
    {
        public string name { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public bool? display { get; set; }

    }

}

