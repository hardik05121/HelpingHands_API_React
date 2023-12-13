using AutoMapper;
using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.Index;
using HelpingHands_Web.Models.VM;
using HelpingHands_Web.Service;
using HelpingHands_Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CityController : Controller
    {
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        public CityController(IStateService stateService, IMapper mapper, ICityService cityService, ICountryService countryService)
        {
            _stateService = stateService;
            _cityService = cityService;
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexCity(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            CityIndexVM cityIndexVM = new CityIndexVM();
            var response = await _cityService.CityByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                cityIndexVM = JsonConvert.DeserializeObject<CityIndexVM>(Convert.ToString(response.Result));
            }
            return View(cityIndexVM);
        }

        public async Task<IActionResult> CreateCity()
        {
            CityCreateVM cityCategoryVM = new();
            var response = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<StateDTO> stateDTOList = JsonConvert.DeserializeObject<List<StateDTO>>(
                            Convert.ToString(response.Result));
                stateDTOList = stateDTOList.OrderBy(i => i.StateName).ToList();
                cityCategoryVM.StateList = stateDTOList.Select(i => new SelectListItem
                {
                    Text = i.StateName,
                    Value = i.Id.ToString()
                });
            }
            var response1 = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response1 != null && response1.IsSuccess)
            {
                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(
                        Convert.ToString(response1.Result));
                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();

                cityCategoryVM.CountryList = countryDTOList.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                });
            }
            return View(cityCategoryVM);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCity(CityCreateVM model)
        {
            if (ModelState.IsValid)
            {
                //var claimsIdentity = (ClaimsIdentity)User.Identity;
                //var userId = claimsIdentity.FindSecond(ClaimTypes.NameIdentifier).Value;
                //string ApplicationUserId = userId;

                var response = await _cityService.CreateAsync<APIResponse>(model.City, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Created sucessfully.";
                    return RedirectToAction(nameof(IndexCity));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }
            }

            var resp = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                List<StateDTO> stateDTOList = JsonConvert.DeserializeObject<List<StateDTO>>(
                            Convert.ToString(resp.Result));
                stateDTOList = stateDTOList.OrderBy(i => i.StateName).ToList();
                model.StateList = stateDTOList.Select(i => new SelectListItem
                {
                    Text = i.StateName,
                    Value = i.Id.ToString()
                });
            }
            var res = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (res != null && res.IsSuccess)
            {
                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(
                        Convert.ToString(res.Result));
                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();

                model.CountryList = countryDTOList.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                });
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateCity(int id)
        {
            CityUpdateVM cityCategoryVM = new();
            var response = await _cityService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                CityDTO model = JsonConvert.DeserializeObject<CityDTO>(Convert.ToString(response.Result));
                cityCategoryVM.City = _mapper.Map<CityUpdateDTO>(model);
            }

            response = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<StateDTO> stateDTOList = JsonConvert.DeserializeObject<List<StateDTO>>(
                             Convert.ToString(response.Result));
                stateDTOList = stateDTOList.OrderBy(i => i.StateName).ToList();
                cityCategoryVM.StateList = stateDTOList.Select(i => new SelectListItem
                {
                    Text = i.StateName,
                    Value = i.Id.ToString()
                });
            }
            response = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(
                         Convert.ToString(response.Result));
                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();

                cityCategoryVM.CountryList = countryDTOList.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                });
            }
            return View(cityCategoryVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCity(CityUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _cityService.UpdateAsync<APIResponse>(model.City, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Updated sucessfully.";
                    return RedirectToAction(nameof(IndexCity));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }
            }

            var resp = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                List<StateDTO> stateDTOList = JsonConvert.DeserializeObject<List<StateDTO>>(
                             Convert.ToString(resp.Result));
                stateDTOList = stateDTOList.OrderBy(i => i.StateName).ToList();
                model.StateList = stateDTOList.Select(i => new SelectListItem
                {
                    Text = i.StateName,
                    Value = i.Id.ToString()
                }); ;
            }

            var res = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (res != null && res.IsSuccess)
            {
                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(
                         Convert.ToString(res.Result));
                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();

                model.CountryList = countryDTOList.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.Id.ToString()
                });
            }
            return View(model);
        }


        //public async Task<IActionResult> DeleteCity(int id)
        //{
        //    CityDeleteVM cityCategoryVM = new();
        //    var response = await _cityService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        CityDTO model = JsonConvert.DeserializeObject<CityDTO>(Convert.ToString(response.Result));
        //        cityCategoryVM.City = model;
        //    }

        //    var response2 = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    var response1 = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response2 != null && response2.IsSuccess && response1 != null && response1.IsSuccess)
        //    {
        //        cityCategoryVM.StateList = JsonConvert.DeserializeObject<List<StateDTO>>
        //            (Convert.ToString(response2.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.StateName,
        //                Value = i.Id.ToString()
        //            });
        //        cityCategoryVM.CountryList = JsonConvert.DeserializeObject<List<CountryDTO>>
        //            (Convert.ToString(response1.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.CountryName,
        //                Value = i.Id.ToString()
        //            });
        //        return View(cityCategoryVM);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var response = await _cityService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexCity));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction(nameof(IndexCity));
        }

        public async Task<IActionResult> GetStatesByCountry(int countryId)
        {
            List<StateDTO> list = new();

            var response = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                var Model = JsonConvert.DeserializeObject<List<StateDTO>>(Convert.ToString(response.Result));
                list = Model.Where(x => x.CountryId == countryId).OrderBy(i => i.StateName).ToList();
            }
            return Json(list);
        }

    }
}
