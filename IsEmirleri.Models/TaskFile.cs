using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    public class TaskFile:BaseModel
    {
        public string Path {  get; set; }
        public int TaskId {  get; set; }
        public virtual Mission Task { get; set; }
    }
}
