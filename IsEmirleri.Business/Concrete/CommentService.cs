using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class CommentService : Service<Comment>, ICommentService
    {
        private readonly IRepository<Comment> _repository;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentService(IRepository<Comment> repository, IUserService userService, IHttpContextAccessor httpContextAccessor) :base(repository)
        {
            _repository = repository;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQueryable<Comment> AddComment(Comment comment)
        {
            comment.UserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _repository.Add(comment);
            return _repository.GetAll(c=>c.TaskId == comment.TaskId).Include(c => c.User);
        }
    }
}
