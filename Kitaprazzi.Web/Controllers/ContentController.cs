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

        public ContentController(IContentRepository contentRepository, IPublisherRepository publisherRepository, ICategoryRepository categoryRepositoy)
        {
            _contentRepository = contentRepository;
            _publisherRepository = publisherRepository;
            _categoryRepository = categoryRepositoy;
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

        public ActionResult Category(int id)
        {
            var categoryItem = _categoryRepository.GetById(id);
            return View(categoryItem);
        }
    }
}