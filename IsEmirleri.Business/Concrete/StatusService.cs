using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StatusService(IRepository<MissionStatus> repo, IHttpContextAccessor httpContextAccessor) : base(repo)
        {
            _repository = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQueryable<MissionStatus> GetAllStatus()
        {
            return _repository.GetAll();
        }




        public MissionStatus Add(MissionStatus status)
        {
            var customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            status.CustomerId = customerId;

            return _repository.Add(status);
        }
        public IQueryable<MissionStatus> GetAll(int statusId)
        {
            return _repository.GetAll().Select(x => new MissionStatus
            {
                Id = x.Id,
                Name = x.Name,
                CustomerId = x.CustomerId,
            });
        }






    }
}
