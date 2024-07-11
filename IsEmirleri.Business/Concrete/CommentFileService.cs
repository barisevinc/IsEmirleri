using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class CommentFileService : Service<CommentFile>, ICommentFile
    {
        private readonly IRepository<CommentFile> _repository;

        public CommentFileService(IRepository<CommentFile> repository):base(repository) 
        {
            _repository = repository;
        }
    }
}
