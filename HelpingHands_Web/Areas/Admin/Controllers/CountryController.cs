using AutoMapper;
using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.Index;
using HelpingHands_Web.Service;
using HelpingHands_Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Numerics;

namespace HelpingHands_Web.Areas.Admin.Controllers{
    [Area("Admin")]
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

		public List<CountryDTO> list;
		public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        //public async Task<IActionResult> IndexCountry()
        //{
        //    List<CountryDTO> list = new();

        //    var response = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<CountryDTO>>(Convert.ToString(response.Result));
        //    }
        //    return View(list);
        //}


        public async Task<IActionResult> IndexCountry()
        {
            List<CountryDTO> list = new();

            var response = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CountryDTO>>(Convert.ToString(response.Result));

                // Sort the list in ascending order based on a property (e.g., CountryName).
                list = list.OrderBy(country => country.CountryName).ToList();
            }

            return View(list);
        }







        public IActionResult CountryByLazyLoading()
		{

			return RedirectToAction("GetProjects");
		}

		public async Task<IActionResult> GetProjects(int pageNum)
		{
			//pageNum = pageNum ?? 0;
			//ViewBag.IsEndOfRecords = false;
			//if (Request.IsAjaxRequest())
			if (pageNum == null)
			{
				pageNum = 0;
			}

			ViewBag.IsEndOfRecords = false;
			if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
			{
				var response = await _countryService.CountryByLazyLoading<APIResponse>(pageNum, HttpContext.Session.GetString(SD.SessionToken));
				if (response != null && response.IsSuccess)
				{
					list = JsonConvert.DeserializeObject<List<CountryDTO>>(Convert.ToString(response.Result));
				}

				ViewBag.IsEndOfRecords = (list.Any());
				ViewBag.list = list;
				return PartialView("_Country", list);
				// return View(list);
			}
			else
			{

				var response = await _countryService.CountryByLazyLoading<APIResponse>(pageNum, HttpContext.Session.GetString(SD.SessionToken));
				if (response != null && response.IsSuccess)
				{
					list = JsonConvert.DeserializeObject<List<CountryDTO>>(Convert.ToString(response.Result));
				}

				ViewBag.TotalNumberProjects = list.Count;
				ViewBag.list = list;

				return View("CountryByLazyLoading", list);
			}
		}

		public async Task<IActionResult> CountryByPagination(string term = "", string orderBy = "", int currentPage = 1)
		{
			ViewData["CurrentFilter"] = term;
			term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

			CountryIndexVM countryIndexVM = new CountryIndexVM();
			var response = await _countryService.CountryByPagination<APIResponse>(term, orderBy, currentPage,HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.IsSuccess)
			{
				countryIndexVM = JsonConvert.DeserializeObject<CountryIndexVM>(Convert.ToString(response.Result));
			}
			return View(countryIndexVM);
		}

		public async Task<IActionResult> CreateCountry()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCountry(CountryCreateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _countryService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Country created successfully";
                    return RedirectToAction(nameof(IndexCountry));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }
            }
            return View(model);
        }


        //   [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCountry(int CountryId)
        {
            var response = await _countryService.GetAsync<APIResponse>(CountryId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                CountryDTO model = JsonConvert.DeserializeObject<CountryDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<CountryUpdateDTO>(model));
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCountry(CountryUpdateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _countryService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Country updated successfully";
                    return RedirectToAction(nameof(IndexCountry));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }
            }

            return View(model);
        }

        //  [Authorize(Roles = "admin")]
        //   public async Task<IActionResult> DeleteCountry(int CountryId)
        //   {
        //       var response = await _countryService.GetAsync<APIResponse>(CountryId, HttpContext.Session.GetString(SD.SessionToken));
        //       if (response != null && response.IsSuccess)
        //       {
        //           CountryDTO model = JsonConvert.DeserializeObject<CountryDTO>(Convert.ToString(response.Result));
        //           return View(model);
        //       }
        //       return NotFound();
        //   }
        ////   [Authorize(Roles = "admin")]
        //   [HttpPost]
        //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCountry(int CountryId)
        {

            var response = await _countryService.DeleteAsync<APIResponse>(CountryId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Country deleted successfully";
                return RedirectToAction(nameof(IndexCountry));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction("Index");
        }
    }}