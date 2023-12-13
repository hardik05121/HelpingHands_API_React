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
using System.Collections.Generic;
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CompanyXServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly ICompanyXServiceService _cxaService;
        public CompanyXServiceController(IServiceService serviceService, ICompanyService companyService, IMapper mapper, ICompanyXServiceService cxaService)
        {
            _serviceService = serviceService;
            _companyService = companyService;
            _mapper = mapper;
            _cxaService = cxaService;
        }

        public async Task<IActionResult> IndexCompanyXService()
        {
            List<CompanyXServiceDTO> list = new();

            var response = await _cxaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CompanyXServiceDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }


        public async Task<IActionResult> CreateCompanyXService(int companyId,int firstCategoryId)
        {
            CompanyXServiceVM companyXServiceVM = new();
            {
                var response = await _companyService.GetAsync<APIResponse>(companyId, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null &&
                    response.IsSuccess)
                {
                    CompanyDTO model = JsonConvert.DeserializeObject<CompanyDTO>(Convert.ToString(response.Result));
                    companyXServiceVM.Company = _mapper.Map<CompanyCreateDTO>(model);
                }

                var CompanyXAmenitylist = await _cxaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (CompanyXAmenitylist != null && CompanyXAmenitylist.IsSuccess)
                {

                    List<CompanyXServiceDTO> model1 = JsonConvert.DeserializeObject<List<CompanyXServiceDTO>>(Convert.ToString(CompanyXAmenitylist.Result));

					companyXServiceVM.CompanyXServicelist = _mapper.Map<List<CompanyXServiceCreateDTO>>(model1);
                }


                var AmenityList = await _serviceService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (AmenityList != null && AmenityList.IsSuccess)
                {

                    var model = JsonConvert.DeserializeObject<List<ServiceDTO>>(Convert.ToString(AmenityList.Result));
                    var model1 = model.Where(x => x.FirstCategoryId == firstCategoryId).ToList();

					companyXServiceVM.ServiceList = model1.Select(i => new ServiceDTO
                      {
                          ServiceName = i.ServiceName,
                          Id = i.Id,
                          IsActive = companyXServiceVM.CompanyXServicelist.Where(x => x.ServiceId == i.Id && x.CompanyId == companyId).Any()

                      }).ToList();



				}
            };
            return View(companyXServiceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompanyXService(CompanyXServiceVM companyXServiceVM)
        {
            if (ModelState.IsValid)
            {

                var response = await _cxaService.CreateAsync<APIResponse>(companyXServiceVM, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Created sucessfully.";
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

                List<CompanyXServiceDTO> model1 = JsonConvert.DeserializeObject<List<CompanyXServiceDTO>>(Convert.ToString(CompanyXAmenitylist.Result));
                companyXServiceVM.CompanyXServicelist = _mapper.Map<List<CompanyXServiceCreateDTO>>(model1);
            }


            var AmenityList = await _serviceService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (AmenityList != null && AmenityList.IsSuccess)
            {
                companyXServiceVM.ServiceList = JsonConvert.DeserializeObject<List<ServiceDTO>>
                  (Convert.ToString(AmenityList.Result)).Select(i => new ServiceDTO
                  {
                      ServiceName = i.ServiceName,
                      Id = i.Id,
                      IsActive = companyXServiceVM.CompanyXServicelist.Where(x => x.ServiceId == i.Id).Any()

                  }).ToList();

            }
            return View(companyXServiceVM);
        }



        //public async Task<IActionResult> UpdateCompanyXService(int id)
        //{
        //    CompanyXServiceUpdateVM companyXServiceVM = new();
        //    {
        //        var response = await _cxaService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
        //        if (response != null && response.IsSuccess)
        //        {
        //            CompanyXServiceDTO model = JsonConvert.DeserializeObject<CompanyXServiceDTO>(Convert.ToString(response.Result));
        //            companyXServiceVM.CompanyXService = _mapper.Map<CompanyXServiceUpdateDTO>(model);
        //        }


        //        response = await _companyService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //        if (response != null && response.IsSuccess)
        //        {
        //            companyXServiceVM.CompanyList = JsonConvert.DeserializeObject<List<CompanyDTO>>
        //                (Convert.ToString(response.Result)).Select(i => new SelectListItem
        //                {
        //                    Text = i.CompanyName,
        //                    Value = i.Id.ToString()
        //                });
        //        }
        //        var response1 = await _serviceService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

        //        if (response1 != null && response1.IsSuccess)
        //        {
        //            companyXServiceVM.ServiceList = JsonConvert.DeserializeObject<List<ServiceDTO>>
        //                (Convert.ToString(response1.Result)).Select(i => new ServiceDTO
        //                {
        //                    ServiceName = i.ServiceName,
        //                    Id = i.Id,
        //                    IsActive = false

        //                }).ToList();
        //        }
        //    };
        //    return View(companyXServiceVM);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> UpdateCompanyXService(CompanyXServiceUpdateVM companyXServiceVM)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var response = await _cxaService.UpdateAsync<APIResponse>(companyXServiceVM, HttpContext.Session.GetString(SD.SessionToken));
        //        if (response != null && response.IsSuccess)
        //        {
        //            TempData["success"] = "Data Updated sucessfully.";
        //            return RedirectToAction(nameof(IndexCompanyXService));
        //        }
        //        else
        //        {
        //            if (response.ErrorMessages.Count > 0)
        //            {
        //                ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
        //            }
        //        }
        //    }

        //    var resp = await _companyService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (resp != null && resp.IsSuccess)
        //    {
        //        companyXServiceVM.CompanyList = JsonConvert.DeserializeObject<List<CompanyDTO>>
        //            (Convert.ToString(resp.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.CompanyName,
        //                Value = i.Id.ToString()
        //            });
        //    }
        //    var res = await _serviceService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (res != null && res.IsSuccess)
        //    {
        //        companyXServiceVM.ServiceList = JsonConvert.DeserializeObject<List<ServiceDTO>>
        //            (Convert.ToString(res.Result)).Select(i => new ServiceDTO
        //            {
        //                ServiceName = i.ServiceName,
        //                Id = i.Id,
        //                IsActive = false
        //            }).ToList();
        //    }
        //    return View(companyXServiceVM);
        //}



        public async Task<IActionResult> DeleteCompanyXService(int id)

        {

            var response = await _cxaService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexCompanyXService));
            }

            return View();
        }



    }
}
