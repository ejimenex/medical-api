using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity
{
    public class PermissionRoles
    {
        [Key]
        public int Id { get; set; }
        public int? PermissionId { get; set; }
        public int? RolId { get; set; }
        public bool? HasPermission{get;set;}

    }
}
