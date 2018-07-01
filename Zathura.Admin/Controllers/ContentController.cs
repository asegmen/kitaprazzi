﻿using Kitaprazzi.Core.Helper;
using Kitaprazzi.Core.Infrastructure;
using Kitaprazzi.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.CustomFilter;
using Zathura.Admin.Helper;

namespace Zathura.Admin.Controllers
{
    public class ContentController : Controller
    {
        private const int PagingCount = 30;

        #region Repositories
        private readonly IContentRepository _contentRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMediaItemRepository _mediaItemRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;
        //private readonly IMemoryCacheManager _cacheManager;

        public ContentController(IContentRepository contentRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, IMediaItemRepository mediaItemRepository, ISystemSettingRepository systemSettingRepository)//, IMemoryCacheManager cacheManager
        {
            _contentRepository = contentRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _mediaItemRepository = mediaItemRepository;
            _systemSettingRepository = systemSettingRepository;
            //_cacheManager = cacheManager;
        }
        #endregion

        public ActionResult Index(int p = 1)
        {
            return View(_contentRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Add()
        {
            SetCategoryList();
            return View();
        }

        [HttpPost]
        [LoginFilter]
        public ActionResult Add(Content content, int CategoryID, HttpPostedFileBase spotImage, IEnumerable<HttpPostedFileBase> contentImages)
        {
            var userSession = HttpContext.Session[Kitaprazzi.Core.Helper.Session.User] as User;
            if (ModelState.IsValid) //check Content object attributes is ok?
            {
                //var user = _userRepository.GetById(Convert.ToInt32(userSession.ID));
                //content.UserID = user.ID;
                content.CategoryID = CategoryID;
                content.StartDate = DateTime.Now;

                _contentRepository.Insert(content);
                //_contentRepository.Save();

                //insert spot images
                if (spotImage != null)
                {
                    string fileName = Guid.NewGuid().ToString().Replace("-", "");
                    string extension = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string fullPath = "/external/content/" + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(fullPath));
                    var media = new MediaItem
                    {
                        Url = fullPath,
                        Content = content,
                        Status = (int)Status.Active,
                        CreatedDate = DateTime.Now,
                        Type = (int) ImageType.SpotImage
                    };

                    _mediaItemRepository.Insert(media);
                    _mediaItemRepository.Save();
                }
                //get inserted content id and save images if contentImages not null
                string mediaList = System.IO.Path.GetExtension(Request.Files[1].FileName);
                if (contentImages != null)
                {
                    foreach (var file in contentImages)
                    {
                        if (file?.ContentLength > 0)
                        {
                            string fileName = Guid.NewGuid().ToString().Replace("-", "");
                            string extension = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string fullPath = "/external/content/" + fileName + extension;
                            file.SaveAs(Server.MapPath(fullPath));

                            var media = new MediaItem
                            {
                                Url = fullPath,
                                Content = content,
                                Status = (int)Status.Active,
                                CreatedDate = DateTime.Now,
                                Type = (int)ImageType.MediaImage
                            };

                            _mediaItemRepository.Insert(media);
                            _mediaItemRepository.Save();
                        }
                    }
                }

            }
            SetCategoryList();
            return View();
        }


        #region Set Category List

        public void SetCategoryList(object category = null)
        {
            //if (!_cacheManager.IsSet("CategoriList_"))
            //{
            //    _cacheManager.Add("CategoriList_", _categoryRepository.GetMany(x => x.ParentCategoryId == 0).ToList(), 3600);
            //}

            var categoryList = _categoryRepository.GetMany(x => x.CategoryID == 0 && x.Status == (int)Status.Active);// _cacheManager.Get<List<Category>>("CategoriList_");
            ViewBag.CategoryList = categoryList;
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
        }
        public ActionResult Delete(int contentId) {
            try
            {
                var content = _contentRepository.GetById(contentId);
                if (content == null)
                {
                }
                _contentRepository.Delete(contentId);
                _contentRepository.Save();
                //return Json(new ResultJson { Success = true, Message = "Content deleted successfully..." });
            }
            catch (Exception ex)
            {
                //return Json(new ResultJson { Success = false, Message = "Content couldnt deleted!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
            return Index(1);
        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int id) {
            var content = _contentRepository.GetById(id);
            if (content == null)
            {
                throw new Exception("Content not found");
            }
            SetCategoryList();
            return View(content);
        }
        #endregion
    }
}