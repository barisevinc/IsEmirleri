using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.MissionDTOs
{
    public class MissionDto
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public int MissionStatusId {  get; set; }
        public virtual MissionStatus MissionStatus { get; set; }
        public virtual ICollection<Mission> Missions { get; set; } = [];
    }
}
