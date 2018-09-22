using Kitaprazzi.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.CustomFilter;
using PagedList;
using Kitaprazzi.Data.Model;
using Zathura.Admin.Helper;

namespace Zathura.Admin.Controllers
{
    public class DealerController : Controller
    {
        #region Primitives
        private const int PagingCount = 30;
        #endregion

        #region Repositories
        private readonly IDealerRepository _dealerRepository;
        private readonly ISystemSettingRepository _systemSettingRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;

        #endregion

        public DealerController(IDealerRepository dealerRepository, ISystemSettingRepository systemSettingRepository, ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _dealerRepository = dealerRepository;
            _systemSettingRepository = systemSettingRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }
        // GET: Dealer
        [HttpGet]
        [LoginFilter]
        public ActionResult Index(int p = 1)
        {
            return View(_dealerRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(p, PagingCount));
        }
        public void PrepareForms()
        {
            var cityList = _cityRepository.GetAll();
            ViewBag.CityList = cityList;
            var systemSettingsList = _systemSettingRepository.GetMany(x => x.Key == "Status").ToList();
            ViewBag.StatusList = systemSettingsList;
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
        public JsonResult Add(Dealer publisher)
        {
            try
            {
                if (publisher == null)
                {
                    return Json(new ResultJson { Success = false, Message = "Dealer couldn't found!" });

                }
                _dealerRepository.Insert(publisher);
                _dealerRepository.Save();
                return Json(new ResultJson() { Success = true, Message = "Dealer Added Successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Dealer couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }

        }

        [LoginFilter]
        public ActionResult Delete(int id)
        {
            try
            {
                var content = _dealerRepository.GetById(id);
                if (content != null)
                {
                    _dealerRepository.Delete(id);
                    _dealerRepository.Save();
                }

            }
            catch (Exception ex)
            {
                //return Json(new ResultJson { Success = false, Message = "Content couldnt deleted!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
            return Index(1);
        }


        [HttpGet]
        [LoginFilter]
        public ActionResult Update(int id)
        {
            var publisher = _dealerRepository.GetById(id);
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
        public JsonResult Update(Dealer dealer)
        {
            try
            {
                //var publisherItem = _publisherRepository.GetById(publisher.ID);
                //if (publisherItem == null)
                //{
                //    return Json(new ResultJson { Success = false, Message = "Publisher couldn't found!" });
                //}
                //publisherItem.Name = publisher.Name;
                //publisherItem.Phone = publisher.Phone;
                //publisherItem.Status = publisher.Status;
                //publisherItem.UpdateDate = DateTime.Now;
                //publisherItem.Adress = publisher.Adress;
                //publisherItem.CityID = publisher.CityID;
                //publisherItem.CountryID = publisher.CountryID;

                //_publisherRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Publisher updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = false, Message = "Publisher couldnt added!!!", ExceptionMessage = ex.Message, ExStackTrace = ex.StackTrace });
            }
        }
    }
}