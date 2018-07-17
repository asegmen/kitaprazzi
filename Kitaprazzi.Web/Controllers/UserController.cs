using Kitaprazzi.Core.Helper;
using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kitaprazzi.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View("~/Views/User/_NewUser.cshtml");
        }
        public ActionResult Enterance()
        {
            return View("~/Views/User/_UserEnterance.cshtml");
        }
        public ActionResult ForgatPassword()
        {
            return View("~/Views/User/_UserForgetPassword.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(User userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existMail = _userRepository.GetMany(x => x.Email == userModel.Email);
                    if (existMail.Any())
                    {
                        ViewBag.IsUserExists = true;
                        return View("~/Views/User/_NewUser.cshtml");
                    }
                    userModel.RoleID = 10;
                    _userRepository.Insert(userModel);
                    _userRepository.Save();
                }
                else
                {
                    return View("~/Views/User/_NewUser.cshtml");
                }
                
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View("~/Views/User/_NewUser.cshtml");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enterance(User userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userControl = _userRepository.Get(x => x.Email.Equals(userModel.Email) && x.Password.Equals(userModel.Password) && x.Status == (int)Status.Active);
                    if (userControl != null)
                    {
                        Session[Kitaprazzi.Core.Helper.Session.User] = userControl;
                    }
                    return RedirectToAction("Index", "Home");
                }
                return View("~/Views/User/_UserEnterance.cshtml");
            }
            catch (Exception)
            {
                return View("~/Views/User/_UserEnterance.cshtml");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgatPassword(User userModel)
        {
            try
            {
                var userControl = _userRepository.Get(x => x.Email.Equals(userModel.Email) && x.Status == (int)Status.Active);
                string body = $"Merhaba {userControl.Name} {userControl.Surname} </br> Talebiniz üzere şifreniz: {userControl.Password}";
                EMailHelper.SendMail(userControl.Email, "Üyelik Yönetim Kitaprazzi", "Şifre Talebi", body);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View("~/Views/User/_UserForgetPassword.cshtml");
            }
        }
    }
}