using Kitaprazzi.Data.Model;
using Kitaprazzi.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kitaprazzi.Core.Infrastructure;

namespace Zathura.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region User
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var useList = _userRepository.GetAll().ToList();

            var userExists =
                _userRepository.GetMany(x => x.Email == user.Email && x.Password == user.Password && x.Status)
                    .SingleOrDefault();
            if (userExists != null) 
            {
                if (userExists.Role.Name == Roles.Admin)
                {
                    Session[Kitaprazzi.Core.Helper.Session.User] = userExists;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Unauthorized User!!!";
            }
            ViewBag.Message = "User does not exists!!!";
            return View();
        }
    }
}