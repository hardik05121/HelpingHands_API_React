using AutoMapper;using HelpingHands_Utility;using HelpingHands_Web.Models;using HelpingHands_Web.Models.DTO;using HelpingHands_Web.Models.Index;
using HelpingHands_Web.Models.VM;using HelpingHands_Web.Service;
using HelpingHands_Web.Service.IService;using Microsoft.AspNetCore.Authorization;using Microsoft.AspNetCore.Mvc;using Microsoft.AspNetCore.Mvc.Rendering;using Newtonsoft.Json;using System.Reflection;
using System.Security.Claims;namespace HelpingHands_Web.Areas.Admin.Controllers{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class StateController : Controller    {
        private readonly ICountryService _countryService;        private readonly IStateService _stateService;        private readonly IMapper _mapper;        public StateController(ICountryService countryService, IStateService stateService, IMapper mapper)
        {
            _countryService = countryService;
            _stateService = stateService;
            _mapper = mapper;
        }        public async Task<IActionResult> IndexState(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            StateIndexVM StateIndexVM = new StateIndexVM();
            var response = await _stateService.StateByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                StateIndexVM = JsonConvert.DeserializeObject<StateIndexVM>(Convert.ToString(response.Result));
            }
            return View(StateIndexVM);
        }






        //public async Task<IActionResult> IndexState()
        //{
        //    List<StateDTO> list = new();

        //    var response = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<StateDTO>>(Convert.ToString(response.Result));
        //    }
        //    return View(list);
        //}

        public async Task<IActionResult> CreateState()        {            StateCreateVM stateVM = new();            var response = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {
                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(
                         Convert.ToString(response.Result));                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();                stateVM.CountryList = countryDTOList.Select(i => new SelectListItem                {                    Text = i.CountryName,                    Value = i.Id.ToString()                });            }            return View(stateVM);        }




        [HttpPost]        [ValidateAntiForgeryToken]        public async Task<IActionResult> CreateState(StateCreateVM model)        {            if (ModelState.IsValid)            {
                //var claimsIdentity = (ClaimsIdentity)User.Identity;
                //var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                //string ApplicationUserId = userId;

                var response = await _stateService.CreateAsync<APIResponse>(model.State, HttpContext.Session.GetString(SD.SessionToken));                if (response != null && response.IsSuccess)                {                    TempData["success"] = "Data Created sucessfully.";                    return RedirectToAction(nameof(IndexState));                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }            }            var resp = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            if (resp != null && resp.IsSuccess)            {                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(
                         Convert.ToString(resp.Result));                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();                model.CountryList = countryDTOList.Select(i => new SelectListItem                {                    Text = i.CountryName,                    Value = i.Id.ToString()                });            }            return View(model);        }

        public async Task<IActionResult> UpdateState(int id)        {            StateUpdateVM stateVM = new();            var response = await _stateService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {                StateDTO model = JsonConvert.DeserializeObject<StateDTO>(Convert.ToString(response.Result));                stateVM.State = _mapper.Map<StateUpdateDTO>(model);            }            response = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {
                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(
                          Convert.ToString(response.Result));                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();                stateVM.CountryList = countryDTOList.Select(i => new SelectListItem                {                    Text = i.CountryName,                    Value = i.Id.ToString()                });

                return View(stateVM);            }            return NotFound();        }        [HttpPost]        [ValidateAntiForgeryToken]        public async Task<IActionResult> UpdateState(StateUpdateVM model)        {            if (ModelState.IsValid)            {                var response = await _stateService.UpdateAsync<APIResponse>(model.State, HttpContext.Session.GetString(SD.SessionToken));                if (response != null && response.IsSuccess)                {                    TempData["success"] = "Data Updated sucessfully.";                    return RedirectToAction(nameof(IndexState));                }                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();

                    }
                }            }            var resp = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            if (resp != null && resp.IsSuccess)            {
                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(
                           Convert.ToString(resp.Result));                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();                model.CountryList = countryDTOList.Select(i => new SelectListItem                {                    Text = i.CountryName,                    Value = i.Id.ToString()                });
            }            return View(model);        }

        //public async Task<IActionResult> DeleteState(int id)
        //{
        //    StateDeleteVM stateVM = new();
        //    var response = await _stateService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        StateDTO model = JsonConvert.DeserializeObject<StateDTO>(Convert.ToString(response.Result));
        //        stateVM.State = model;
        //    }

        //    response = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        stateVM.CountryList = JsonConvert.DeserializeObject<List<CountryDTO>>
        //            (Convert.ToString(response.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.CountryName,
        //                Value = i.Id.ToString()
        //            });
        //        return View(stateVM);
        //    }

        //    return NotFound();
        //}


        //////[HttpPost]
        //////[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteState(int id)        {            var response = await _stateService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {                TempData["success"] = "Data Delated sucessfully.";                return RedirectToAction(nameof(IndexState));            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction(nameof(IndexState));        }    }}