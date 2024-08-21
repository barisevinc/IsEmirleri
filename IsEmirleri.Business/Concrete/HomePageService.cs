using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using IsEmirleri.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class HomePageService : Service<Contact>, IHomePageService
    {
        private readonly IRepository<Contact> _repository;

        public HomePageService(IRepository<Contact> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> NewMail(string mail, string message, string subject)
        {

            if (await HelperMail.SendMail(mail, subject, message))
            {

                return true;

            }

            else
            {
                return false;
            }
        }
    }
}
