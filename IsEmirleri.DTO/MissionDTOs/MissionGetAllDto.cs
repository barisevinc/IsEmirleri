using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.MissionDTOs
{
    public class MissionGetAllDto:Mission
    {
        public string ProjectName {  get; set; }
        public string PriorityName {  get; set; }
    }
}
