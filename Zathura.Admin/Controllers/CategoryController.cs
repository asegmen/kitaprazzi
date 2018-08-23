using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.Helper;
using PagedList;
using Zathura.Admin.CustomFilter;
using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Core.Repository;
using Kitaprazzi.Core.Helper;
using Kitaprazzi.Data.Model;
using Zathura.Admin.Models;

namespace Zathura.Admin.Controllers
{
    public class CategoryController : Controller
    {
        #region Primitives
        private const int PagingCount = 30;
        #endregion

        #region Repositories
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;
        private readonly ILessonRepository _lessonRepository;

        public CategoryController() : this(new CategoryRepository(), new SystemSettingRepository(), new LessonRepository())
        {
              
        }

        public CategoryController(ICategoryRepository categoryRepository, ISystemSettingRepository systemSettingRepository, ILessonRepository lessonRepository)
        {
            _categoryRepository = categoryRepository;
            _systemSettingRepository = systemSettingRepository;
            _lessonRepository = lessonRepository;
        }
        #endregion
        

        #region MyRegion

        
        #endregion

        #region Index
        [HttpGet]
        public ActionResult Index(int p = 1)
        {
            return View(_categoryRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
        }
        #endregion

        #region Add Category
        [HttpGet]
        public ActionResult Add()
        {
            var parentCatList = _categoryRepository.GetMany(x => x.Status == (int)Status.Active).ToList();
            ViewBag.ParentCategoryList = parentCatList;
            var generalLessonList = _lessonRepository.GetMany(x=> x.Status == (int) Status.Active).ToList();
            var lessonList = new List<CheckLessonModel>();
            foreach (var item in generalLessonList)
            {
                lessonList.Add(new CheckLessonModel { LessonId = item.ID, LessonName = item.Name, IsCheck = false});
            }
            ViewBag.LessonList = lessonList;
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
            return View();
        }

        [HttpPost]
        public JsonResult Add(Category category)
        {
            try
            {
                _categoryRepository.Insert(category);
                _categoryRepository.Save();
                category.Url = $"/category/{TextHelper.ClearForUrl(category.Name)}-{category.ID}";
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                return Json(new ResultJson() { Success = true, Message = "Category Added Successfully." });

            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Category couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
        }
        #endregion

        #region Update Category
        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new Exception("Category couldn't found!");
            }
            var parentCatList = _categoryRepository.GetMany(x =>x.Status == (int)Status.Active).ToList();
            ViewBag.ParentCategoryList = parentCatList;
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
            var lessonIDList = category.LessonIDs?.Split(new char[] { ',' });
            var generalLessonList = _lessonRepository.GetMany(x => x.Status == (int)Status.Active).ToList();
            var lessonList = new List<CheckLessonModel>();
            foreach (var item in generalLessonList)
            {
                lessonList.Add(new CheckLessonModel { LessonId = item.ID, LessonName = item.Name, IsCheck = lessonIDList != null && lessonIDList.Any(x=>x.Equals(item.ID.ToString())) });
            }
            ViewBag.LessonList = lessonList;
            return View(category);
        }

        [HttpPost]
        [LoginFilter]
        public JsonResult Update(Category category)
        {
            try
            {
                var categoryItem = _categoryRepository.GetById(category.ID);
                categoryItem.Status = category.Status;
                categoryItem.Name = category.Name;
                categoryItem.CategoryID = category.CategoryID;
                categoryItem.LessonIDs = category.LessonIDs;
                _categoryRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Category updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Category couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }

        }

        #endregion

        #region Delete Category
        public ActionResult Delete(int id)
        {
            try
            {
                var category = _categoryRepository.GetById(id);
                if (category == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Category couldn't found!" });
                }
                _categoryRepository.Delete(id);
                _categoryRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Category deleted successfully..." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Category couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
            
        }
        #endregion


    }
}