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

namespace HelpingHands_Web.Areas.Admin.Controllers{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class ApplicationRoleController : Controller
    {
        private readonly IApplicationRoleService _roleService;
        private readonly IMapper _mapper;
        public ApplicationRoleController(IApplicationRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexApplicationRole(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            ApplicationRoleIndexVM applicationRoleIndexVM = new ApplicationRoleIndexVM();
            var response = await _roleService.ApplicationRoleByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                applicationRoleIndexVM = JsonConvert.DeserializeObject<ApplicationRoleIndexVM>(Convert.ToString(response.Result));
            }
            return View(applicationRoleIndexVM);
        }

        public async Task<IActionResult> CreateApplicationRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateApplicationRole(ApplicationRoleDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _roleService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "ApplicationRole created successfully";
                    return RedirectToAction(nameof(IndexApplicationRole));
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
        [HttpGet]
        public async Task<IActionResult> UpdateApplicationRole(string ApplicationRoleId)
        {
            var response = await _roleService.GetAsync<APIResponse>(ApplicationRoleId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ApplicationRoleDTO model = JsonConvert.DeserializeObject<ApplicationRoleDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateApplicationRole(ApplicationRoleDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _roleService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "ApplicationRole updated successfully";
                    return RedirectToAction(nameof(IndexApplicationRole));
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

        public async Task<IActionResult> DeleteApplicationRole(string ApplicationRoleId)
        {

            var response = await _roleService.DeleteAsync<APIResponse>(ApplicationRoleId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "ApplicationRole deleted successfully";
                return RedirectToAction(nameof(IndexApplicationRole));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction("Index");
        }
    }}