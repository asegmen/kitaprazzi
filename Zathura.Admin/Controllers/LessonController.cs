using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Zathura.Admin.CustomFilter;
using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Core.Repository;
using Kitaprazzi.Core.Helper;
using Kitaprazzi.Data.Model;
using Zathura.Admin.Helper;

namespace Zathura.Admin.Controllers
{
    public class LessonController : Controller
    {
        #region Primitives
        private const int PagingCount = 30;
        #endregion

        #region Repositories
        private readonly ILessonRepository _lessonRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;

        #endregion

        public LessonController(ILessonRepository lessonRepository, ISystemSettingRepository systemSettingRepository)
        {
            _lessonRepository = lessonRepository;
            _systemSettingRepository = systemSettingRepository;
        }



        // GET: Publisher
        [HttpGet]
        [LoginFilter]
        public ActionResult Index(int p = 1)
        {
            return View(_lessonRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
        }


        [HttpGet]
        [LoginFilter]
        public ActionResult Add()
        {
            PrepareForms();
            return View();
        }

        [HttpPost]
        [LoginFilter]
        public JsonResult Add(Lesson lesson)
        {
            try
            {
                if (lesson == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Lesson couldn't found!" });

                }
                _lessonRepository.Insert(lesson);
                _lessonRepository.Save();
                return Json(new ResultJson() { Success = true, Message = "Lesson Added Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Lesson couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }

        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int id)
        {
            var publisher = _lessonRepository.GetById(id);
            if (publisher == null)
            {
                return Json(new ResultJson { Success = false, Message = "Publisher couldn't found!" });
            }
            PrepareForms();

            return View(publisher);
        }

        [HttpPost]
        [LoginFilter]
        public JsonResult Update(Lesson lesson)
        {
            try
            {
                var lessonItem = _lessonRepository.GetById(lesson.ID);
                if (lessonItem == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Lesson couldn't found!" });
                }
                lessonItem.Name = lesson.Name;
                

                _lessonRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Lesson updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Lesson couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
        }

        public void PrepareForms()
        {
            
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
        }
      
        [LoginFilter]
        public ActionResult Delete(int id)
        {
            try
            {
                var content = _lessonRepository.GetById(id);
                if (content != null)
                {
                    _lessonRepository.Delete(id);
                    _lessonRepository.Save();
                }
               
                //return Json(new ResultJson { Success = true, Message = "Content deleted successfully..." });
            }
            catch (Exception ex)
            {
                //return Json(new ResultJson { Success = false, Message = "Content couldnt deleted!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
            return Index(1);
        }
    }
}