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
        public ActionResult Enterance()
        {
            return View("~/Views/User/_NewUser.cshtml");
        }

        [HttpPost]
        public ActionResult Add(User userModel)
        {
            try
            {
                var existMail = _userRepository.GetMany(x => x.Email == userModel.Email);
                if (existMail.Any())
                {
                    return View("~/Views/User/_NewUser.cshtml");
                }
                userModel.RoleID = 10;
                _userRepository.Insert(userModel);
                _userRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return View("~/Views/User/_NewUser.cshtml");

            }

        }
    }
}