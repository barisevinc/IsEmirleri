using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    public class Priority:BaseModel
    {
        public string Name { get; set; }
        public int CustomerId {  get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}
