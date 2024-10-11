using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.ProjectDTOs
{
    public class ProjectProgressDto
    {
        public string ProjectName { get; set; }
        public int TotalMissions { get; set; } 
        public int CompletedMissions { get; set; } 
        public int OngoingMissions { get; set; } 
        public int DelayedMissions { get; set; } 
    }
}
