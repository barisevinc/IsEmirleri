using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.MissionStatusDTOs;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using IsEmirleri.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class StatusService : Service<MissionStatus>, IStatusService
    {
        private readonly IRepository<MissionStatus> _repository;
        private readonly IRepository<Mission>  _repositoryMission;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public StatusService(IRepository<MissionStatus> repo, IHttpContextAccessor httpContextAccessor, IRepository<Mission> repositoryMission) : base(repo)
        {
            _repository = repo;
            _httpContextAccessor = httpContextAccessor;
            _repositoryMission = repositoryMission;
        }






        public MissionStatus Add(MissionStatus status)
        {
            var customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            status.CustomerId = customerId;

            return _repository.Add(status);
        }

        public List<MissionStatusGetAllDto> GetAllByStatus()
        {
          return  _repository.GetAll().Select(s => new MissionStatusGetAllDto
            {
                Id = s.Id,
                Name = s.Name,
                TaskCount = _repositoryMission.GetAll().Where(x => x.StatusId == s.Id).Count()
            }).ToList();
        }
    }
}
