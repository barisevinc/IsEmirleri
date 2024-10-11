using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.MissionDTO
{
    public class MissionEfficiencyDto
    {
        public int CompletedTasks { get; set; }
        public int TotalTasks { get; set; }
        public TimeSpan PlannedTime { get; set; }
        public TimeSpan ActualTime { get; set; }
        public double TaskCompletionRate { get; set; }
        public double TimeEfficiency { get; set; }
    }
}
