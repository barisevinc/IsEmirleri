using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    public class Notification:BaseModel
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public string Icon { get; set; }
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
