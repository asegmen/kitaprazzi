using Kitaprazzi.Core.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using Zathura.Admin.CustomFilter;
using Kitaprazzi.Core.Helper;
using Kitaprazzi.Data.Model;
using System.Web;
using System;
using System.IO;

namespace Zathura.Admin.Controllers
{
    public class MainControlController : Controller
    {
        private const int PagingCount = 30;

        #region Repositories
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMainControlRepository _mainControlRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;
        #endregion


        public MainControlController(ICategoryRepository categoryRepository, ISystemSettingRepository systemSettingRepository, IMainControlRepository mainControlRepository)//, IMemoryCacheManager cacheManager
        {
            _categoryRepository = categoryRepository;
            _systemSettingRepository = systemSettingRepository;
            _mainControlRepository = mainControlRepository;
            //_cacheManager = cacheManager;
        }

        //private readonly IMemoryCacheManager _cacheManager;
        // GET: MainControl
        public ActionResult Index(int p=1)
        {
            return View(_mainControlRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
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

            var categoryList = _categoryRepository.GetMany(x => x.Status == (int)Status.Active);// _cacheManager.Get<List<Category>>("CategoriList_");
            ViewBag.CategoryList = categoryList;
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
        }

        [HttpPost, ValidateInput(false)]
        [LoginFilter]
        public ActionResult Add(MainControl control)
        {
            var userSession = HttpContext.Session[Kitaprazzi.Core.Helper.Session.User] as User;
            if (ModelState.IsValid) //check Content object attributes is ok?
            {
                _mainControlRepository.Insert(control);
                _mainControlRepository.Save();
            }
            //PreparePage();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int id)
        {
            var content = _mainControlRepository.GetById(id);
            if (content == null)
            {
                throw new Exception("Content not found");
            }
            PreparePage();
            return View(content);
        }
        public ActionResult Update(MainControl control)
        {
            _mainControlRepository.Update(control);
            _mainControlRepository.Save();
            return RedirectToAction("Index");
        }
    }
}