using Kitaprazzi.Core.Helper;
using Kitaprazzi.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kitaprazzi.Web.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentRepository _contentRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly GenericHelper _genericHelper;


        public ContentController(IContentRepository contentRepository, IPublisherRepository publisherRepository, ICategoryRepository categoryRepositoy)
        {
            _contentRepository = contentRepository;
            _publisherRepository = publisherRepository;
            _categoryRepository = categoryRepositoy;
            _genericHelper = new GenericHelper(_contentRepository);
        }

        // GET: Content
        public ActionResult Book(int id)
        {
            var contentItem = _contentRepository.GetById(id);
            return View("~/Views/Content/BookDetail.cshtml", contentItem);
        }

        public ActionResult Publisher(int id)
        {
            var contentItem = _contentRepository.GetById(id);
            return View(contentItem);
        }

        public ActionResult Category(int id, int l = 0,int contentType = 0,  int publisherId = 0, int sortBy=0)
        {
            var categoryItem = _categoryRepository.GetById(id);
            var contentList = _genericHelper.GetContentsWithByCategory(categoryItem.ID, l, 50);
            ViewBag.FullContentList = contentList;
            if (contentType > 0)
            {
                contentList = contentList.Where(x => x.ContentTypeID == contentType).ToList();
            }
            if (publisherId > 0)
            {
                contentList = contentList.Where(x => x.PublisherID == publisherId).ToList();
            }
            if (sortBy == 0)
            {
                contentList = contentList.OrderBy(x=> x.KitaprazziPoint).ToList();
            }
            else
            {
                contentList = contentList.OrderByDescending(x => x.KitaprazziPoint).ToList();
            }
            
            ViewBag.ContentList = contentList;
            return View("~/Views/Content/CategoryDetail.cshtml", categoryItem);
        }
    }
}