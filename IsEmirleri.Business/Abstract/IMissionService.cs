using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.DTO.MissionDTO;
using IsEmirleri.DTO.MissionDTOs;
using IsEmirleri.DTO.UserDTOs;
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
        MissionGetByDto GetByMissionId(int missionId);
        bool UpdateMissionDescription(int missionId, string description);
        List<MissionDto> GetAllMission();
        Mission AddMission(Mission mission, List<int> userIds);

        bool UpdateStatus(int missionId, int statusId);
        UserCountDto GetCustomerInformationCounts(int userId);

    }
}
