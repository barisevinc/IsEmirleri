using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class CommentFileService : Service<CommentFile>, ICommentFile
    {
        private readonly IRepository<MissionStatus> _repository;
        private readonly IRepository<Mission> _repositoryMission;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommentFileService(IRepository<CommentFile> repo) : base(repo)
        {
        }
    }
}
