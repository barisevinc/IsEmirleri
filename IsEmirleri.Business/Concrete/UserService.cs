using IsEmirleri.Business.Abstract;
using IsEmirleri.Business.Shared.Concrete;
using IsEmirleri.DTO.UserDTOs;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using IsEmirleri.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Business.Concrete
{
    public class UserService : Service<AppUser>, IUserService
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IRepository<AppUser> repo, IRepository<Customer> customerRepo, IHttpContextAccessor httpContextAccessor) : base(repo)
        {
            _repository = repo;
            _customerRepository = customerRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        public AppUser CheckLogin(AppUser user)
        {
            return _repository.GetAll().Include(p => p.UserType).Where(p => p.Email == user.Email && p.Password == user.Password).FirstOrDefault();
        }

        public AppUser Add(AppUser user)
        {
            //int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserData).Value);
            var customer = _customerRepository.GetById(user.CustomerId.Value);

            //limit kontrol usertype vermezsek admin dahil limit tutuyor
            int userCount = _repository.GetAll(u => u.CustomerId == customer.Id && !u.IsDeleted && u.UserTypeId == 3).Count();

            if (userCount >= customer.UserLimit)
            {
                return null;
            }

            user.CustomerId = customer.Id;
            user.UserTypeId = 3;
            _repository.Add(user);
            return user;
        }

        public IQueryable<UserCountDto> GetAll()
        {
            return _repository.GetAll(u => u.CustomerId == int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("CustomerId").Value) && u.IsDeleted == false && u.UserTypeId == 3)
                .Include(u => u.Tasks)
                .Include(u => u.Projects)
                .Include(u => u.Customer)
                .Select(x => new UserCountDto {

                    Id = x.Id,
                    Picture=x.Picture,
                    Email = x.Email,
                    Password = x.Password,
                    UserType = x.UserType,
                    CustomerName = x.Customer.Name,
                    TaskCount = x.Tasks.Count(),
                    ProjectCount = x.Projects.Count()
                });
          
        }
        public AppUser Profile()
        {

            return _repository.GetById(int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));

        }

        public async Task<Response<AppUser>> UpdateWithPhoto(AppUser user)
        {
            AppUser appUser = GetById(user.Id);
            try
            {
                //hata alma olasılığımızın oldu kısım bu blok içerisinde yer alır.
                if (!_httpContextAccessor.HttpContext.Request.Form.Files.IsNullOrEmpty())
                {
                    var foto = _httpContextAccessor.HttpContext.Request.Form.Files[0];
                    FileInfo fotofile = new FileInfo(foto.FileName);
                    string dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "UserPhotos");

                    if (!Directory.Exists(dosyaYolu))
                        Directory.CreateDirectory(dosyaYolu);

                    string dosyaAdi = user.Id + "-" + user.Email + "-" + Helper.RandomStringGenerator(5) + fotofile.Extension;
                    using (var stream = new FileStream(Path.Combine(dosyaYolu, dosyaAdi), FileMode.Create))
                    {
                        await foto.CopyToAsync(stream);
                    }

                    appUser.Picture = dosyaAdi;

                }
                
            }
            catch (Exception ex) {

            return new Response<AppUser> { SuccessMessage = "Kayıt güncellenemedi", ErrorMessage = ex.Message };

                //try kısmında bir hata ile karşılaşıldığında catch devreye ve burdaki işlemler yürütülür.
            }
            finally
            {
                //kesinlikle yapılması gereken bir işlemin varsa burda yapılır
                appUser.Password = user.Password;
                Update(appUser);
            }
           
            return new Response<AppUser> { SuccessMessage = "Kayıt başarıyla Güncellendi", ErrorMessage = "" };
           



        }
        public AppUser? AddCustomerUser(AppUser user)
        {
            var customer = _customerRepository.GetById(user.CustomerId.Value);

            //limit kontrol usertype vermezsek admin dahil limit tutuyor
            int userCount = _repository.GetAll(u => u.CustomerId == customer.Id && !u.IsDeleted && u.UserTypeId == 3).Count();

            if (userCount >= customer.UserLimit)
            {
                return null;
            }

            user.CustomerId = customer.Id;
            _repository.Add(user);
            return user;

           
        }

        public async Task<bool> NewUserPassword(string mail)
        {
            var appUser = GetFirstOrDefault(u => u.Email == mail);
            if(appUser is not null)
            {
                string newPassword = Helper.RandomPassword();
                appUser.Password = newPassword;
                string message = "Merhaba,<br>" +
                    "Şifreniz yenilenmiştir.<br>" +
                   $"Şifreniz: {newPassword}";
                _repository.Update(appUser);
                if (await HelperMail.SendMail(appUser.Email, "Şifre Yenileme", message))
                {
                    
                    return true;

                }

                return false;
            }
            else
            {
                return false;
            }
         
        }
    } }
