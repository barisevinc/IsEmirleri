using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.ProjectDTOs
{
    public class ProjectAddDto:Project
    {
        public Project Project { get; set; }

        public List<string> UserEmails { get; set; }
    }
}
