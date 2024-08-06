﻿using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.DTO.MissionDTO;
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
        List<MissionDto> GetAllMission();
        Mission AddMission(Mission mission, List<int> userIds);
        MissionGetByDto GetByMissionId(int missionId);
        bool UpdateMissionDescription(int missionId, string description);

    }
}
