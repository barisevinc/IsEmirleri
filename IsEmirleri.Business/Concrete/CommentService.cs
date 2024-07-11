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
    public class CommentService : Service<Comment>, ICommentFile
    {
        private readonly IRepository<Comment> _repository;

        public CommentService(IRepository<Comment> repository):base(repository)
        {
            _repository = repository;
        }

        public CommentFile Add(CommentFile entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CommentFile> GetAll(Expression<Func<CommentFile, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CommentFile GetFirstOrDefault(Expression<Func<CommentFile, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CommentFile Update(CommentFile entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<CommentFile> IService<CommentFile>.GetAll()
        {
            throw new NotImplementedException();
        }

        CommentFile IService<CommentFile>.GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        CommentFile IService<CommentFile>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
