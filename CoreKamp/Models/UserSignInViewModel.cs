using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKamp.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz...")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen Parolanızı Giriniz...")]
        public string userPassword { get; set; }
    }
}
