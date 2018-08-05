using Kitaprazzi.Core.Helper;
using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zathura.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMainControlRepository _mainControlRepository;
        private readonly IContentRepository _contentRepository;
        private readonly GenericHelper _genericHelper;
        

        public HomeController(ICategoryRepository categoryRepository, IMainControlRepository mainControlRepository, IContentRepository contentRepository) {
            _categoryRepository = categoryRepository;
            _mainControlRepository = mainControlRepository;
            _contentRepository = contentRepository;
            _genericHelper = new GenericHelper(_contentRepository);
        }
        // GET: Home
        public ActionResult Index()
        {
            var mainControls = _mainControlRepository.GetMany(x=> x.Category.Status == (int)Status.Active).OrderBy(x=>x.Order).ToList();
            ViewBag.MainControls = mainControls;
            return View();
        }
        // GET: Category
        public ActionResult Category()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Navigation()
        {
            var categories = _categoryRepository.GetMany(x => x.Status == (int)Status.Active);
            ViewBag.Categories = categories.ToList();
            ViewBag.UserModel = Session[Kitaprazzi.Core.Helper.Session.User];
            return PartialView("~/Views/_Partial/_Header.cshtml");
        }

        [ChildActionOnly]
        public ActionResult BookList(MainControl control, string type = "category")
        {
            if (type == "popular")
            {
                var popularContentList = _genericHelper.GetMostPopularContents();
                ViewBag.ContentList = popularContentList;
                return PartialView("~/Views/Home/_Partial/_PopulerBookList.cshtml");

            }
            var contentList = _genericHelper.GetContentsWithByCategory(control.CategoryID);
            ViewBag.ContentList = contentList;
            return PartialView("~/Views/Home/_Partial/_BookList.cshtml", control);
        }
    }
}