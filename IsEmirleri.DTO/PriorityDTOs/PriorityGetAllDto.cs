using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.PriorityDTOs
{
    public class PriorityGetAllDto:Priority
    {
        public int TaskCount { get; set; }
    }
}
