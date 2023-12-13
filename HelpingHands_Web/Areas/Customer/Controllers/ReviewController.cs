

using AutoMapper;
using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.VM;
using HelpingHands_Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;
        private readonly IReviewXCommentService _reviewXCommentService;
        public ReviewController(ICompanyService companyService, IReviewService reviewService, IMapper mapper, IReviewXCommentService reviewXCommentService)
        {
            _companyService = companyService;
            _reviewService = reviewService;
            _mapper = mapper;
            _reviewXCommentService = reviewXCommentService;
        }

        public async Task<IActionResult> CreateReview(int companyId)
        {
            ReviewCreateVM reviewVM = new();

            var response = await _companyService.GetAsync<APIResponse>(companyId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                reviewVM.Company = JsonConvert.DeserializeObject<CompanyCreateDTO>(Convert.ToString(response.Result));

            }
           
            return View(reviewVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(ReviewCreateVM model)
        {
            ReviewCreateVM reviewVM = new();

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            string ApplicationUserId = userId;

            model.Review.ApplicationUserId = ApplicationUserId;

            var response = await _reviewService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("BrifDetail", "Home", new { companyId = model.Company.Id, area = "Customer" });
            }
            else
            {
                if (response.ErrorMessages.Count > 0)
                {
                    // ModelState.AddModelError("CustomError", response.ErrorMessages.FirstOrDefault());
                    TempData["error"] = response.ErrorMessages.FirstOrDefault();
                }
            }
            return View(reviewVM);
        }


       
        [Authorize]

        
        public async Task<IActionResult> ReviewXComment(int reviewId, int companyId)
        {
            HomeVM homeVM = new HomeVM();

            homeVM.ReviewXComment.ReviewID = reviewId;
            homeVM.Company.Id = companyId;


            var response = await _companyService.GetAsync<APIResponse>(companyId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                homeVM.Company = JsonConvert.DeserializeObject<CompanyDTO>(Convert.ToString(response.Result));
            }

            var response1 = await _reviewService.GetAsync<APIResponse>(reviewId, HttpContext.Session.GetString(SD.SessionToken));
            if (response1 != null && response1.IsSuccess)
            {
                homeVM.Review = JsonConvert.DeserializeObject<ReviewDTO>(Convert.ToString(response1.Result));
            }
            return View(homeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReviewXComment(HomeVM homeVM)
        {


            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            string ApplicationUserId = userId;

            HomeVM homeVM1 = new HomeVM();
            homeVM1.ReviewXComment.ReviewID = homeVM.ReviewXComment.ReviewID;
            homeVM1.ReviewXComment.Comment = homeVM.ReviewXComment.Comment;
            homeVM1.ReviewXComment.CompanyID = homeVM.Company.Id;
           homeVM1.ReviewXComment.ApplicationUserId = ApplicationUserId;

            var response = await _reviewXCommentService.CreateAsync<APIResponse>(homeVM1.ReviewXComment, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("BrifDetail", "Home", new { companyId = homeVM.Company.Id, area = "Customer" });

            }
            else
            {
                if (response.ErrorMessages.Count > 0)
                {
                    // ModelState.AddModelError("CustomError", response.ErrorMessages.FirstOrDefault());
                    TempData["error"] = response.ErrorMessages.FirstOrDefault();
                }
            }
            return View(homeVM);
        }
    }
}


