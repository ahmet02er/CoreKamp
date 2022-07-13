using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Areas.Admin.Models
{
    public class RoleModel
    {
        [Required(ErrorMessage ="Lütfen Rol Adı Giriniz..")]
        public string name { get; set; }
        public string normalizeName { get; set; }
    }
}
