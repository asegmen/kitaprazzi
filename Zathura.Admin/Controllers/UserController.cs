using Kitaprazzi.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Zathura.Admin.CustomFilter;
using Kitaprazzi.Data.Model;
using Zathura.Admin.Helper;
using Kitaprazzi.Core.Helper;

namespace Zathura.Admin.Controllers
{
    public class UserController : Controller
    {

        private const int PagingCount = 30; 
        #region User
        private readonly IUserRepository _userRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;
        private readonly IRoleRepository _roleRepository;


        public UserController(IUserRepository userRepository, ISystemSettingRepository systemSettingRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _systemSettingRepository = systemSettingRepository;
            _roleRepository = roleRepository;
        }
        #endregion
        // GET: User
        public ActionResult Index(int p=1)
        {
            return View(_userRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
        }

        public ActionResult Delete(int userId)
        {
            try
            {
                var content = _userRepository.GetById(userId);
                if (content == null)
                {
                }
                _userRepository.Delete(userId);
                _userRepository.Save();
                //return Json(new ResultJson { Success = true, Message = "Content deleted successfully..." });
            }
            catch (Exception ex)
            {
                return Redirect("Index");
                //return Json(new ResultJson { Success = false, Message = "Content couldnt deleted!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
            return Redirect("Index");
        }

        #region Update Category
        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception("Category couldn't found!");
            }
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
            var roleList = _roleRepository.GetMany(x => x.Status == (int)Status.Active).ToList();
            ViewBag.RoleList = roleList;
            return View(user);
        }

        [HttpPost]
        [LoginFilter]
        public ActionResult Update(User _user)
        {
            try
            {
                var userItem = _userRepository.GetById(_user.ID);
                if (userItem.Status != _user.Status)
                {
                    string body = $"Merhaba {userItem.Name} {userItem.Surname} </br>";
                    body += " hesabınız " + (_user.Status == (int)Status.Active ? "Aktif" : "Pasif") + " hale getirilmiştir.";
                    EMailHelper.SendMail(userItem.Email, "Üyelik Yönetim Kitaprazzi", "Aktivasyon Bilgilendirme", body);
                }
                userItem.RoleID = _user.RoleID;
                userItem.Status = _user.Status;
                _userRepository.Save();
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "User couldnt updated!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
            return RedirectToAction("Index");

        }

        #endregion
    }
}