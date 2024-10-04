using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    [Table("Users")]
    public class AppUser:BaseModel
    {
        [Required(ErrorMessage = "Email gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public string? Picture { get; set; }
        public virtual AppUserType UserType { get; set; }
        public int? CustomerId { get; set; }
        public string? PasswordHash {  get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Project> Projects { get; set; } = [];
        public virtual ICollection<Mission> Tasks { get; set; } = [];
        public virtual ICollection<Notification> Notifications { get; set; } = [];

        public virtual ICollection<TaskHistory> TaskHistories { get; set; }
    }
}
