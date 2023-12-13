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
    public class ServiceController : Controller
    {
        private readonly ISecondCategoryService _secondService;
        private readonly IServiceService _serviceService;
        private readonly IFirstCategoryService _firstService;
        private readonly IMapper _mapper;
        public ServiceController(ISecondCategoryService secondService, IMapper mapper, IServiceService serviceService, IFirstCategoryService firstService)
        {
            _secondService = secondService;
            _serviceService = serviceService;
            _firstService = firstService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexService(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            ServiceIndexVM ServiceIndexVM = new ServiceIndexVM();
            var response = await _serviceService.ServiceByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ServiceIndexVM = JsonConvert.DeserializeObject<ServiceIndexVM>(Convert.ToString(response.Result));
            }
            return View(ServiceIndexVM);
        }

        //public async Task<IActionResult> IndexService()
        //{
        //    List<ServiceDTO> list = new();

        //    var response = await _serviceService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<ServiceDTO>>(Convert.ToString(response.Result));
        //    }
        //    return View(list);
        //}


        public async Task<IActionResult> CreateService()
        {
            ServiceCreateVM serviceVM = new();

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
        public async Task<IActionResult> CreateService(ServiceCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _serviceService.CreateAsync<APIResponse>(model.Service, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Created sucessfully.";
                    return RedirectToAction(nameof(IndexService));
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



        public async Task<IActionResult> UpdateService(int id)
        {
            ServiceUpdateVM serviceVM = new();
            var response = await _serviceService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ServiceDTO model = JsonConvert.DeserializeObject<ServiceDTO>(Convert.ToString(response.Result));
                serviceVM.Service = _mapper.Map<ServiceUpdateDTO>(model);
            }

      
            response = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
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
        public async Task<IActionResult> UpdateService(ServiceUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _serviceService.UpdateAsync<APIResponse>(model.Service, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Updated sucessfully.";
                    return RedirectToAction(nameof(IndexService));
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


        //public async Task<IActionResult> DeleteThirdCategory(int id)
        //{
        //    ThirdCategoryDeleteVM thirdCategoryVM = new();
        //    var response = await _thirdService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        ThirdCategoryDTO model = JsonConvert.DeserializeObject<ThirdCategoryDTO>(Convert.ToString(response.Result));
        //        thirdCategoryVM.ThirdCategory = model;
        //    }

        //   var  response2 = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    var response1 = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response2 != null && response2.IsSuccess && response1 != null && response1.IsSuccess)
        //    {
        //        thirdCategoryVM.SecondCategoryList = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>
        //            (Convert.ToString(response2.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.SecondCategoryName,
        //                Value = i.Id.ToString()
        //            });
        //        thirdCategoryVM.FirstCategoryList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>
        //            (Convert.ToString(response1.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.FirstCategoryName,
        //                Value = i.Id.ToString()
        //            });
        //        return View(thirdCategoryVM);
        //    }
        //     return NotFound();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteService(int id)

        {

            var response = await _serviceService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexService));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction(nameof(IndexService));
        }



    }
}
