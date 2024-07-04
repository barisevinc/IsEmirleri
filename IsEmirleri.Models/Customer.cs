using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    public class Customer:BaseModel
    {
        public string Name {  get; set; }
        public int UserLimit {  get; set; }

    }
}
