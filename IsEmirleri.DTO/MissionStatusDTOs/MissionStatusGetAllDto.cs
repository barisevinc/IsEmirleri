using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.MissionStatusDTOs
{
    public class MissionStatusGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskCount { get; set; }
    }
}
