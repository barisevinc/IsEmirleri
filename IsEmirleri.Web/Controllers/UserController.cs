﻿using IsEmirleri.Business.Abstract;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IsEmirleri.Utility;
using Microsoft.IdentityModel.Tokens;
using IsEmirleri.DTO;

namespace IsEmirleri.Web.Controllers
{
    [Authorize(Roles = "Admin, Superadmin")]

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AppUser user)
        {
            if (user != null)
            {
                AppUser appUser = _userService.CheckLogin(user);
                // var item = appUser.Picture.Length;
                if (appUser != null)
                {

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
                    claims.Add(new Claim(ClaimTypes.Actor, appUser.Picture == null ? "null.png" : appUser.Picture.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, appUser.UserType.Name));
                    claims.Add(new Claim(ClaimTypes.UserData, appUser.CustomerId.ToString()));
                    claims.Add(new Claim("CustomerId", appUser.CustomerId.ToString()));



                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = true });

                    if (appUser.UserType.Name == "Admin")
                    {
                        TempData["success"] = $"Hoşgeldiniz";
                        return RedirectToAction("Index", "User");
                    }
                    if (appUser.UserType.Name == "Superadmin")
                    {
                        TempData["success"] = $"Hoşgeldiniz";
                        return RedirectToAction("Index", "Customer");
                    }

                    else
                        TempData["success"] = $"Hoşgeldiniz";

                    return RedirectToAction("Index", "Mission");
                }
            }
            TempData["error"] = "Kullanıcı Adı ya da Şifreniz Yanlıştır!";
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
        public IActionResult GetAll()
        {

            return Json(new { data = _userService.GetAll() });
        }
        [HttpPost]
        public IActionResult Add(AppUser user)
        {
            var addedUser = _userService.Add(user);

            if (addedUser != null)
            {
                return Ok(new
                {
                    result = true,
                    message = "Kullanıcı Başarılı Bir Şekilde Oluşturulmuştur.",
                    userId = addedUser.Id,
                    customerName = addedUser.Customer.Name 
                });
            }

            return Ok(new { result = false, message = "Kullanıcı Limitiniz Dolmuştur. Lütfen Ürün Yöneticiniz İle Görüşünüz." });
        }
       
        [HttpPost]
        public IActionResult AddCustomerUser(AppUser user)
        {
            if (_userService.AddCustomerUser(user) != null)
                return Ok(new { result = true, message = "Kullanıcı Başarılı Bir Şekilde Oluşturulmuştur.", userId = user.Id });

            return Ok(new { result = false, message = "Kullanıcı Limitiniz Dolmuştur. Lütfen Ürün Yöneticiniz İle Görüşünüz." });

        }

        [HttpPost]
        public IActionResult Delete(AppUser user)
        {

            return Ok(_userService.Delete(user.Id));

        }
        [HttpPost]
        public IActionResult Update(AppUser user)
        {

            return Ok(_userService.Update(user));
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Json(_userService.GetById(id));
        }
        [AllowAnonymous]
        public IActionResult Password()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Password(string email)
        {
            if (await _userService.NewUserPassword(email))
            {
                var appUser = _userService.GetFirstOrDefault(u => u.Email == email);

                Guid userGuid = appUser.Guid;

                TempData["success"] = "Onay Kodu Mail Adresinize Gönderilmiştir.";
                return RedirectToAction("ResetPassword", "User", new { guid = userGuid });

            }
            else
            {
                TempData["error"] = "Şifre Yenileme İşlemi Başarısızdır.";
                return RedirectToAction("password");
            }

        }



        [AllowAnonymous]
        public IActionResult ResetPassword(Guid guid)
        {
            var user = _userService.GetByGuid(guid);
            if (user == null)
            {
                TempData["error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Login");
            }


            var model = new ResetPasswordViewModel { UserGuid = guid };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirm(ResetPasswordViewModel model)
        {
            if (model.NewPassword != model.ConfirmPassword)
            {
                TempData["error"] = "Şifreler uyuşmuyor!";
                return View("ResetPassword", model);
            }

            var user = _userService.GetByGuid(model.UserGuid);
            if (user == null)
            {
                TempData["error"] = "Kullanıcı bulunamadı.";
                return View("ResetPassword", model);
            }


            if (user.Password != model.Password)
            {
                TempData["error"] = "Onay kodu yanlış.";
                return View("ResetPassword", model);
            }


            user.Password = model.NewPassword;
            _userService.Update(user);

            TempData["success"] = "Şifreniz başarıyla yenilendi.";
            return RedirectToAction("Login");
        }



        [AllowAnonymous]
        public IActionResult Profile()
        {
            return View(_userService.Profile());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(AppUser user)
        {


            await _userService.UpdateWithPhoto(user);


            return RedirectToAction("Profile", "User");




        }
    }
}
