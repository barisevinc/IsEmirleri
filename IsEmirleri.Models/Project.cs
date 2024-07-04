using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    public class Project:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerId {  get; set; }
      
        public virtual Customer Customer { get; set; }
        public virtual ICollection<AppUser> Users { get; set; } = [];

    }
}
