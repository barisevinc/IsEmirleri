using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    public class Comment:BaseModel
    {
        public string Description { get; set; } 
        public int UserId {  get; set; }
        public virtual AppUser User { get; set; }

        public int TaskId {  get; set; }
        public virtual Mission Task { get; set; }

        public int? ParentId {  get; set; }
        public virtual Comment Parent { get; set; }
        public virtual ICollection<CommentFile> Files { get; set; }




    }
}
