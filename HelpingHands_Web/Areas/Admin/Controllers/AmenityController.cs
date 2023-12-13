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
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class AmenityController : Controller
    {

        private readonly IAmenityService _amenityService;
        private readonly IFirstCategoryService _firstService;
        private readonly IMapper _mapper;
        public AmenityController(IMapper mapper, IAmenityService amenityService, IFirstCategoryService firstService)
        {
            _amenityService = amenityService;
            _firstService = firstService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexAmenity(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            AmenityIndexVM amenityIndexVM = new AmenityIndexVM();
            var response = await _amenityService.AmenityByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                amenityIndexVM = JsonConvert.DeserializeObject<AmenityIndexVM>(Convert.ToString(response.Result));
            }
            return View(amenityIndexVM);
        }

        //public async Task<IActionResult> IndexAmenity()
        //{
        //    List<AmenityDTO> list = new();

        //    var response = await _amenityService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<AmenityDTO>>(Convert.ToString(response.Result));
        //    }
        //    return View(list);
        //}


        public async Task<IActionResult> CreateAmenity()
        {
            AmenityCreateVM serviceVM = new();

            var response = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                serviceVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }
            return View(serviceVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAmenity(AmenityCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _amenityService.CreateAsync<APIResponse>(model.Amenity, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Created sucessfully.";
                    return RedirectToAction(nameof(IndexAmenity));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }
            }

            var res = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (res != null && res.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(res.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                model.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }
            return View(model);
        }



        public async Task<IActionResult> UpdateAmenity(int id)
        {
            AmenityUpdateVM amenityVM = new();
            var response = await _amenityService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                AmenityDTO model = JsonConvert.DeserializeObject<AmenityDTO>(Convert.ToString(response.Result));
                amenityVM.Amenity = _mapper.Map<AmenityUpdateDTO>(model);
            }

        
            response = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                amenityVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }
            return View(amenityVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAmenity(AmenityUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _amenityService.UpdateAsync<APIResponse>(model.Amenity, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Updated sucessfully.";
                    return RedirectToAction(nameof(IndexAmenity));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }
            }

            var resp = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(resp.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                model.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteAmenity(int AmenityId)

        {

            var response = await _amenityService.DeleteAsync<APIResponse>(AmenityId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexAmenity));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction(nameof(IndexAmenity));
        }
    }
}
