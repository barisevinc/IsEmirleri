using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.UserDTOs
{
    public class UserCountDto : AppUser
    {
        public int ProjectCount { get; set; }
        public int TaskCount { get; set; }
        public string CustomerName { get; set; }
    }
}

