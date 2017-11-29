using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Owin.Security;
using TestTask.BLL.DTO;
using TestTask.BLL.Interfaces;
using TomskNipiNeft.TestTask.Models;

namespace TomskNipiNeft.TestTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        private IAuthenticationManager Authentication =>
            HttpContext.GetOwinContext().Authentication;

        public AccountController(IUserService userService)
        {
            _userService = userService;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoginModel, UserDto>();
                cfg.CreateMap<RegisterModel, UserDto>();
            }).CreateMapper();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            SetInitialData();
            if (!ModelState.IsValid) return View(model);

            var userDto = _mapper.Map<LoginModel, UserDto>(model);
            var claim = _userService.Authenticate(userDto);
            if (claim == null)
            {
                ModelState.AddModelError("", "Неверный логин или пароль.");
                return View(model);
            }

            Authentication.SignOut();
            Authentication.SignIn(
                new AuthenticationProperties { IsPersistent = true }, claim);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Authentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            SetInitialData();
            if (!ModelState.IsValid) return View(model);

            var userDto = _mapper.Map<RegisterModel, UserDto>(model);
            userDto.Role = Roles.User;
            var operationDetails = _userService.Create(userDto);
            if (operationDetails.Succedeed) return View("SuccessRegister");

            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return View(model);
        }

        private void SetInitialData()
        {
            _userService.SetInitialData(
                new UserDto
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru",
                    Password = "P2w0rd",
                    Name = "Семен Семенович Горбунков",
                    Address = "ул. Спортивная, д.30, кв.75",
                    Role = Roles.Admin
                }, new List<string>{Roles.Admin, Roles.User});
        }
    }
}