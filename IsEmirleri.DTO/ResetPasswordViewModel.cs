using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO
{
    public class ResetPasswordViewModel
    {
        public Guid UserGuid { get; set; }
        public string? Password { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? ConfirmationCode { get; set; } // Mailden gelen onay kodu, yani şifre
    }
}
