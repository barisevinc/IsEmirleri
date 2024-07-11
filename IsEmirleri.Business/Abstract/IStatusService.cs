using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.MissionStatusDTOs;
using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface IStatusService : IService<MissionStatus>
    {
        List<MissionStatusGetAllDto> GetAllByStatus();
    }
}
