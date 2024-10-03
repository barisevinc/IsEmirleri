using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Models
{
    [Table("Tasks")]
    public class Mission:BaseModel
    {
        public string? Title {  get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StopWatch { get; set; }
        public TimeSpan? TotalDuration { get; set; }=TimeSpan.Zero;
        public bool IsActive { get; set; } = true;
        public bool IsCompleted { get; set; } = true;
        public bool EmailNotification { get; set; } = false;
        public bool SmsNotification {  get; set; } = false; 
        public int StatusId {  get; set; }
        public virtual MissionStatus Status { get; set; }
        public int ProjectId {  get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = [];

        public virtual ICollection<AppUser> Assignees { get; set; } = [];
        public virtual ICollection<TaskHistory> TaskHistory { get; set; } = [];
        public virtual ICollection<TaskFile>? Files { get; set; }= [];
        public int PriorityId { get; set; }
        public virtual Priority Priority { get; set; }

    }
}
