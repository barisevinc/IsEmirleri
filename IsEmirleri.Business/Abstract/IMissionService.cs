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
        Task<Mission> AddMission(Mission mission, List<int> userIds, bool emailNotification);

        bool UpdateStatus(int missionId, int statusId);
        UserCountDto GetCustomerInformationCounts(int userId);
        UserCountDto GetUserInformationCounts(int userId);
        bool StartMission(int missionId);
        bool StopMission(int missionId);
        bool CompleteMission(int missionId);
        TimeSpan GetMissionDuration(int missionId);
        IEnumerable<Mission> GetAllMissionsByProjectId(int projectId);
    }
}
