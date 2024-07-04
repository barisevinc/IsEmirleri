using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    public class CommentFile:BaseModel
    {
        public string Path {  get; set; }   
        public int CommentId {  get; set; }
        public virtual Comment Comment { get; set; }
    }
}
