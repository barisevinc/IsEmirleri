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
        public string Description { get; set; }
        public virtual ICollection<AppUser> Assignees { get; set; }
        public int StatusId { get; set; }

    }
}
