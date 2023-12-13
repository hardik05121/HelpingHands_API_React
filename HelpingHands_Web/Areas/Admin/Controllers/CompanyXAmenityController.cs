using AutoMapper;
using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.VM;
using HelpingHands_Web.Service;
using HelpingHands_Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Drawing;
using System.Reflection;
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CompanyXAmenityController : Controller
    {
        private readonly IAmenityService _amenityService;
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly ICompanyXAmenityService _cxaService;
        public CompanyXAmenityController(IAmenityService amenityService, ICompanyService companyService, IMapper mapper, ICompanyXAmenityService cxaService)
        {
            _amenityService = amenityService;
            _companyService = companyService;
            _mapper = mapper;
            _cxaService = cxaService;
        }

        public async Task<IActionResult> IndexCompanyXAmenity()
        {
            List<CompanyXAmenityDTO> list = new();

            var response = await _cxaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CompanyXAmenityDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> CreateCompanyXAmenity(int companyId, int firstCategoryId)
        {
            CompanyXAmenityVM companyXAmenityVM = new();
            {
                var response = await _companyService.GetAsync<APIResponse>(companyId, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null &&
                    response.IsSuccess)
                {
                    CompanyDTO model = JsonConvert.DeserializeObject<CompanyDTO>(Convert.ToString(response.Result));
                    companyXAmenityVM.Company = _mapper.Map<CompanyCreateDTO>(model);
                }

                var CompanyXAmenitylist = await _cxaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (CompanyXAmenitylist != null && CompanyXAmenitylist.IsSuccess)
                {
                    var companyXAmenities = JsonConvert.DeserializeObject<List<CompanyXAmenityDTO>>(Convert.ToString(CompanyXAmenitylist.Result));
                    List<CompanyXAmenityDTO> model1 = companyXAmenities.Where(x => x.CompanyId == companyId).ToList();
                    companyXAmenityVM.CompanyXAmenitylist = _mapper.Map<List<CompanyXAmenityCreateDTO>>(model1);
                }

                var AmenityList = await _amenityService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (AmenityList != null && AmenityList.IsSuccess)
                {
					var model = JsonConvert.DeserializeObject<List<AmenityDTO>>(Convert.ToString(AmenityList.Result));
						
					var model1 = model.Where(x => x.FirstCategoryId == firstCategoryId).ToList();

					companyXAmenityVM.Amenitylist = model1.Select(i => new AmenityDTO
                      {
                          AmenityName = i.AmenityName,
                          Id = i.Id,
                          IsCheked = companyXAmenityVM.CompanyXAmenitylist.Where(x => x.AmenityId == i.Id  && x.CompanyId == companyId).Any()

                      }).ToList();
                }
            };
            return View(companyXAmenityVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompanyXAmenity(CompanyXAmenityVM companyXAmenityVM)
        {
            if (ModelState.IsValid)
            {

                var response = await _cxaService.CreateAsync<APIResponse>(companyXAmenityVM, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    //	return RedirectToAction(nameof(IndexCarXColor));
                    TempData["success"] = "Amenities Add  successfully";
                    return RedirectToAction("IndexCompany", "Company");
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }
            }

            var CompanyXAmenitylist = await _cxaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (CompanyXAmenitylist != null && CompanyXAmenitylist.IsSuccess)
            {

                List<CompanyXAmenityDTO> model1 = JsonConvert.DeserializeObject<List<CompanyXAmenityDTO>>(Convert.ToString(CompanyXAmenitylist.Result));
                companyXAmenityVM.CompanyXAmenitylist = _mapper.Map<List<CompanyXAmenityCreateDTO>>(model1);
            }

            return View(companyXAmenityVM);
        }

        public async Task<IActionResult> DeleteCompanyXAmenity(int id)
        {
            var response = await _cxaService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexCompanyXAmenity));
                //return View();
            }
            return View();
        }

    }
}
