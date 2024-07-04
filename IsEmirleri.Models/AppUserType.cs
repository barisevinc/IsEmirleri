using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    [Table("UserTypes")]
    public class AppUserType:BaseModel
    {
        //Superadmin - Biz
        //admin - Customer'ın ana kullanıcısı
        //user - Customer'a bağlı diğer kullanıcılar
        public string? Name {  get; set; }
    }
}
