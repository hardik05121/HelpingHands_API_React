

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
using Newtonsoft.Json;
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public async Task<IActionResult> IndexReview(string term = "", string orderBy = "", int currentPage = 1)
		{
			ViewData["CurrentFilter"] = term;
			//term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

			ReviewIndexVM ReviewIndexVM = new ReviewIndexVM();
			var response = await _reviewService.ReviewByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.IsSuccess)
			{
				ReviewIndexVM = JsonConvert.DeserializeObject<ReviewIndexVM>(Convert.ToString(response.Result));
			}
			return View(ReviewIndexVM);
		}


		public async Task<IActionResult> LikeCount(int reviewid)
		{
			ReviewUpdateVM reviewUpdateVM = new();

			var response = await _reviewService.GetAsync<APIResponse>(reviewid, HttpContext.Session.GetString(SD.SessionToken));

			if (response != null && response.IsSuccess)
			{
				var model = JsonConvert.DeserializeObject<ReviewDTO>(Convert.ToString(response.Result));
				reviewUpdateVM.Review = _mapper.Map<ReviewUpdateDTO>(model);
				reviewUpdateVM.Review.LikeCount += 1;
			}


			var response1 = await _reviewService.UpdateAsync<APIResponse>(reviewUpdateVM.Review, HttpContext.Session.GetString(SD.SessionToken));
			if (response1 != null && response1.IsSuccess)
			{
				TempData["success"] = " Like successfully";
				return RedirectToAction("BrifDetail", "Home", new { companyId = reviewUpdateVM.Review.CompanyID, area = "Customer" });
			}
			return NotFound();

		}

		public async Task<IActionResult> DisLikeCount(int reviewid)
		{
			ReviewUpdateVM reviewUpdateVM = new();

			var response = await _reviewService.GetAsync<APIResponse>(reviewid, HttpContext.Session.GetString(SD.SessionToken));

			if (response != null && response.IsSuccess)
			{
				var model = JsonConvert.DeserializeObject<ReviewDTO>(Convert.ToString(response.Result));
				reviewUpdateVM.Review = _mapper.Map<ReviewUpdateDTO>(model);
				reviewUpdateVM.Review.DisLikeCount += 1;

			}


			var response1 = await _reviewService.UpdateAsync<APIResponse>(reviewUpdateVM.Review, HttpContext.Session.GetString(SD.SessionToken));
			if (response1 != null && response1.IsSuccess)
			{
				TempData["success"] = " Dislike successfully";
				return RedirectToAction("BrifDetail", "Home", new { companyId = reviewUpdateVM.Review.CompanyID, area = "Customer" });

			}
			return NotFound();

		}


		public async Task<IActionResult> DeleteReview(int id)
        {

            var response = await _reviewService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexReview));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction(nameof(IndexReview));
        }

    }
}


