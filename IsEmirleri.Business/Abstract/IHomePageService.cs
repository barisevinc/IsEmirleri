using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface IHomePageService : IService<Contact>
    {
        Task<bool> NewMail(string mail,string message,string subject);
    }
}
