using AutoMapper;

using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.Index;
using HelpingHands_Web.Models.VM;
using HelpingHands_Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //  [Authorize(Roles = "SuperAdmin,Admin")]
    [Authorize]
    public class EnquiryController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IEnquiryService _enquiryService;
        private readonly IMapper _mapper;
        public EnquiryController(ICompanyService companyService, IMapper mapper, IEnquiryService enquiryService)
        {
            _companyService = companyService;
            _enquiryService = enquiryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexEnquiry(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            EnquiryIndexVM EnquiryIndexVM = new EnquiryIndexVM();
            var response = await _enquiryService.EnquiryByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                EnquiryIndexVM = JsonConvert.DeserializeObject<EnquiryIndexVM>(Convert.ToString(response.Result));
            }
            return View(EnquiryIndexVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEnquiry(HomeVM model)
        {

            EnquiryDTO enquiryCreate = new EnquiryDTO();
            enquiryCreate.Title = model.Enquiry.Title;
            enquiryCreate.PhoneNumber = model.Enquiry.PhoneNumber;
            enquiryCreate.Description = model.Enquiry.Description;
            enquiryCreate.UserName = model.Enquiry.UserName;
            enquiryCreate.Email = model.Enquiry.Email;
            enquiryCreate.IsActive = model.Enquiry.IsActive;
            enquiryCreate.CompanyID = model.Company.Id;


            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            //string ApplicationUserId = userId;

            var response = await _enquiryService.CreateAsync<APIResponse>(enquiryCreate, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Enquiry Created sucessfully.";
                return RedirectToAction("BrifDetail", "Home", new { companyId = model.Company.Id, area = "customer" });
            }
            else
            {
                if (response.ErrorMessages.Count > 0)
                {
                    TempData["error"] = response.ErrorMessages.FirstOrDefault();
                }
            }
            return RedirectToAction("BrifDetail", "Home", new { companyId = model.Company.Id, area = "customer" });
        }

        public async Task<IActionResult> DeleteEnquiry(int id)
        {

            var response = await _enquiryService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexEnquiry));
            }
            return View();
        }
    }
}
