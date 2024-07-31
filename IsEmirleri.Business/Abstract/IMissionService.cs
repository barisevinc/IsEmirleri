using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.DTO.MissionDTOs;
using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface IMissionService:IService<Mission>
    {
        IQueryable<Mission> GetAllMission(List<int> ids);
        //IQueryable<MissionDto> GetTaskBystatus(int ids);
       // List<MissionStatusWithMissionDto> GetAllMissionDto();

    }
}
