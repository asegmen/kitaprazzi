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
    public class PublisherController : Controller
    {
        #region Primitives
        private const int PagingCount = 30;
        #endregion

        #region Repositories
        private readonly IPublisherRepository _publisherRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        #endregion

        public PublisherController(IPublisherRepository categoryRepository, ISystemSettingRepository systemSettingRepository, ICountryRepository countryRepository, ICityRepository cityRepository)
        {
            _publisherRepository = categoryRepository;
            _systemSettingRepository = systemSettingRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }



        // GET: Publisher
        [HttpGet]
        [LoginFilter]
        public ActionResult Index(int p = 1)
        {
            return View(_publisherRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
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
        public JsonResult Add(Publisher publisher)
        {
            try
            {
                if (publisher == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Publisher couldn't found!" });

                }
                _publisherRepository.Insert(publisher);
                _publisherRepository.Save();
                return Json(new ResultJson() { Success = true, Message = "Publisher Added Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Publisher couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }

        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int id)
        {
            var publisher = _publisherRepository.GetById(id);
            if (publisher == null)
            {
                return Json(new ResultJson { Success = false, Message = "Publisher couldn't found!" });
            }
            PrepareForms();
            var counrtyList = _countryRepository.GetMany(x => x.City.ID == publisher.CityID);
            ViewBag.CountryList = counrtyList;
            return View(publisher);
        }

        [HttpPost]
        [LoginFilter]
        public JsonResult Update(Publisher publisher)
        {
            try
            {
                var publisherItem = _publisherRepository.GetById(publisher.ID);
                if (publisherItem == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Publisher couldn't found!" });
                }
                publisherItem.Name = publisher.Name;
                publisherItem.Phone = publisher.Phone;
                publisherItem.Status = publisher.Status;
                publisherItem.UpdateDate = DateTime.Now;
                publisherItem.Adress = publisher.Adress;
                publisherItem.CityID = publisher.CityID;
                publisherItem.CountryID = publisher.CountryID;

                _publisherRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Publisher updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Publisher couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
        }

        public void PrepareForms()
        {
            var cityList = _cityRepository.GetAll();
            ViewBag.CityList = cityList;
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
        }

        public JsonResult GetCountryByCityID(int cityId)
        {
            var counrtyList = _countryRepository.GetMany(x=> x.City.ID == cityId);
            return Json(counrtyList, JsonRequestBehavior.AllowGet);
        }

        [LoginFilter]
        public ActionResult Delete(int id)
        {
            try
            {
                var content = _publisherRepository.GetById(id);
                if (content != null)
                {
                    _publisherRepository.Delete(id);
                    _publisherRepository.Save();
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