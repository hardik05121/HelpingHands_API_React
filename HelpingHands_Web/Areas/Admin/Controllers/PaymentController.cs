using AutoMapper;
using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.Index;
using HelpingHands_Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HelpingHands_Web.Areas.Admin.Controllers{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexPayment(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            PaymentIndexVM PaymentIndexVM = new PaymentIndexVM();
            var response = await _paymentService.PaymentByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                PaymentIndexVM = JsonConvert.DeserializeObject<PaymentIndexVM>(Convert.ToString(response.Result));
            }
            return View(PaymentIndexVM);
        }

        //   [Authorize(Roles ="admin")]
        public async Task<IActionResult> CreatePayment()
        {
            return View();
        }
        // [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePayment(PaymentCreateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _paymentService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Payment created successfully";
                    return RedirectToAction(nameof(IndexPayment));
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


        //   [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdatePayment(int PaymentId)
        {
            var response = await _paymentService.GetAsync<APIResponse>(PaymentId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                PaymentDTO model = JsonConvert.DeserializeObject<PaymentDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<PaymentUpdateDTO>(model));
            }
            return NotFound();
        }
        //   [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePayment(PaymentUpdateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _paymentService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Payment updated successfully";
                    return RedirectToAction(nameof(IndexPayment));
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

        //  [Authorize(Roles = "admin")]
        //   public async Task<IActionResult> DeletePayment(int PaymentId)
        //   {
        //       var response = await _paymentService.GetAsync<APIResponse>(PaymentId, HttpContext.Session.GetString(SD.SessionToken));
        //       if (response != null && response.IsSuccess)
        //       {
        //           PaymentDTO model = JsonConvert.DeserializeObject<PaymentDTO>(Convert.ToString(response.Result));
        //           return View(model);
        //       }
        //       return NotFound();
        //   }
        ////   [Authorize(Roles = "admin")]
        //   [HttpPost]
        //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePayment(int PaymentId)
        {

            var response = await _paymentService.DeleteAsync<APIResponse>(PaymentId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Payment deleted successfully";
                return RedirectToAction(nameof(IndexPayment));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction("Index");
        }
    }}