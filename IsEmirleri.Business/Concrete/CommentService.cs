using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class CommentService : Service<Comment>, IComment
    {
        private readonly IRepository<Comment> _repository;

        public CommentService(IRepository<Comment> repository):base(repository)
        {
            _repository = repository;
        }

    }
}
