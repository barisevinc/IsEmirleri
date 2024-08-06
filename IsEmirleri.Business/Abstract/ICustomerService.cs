using IsEmirleri.Business.Shared.Abstract;
using IsEmirleri.DTO.CustomerDTOs;
using IsEmirleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Abstract
{
    public interface ICustomerService : IService<Customer>
    {
        IQueryable<CustomerGetAllDto> GetAllWithUserCount();
        IQueryable<AppUser> GetAllUsersById(int customerId);
        CustomerGetAllDto UpdateCustomer(Customer customer);
        bool UpdateCustomerUsers(AppUser user);
        bool IsLimitAvailable(int customerId);

    }
}
