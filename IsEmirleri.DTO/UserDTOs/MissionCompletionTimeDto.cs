using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.UserDTOs
{
    public class MissionCompletionTimeDto
    {
        public string TaskTitle { get; set; } 
        public TimeSpan PlannedDuration { get; set; } 
        public TimeSpan ActualDuration { get; set; }  
        public bool IsLate { get; set; } 
    }
}
