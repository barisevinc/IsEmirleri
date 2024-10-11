using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.MissionDTOs
{
    public class TaskStatusDto
    {
        public string Email { get; set; }
        public int CompletedTasks { get; set; }
        public int OngoingTasks { get; set; }
        public int DelayedTasks { get; set; }
    }
}
