using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Areas.Admin.Models
{
    public class RoleAssignModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Exists { get; set; }
    }
}
