using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Zathura.Admin.CustomFilter;
using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Data.Model;
using Zathura.Admin.Helper;

namespace Zathura.Admin.Controllers
{
    public class ContentTypeController : Controller
    {
        #region Primitives
        private const int PagingCount = 30;
        #endregion

        #region Repositories
        private readonly IContentTypeRepository _contentTypeRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;

        #endregion

        public ContentTypeController(IContentTypeRepository contentTypeRepository, ISystemSettingRepository systemSettingRepository)
        {
            _contentTypeRepository = contentTypeRepository;
            _systemSettingRepository = systemSettingRepository;
        }



        // GET: Publisher
        [HttpGet]
        [LoginFilter]
        public ActionResult Index(int p = 1)
        {
            return View(_contentTypeRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
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
        public JsonResult Add(ContentType contentType)
        {
            try
            {
                if (contentType == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Type couldn't found!" });

                }
                _contentTypeRepository.Insert(contentType);
                _contentTypeRepository.Save();
                return Json(new ResultJson() { Success = true, Message = "Type Added Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Type couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }

        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int id)
        {
            var publisher = _contentTypeRepository.GetById(id);
            if (publisher == null)
            {
                return Json(new ResultJson { Success = false, Message = "Type couldn't found!" });
            }
            PrepareForms();

            return View(publisher);
        }

        [HttpPost]
        [LoginFilter]
        public JsonResult Update(ContentType contentType)
        {
            try
            {
                var contentTypeItem = _contentTypeRepository.GetById(contentType.ID);
                if (contentTypeItem == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Type couldn't found!" });
                }
                contentTypeItem.Name = contentType.Name;

                _contentTypeRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Type updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Type couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
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
                var content = _contentTypeRepository.GetById(id);
                if (content != null)
                {
                    _contentTypeRepository.Delete(id);
                    _contentTypeRepository.Save();
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