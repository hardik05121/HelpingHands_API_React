using AutoMapper;using HelpingHands_Utility;using HelpingHands_Web.Models;using HelpingHands_Web.Models.DTO;using HelpingHands_Web.Models.Index;
using HelpingHands_Web.Models.VM;using HelpingHands_Web.Service;using HelpingHands_Web.Service.IService;using Microsoft.AspNetCore.Authorization;using Microsoft.AspNetCore.Identity;using Microsoft.AspNetCore.Mvc;using Microsoft.AspNetCore.Mvc.Rendering;using Newtonsoft.Json;using System.Collections.Generic;namespace HelpingHands_Web.Areas.Admin.Controllers{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class ApplicationUserController : Controller    {        private readonly IApplicationUserService _userService;        private readonly IApplicationRoleService _roleService;        private readonly IApplicationUserRoleService _userRoleService;        private readonly IMapper _mapper;
        
        public ApplicationUserController(IApplicationUserService userService, IApplicationRoleService roleService,
            IMapper mapper, IApplicationUserRoleService userRoleService)        {            _userService = userService;            _mapper = mapper;
            _roleService = roleService;            _userRoleService = userRoleService;        }        public async Task<IActionResult> IndexApplicationUser(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            ApplicationUserIndexVM applicationUserIndexVM = new ApplicationUserIndexVM();
            var response = await _userService.ApplicationUserByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                applicationUserIndexVM = JsonConvert.DeserializeObject<ApplicationUserIndexVM>(Convert.ToString(response.Result));
            }
            return View(applicationUserIndexVM);
        }

        //public async Task<IActionResult> IndexApplicationUser()
        //{
        //    List<ApplicationUserDTO> list = new();

        //    var response = await _userService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<ApplicationUserDTO>>(Convert.ToString(response.Result));
        //    }
        //    return View(list);
        //}

        [HttpGet]        public async Task<IActionResult> MultipleRole(string ApplicationUserId)        {            UserVM userVM = new();
            var response = await _userService.GetAsync<APIResponse>(ApplicationUserId, HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {                userVM.ApplicationUser = JsonConvert.DeserializeObject<ApplicationUserDTO>(Convert.ToString(response.Result));            }

            var UserRoleList = await _userRoleService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (UserRoleList != null && UserRoleList.IsSuccess)
            {
                var list = JsonConvert.DeserializeObject<List<ApplicationUserRoleDTO>>(Convert.ToString(UserRoleList.Result));
                userVM.ApplicationUserRoleList = list.Where(x => x.UserId == ApplicationUserId).ToList();
            }
            var ApplicationRoleList = await _roleService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            if (ApplicationRoleList != null && ApplicationRoleList.IsSuccess)            {
                userVM.ApplicationRoleList = JsonConvert.DeserializeObject<List<ApplicationRoleDTO>>
                        (Convert.ToString(ApplicationRoleList.Result)).Select(i => new ApplicationRoleDTO
                        {
                            Name = i.Name,
                            Id = i.Id,
                            IsChecked = userVM.ApplicationUserRoleList.Where(x => x.RoleId == i.Id && x.UserId == ApplicationUserId).Any()
                        }).ToList();
            }
            return View(userVM);        }


        [HttpPost]        [ValidateAntiForgeryToken]        public async Task<IActionResult> MultipleRole(UserVM updateUser)        {
                        if (ModelState.IsValid)            {                var response = await _userService.UpdateAsync<APIResponse>(updateUser, HttpContext.Session.GetString(SD.SessionToken));                if (response != null && response.IsSuccess)                {                    TempData["success"] = "UserRoles updated successfully";                    return RedirectToAction(nameof(IndexApplicationUser));                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }            }

            var UserRoleList = await _userRoleService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (UserRoleList != null && UserRoleList.IsSuccess)
            {
                updateUser.ApplicationUserRoleList = JsonConvert.DeserializeObject<List<ApplicationUserRoleDTO>>(Convert.ToString(UserRoleList.Result));
            }

            return View(updateUser);        }    }}