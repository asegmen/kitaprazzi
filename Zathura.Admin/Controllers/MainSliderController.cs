using Kitaprazzi.Core.Helper;
using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.CustomFilter;

namespace Zathura.Admin.Controllers
{
    public class MainSliderController : Controller
    {
        private const int PagingCount = 30;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMainSliderRepository _mainSliderRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;

        public MainSliderController(ICategoryRepository categoryRepository, ISystemSettingRepository systemSettingRepository, IMainSliderRepository mainSliderRepository)//, IMemoryCacheManager cacheManager
        {
            _categoryRepository = categoryRepository;
            _systemSettingRepository = systemSettingRepository;
            _mainSliderRepository = mainSliderRepository;
            //_cacheManager = cacheManager;
        }
        // GET: MainSlider
        public ActionResult Index(int p=1)
        {
            return View(_mainSliderRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
        }


        [HttpGet]
        [LoginFilter]
        public ActionResult Add()
        {
            PreparePage();
            return View();
        }
        public void PreparePage(object category = null)
        {
            //if (!_cacheManager.IsSet("CategoriList_"))
            //{
            //    _cacheManager.Add("CategoriList_", _categoryRepository.GetMany(x => x.ParentCategoryId == 0).ToList(), 3600);
            //}
            var sliderTtypes = new List<Tuple<int, string>>();
            sliderTtypes.Add(new Tuple<int, string>(1, "Detay Slider"));
            sliderTtypes.Add(new Tuple<int, string>(2, "Görsel Slider"));
            ViewBag.SliderTypeList = sliderTtypes;

        }

        [HttpPost, ValidateInput(false)]
        [LoginFilter]
        public ActionResult Add(MainSlider slider, HttpPostedFileBase spotImage )
        {
            if (ModelState.IsValid) //check Content object attributes is ok?
            {
               //insert spot images
                if (spotImage != null)
                {
                    string fileName = Guid.NewGuid().ToString().Replace("-", "");
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string fullPath = "/external/content/" + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(fullPath));
                    slider.ImageUrl = fullPath;
                }
            }
            _mainSliderRepository.Insert(slider);
            _mainSliderRepository.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int id)
        {
            var content = _mainSliderRepository.GetById(id);
            if (content == null)
            {
                throw new Exception("Content not found");
            }
            PreparePage();

            return View(content);
        }
        public ActionResult Update(MainSlider slider)
        {
            _mainSliderRepository.Update(slider);
            _mainSliderRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int contentId)
        {
            try
            {
                var content = _mainSliderRepository.GetById(contentId);
                if (content == null)
                {
                }
                _mainSliderRepository.Delete(contentId);
                _mainSliderRepository.Save();
            }
            catch (Exception ex)
            {
                //return Json(new ResultJson { Success = false, Message = "Content couldnt deleted!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
            return Index(1);
        }
    }
}