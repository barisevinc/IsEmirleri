using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.MissionDTOs
{
    public class MissionStatusWithMissionDto
    {
        public string StatusName {  get; set; }
        public List<MissionDto> Missions { get; set; } = new List<MissionDto>();
    }
}
