using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    [Table("Users")]
    public class AppUser:BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public string? Picture { get; set; }
        public virtual AppUserType UserType { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Project> Projects { get; set; } = [];
        public virtual ICollection<Mission> Tasks { get; set; } = [];
    }
}
