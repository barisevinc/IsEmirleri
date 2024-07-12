using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.DTO.CustomerDTOs
{
    public class CustomerGetAllDto : Customer
    {
        public int UserCount { get; set; }
    }
}
