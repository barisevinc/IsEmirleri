using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.MissionDTO
{
    public class MissionGetByDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan TotalDuration { get; set; } = TimeSpan.Zero;
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? MissionStartDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string StatusName { get; set; }
        public string PriorityName { get; set; }
        public string ProjectName { get; set; }
        public int? ProjectId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<string> AssigneeEmails { get; set; }
        public bool EmailNotification { get; set; }
        public bool SmsNotification { get; set; }
    }
}
