﻿using IsEmirleri.Business.Abstract;
using IsEmirleri.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IsEmirleri.Utility;

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
                if (appUser != null)
                {

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
                    claims.Add(new Claim(ClaimTypes.Role, appUser.UserType.Name));
                    claims.Add(new Claim(ClaimTypes.UserData, appUser.CustomerId.ToString()));


                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = true });

                    if (appUser.UserType.Name == "Admin"|| appUser.UserType.Name == "Superadmin")
                        return RedirectToAction("Index", "User");
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
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


            if (_userService.Add(user)!=null)
                return Ok(new { result = true, message = "Kullanıcı Başarılı Bir Şekilde Oluşturulmuştur." ,userId=user.Id});
       
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
        public IActionResult Password(string email)
        {
            var newPassword =Helper.RandomPassword();
            return Ok(newPassword);
        }
        public IActionResult Profile()
        {
            return View(_userService.Profile());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(AppUser user)
        {
            var test = await _userService.UpdateWithPhoto(user, HttpContext.Request.Form.Files[0], int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            if (test.Result != null)
            {
                return RedirectToAction("Profile", "User");
            }
            else
            {
                return BadRequest("Hata");
            }



        }
    }
}
