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
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CompanyXPaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly ICompanyXPaymentService _cxpService;
        public CompanyXPaymentController(IPaymentService paymentService, ICompanyService companyService, IMapper mapper, ICompanyXPaymentService cxpService)
        {
            _paymentService = paymentService;
            _companyService = companyService;
            _mapper = mapper;
            _cxpService = cxpService;
        }

        public async Task<IActionResult> IndexCompanyXPayment()
        {
            List<CompanyXPaymentDTO> list = new();

            var response = await _cxpService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CompanyXPaymentDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> CreateCompanyXPayment(int companyId)
        {
            CompanyXPaymentVM companyXPaymentVM = new();
            {
                var response = await _companyService.GetAsync<APIResponse>(companyId, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null &&
                    response.IsSuccess)
                {
                    CompanyDTO model = JsonConvert.DeserializeObject<CompanyDTO>(Convert.ToString(response.Result));
                    companyXPaymentVM.Company = _mapper.Map<CompanyCreateDTO>(model);
                }

                var CompanyXPaymentlist = await _cxpService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (CompanyXPaymentlist != null && CompanyXPaymentlist.IsSuccess)
                {

                    List<CompanyXPaymentDTO> model1 = JsonConvert.DeserializeObject<List<CompanyXPaymentDTO>>(Convert.ToString(CompanyXPaymentlist.Result));
                    companyXPaymentVM.CompanyXPaymentlist = _mapper.Map<List<CompanyXPaymentCreateDTO>>(model1);
                }

                var PaymentList = await _paymentService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (PaymentList != null && PaymentList.IsSuccess)
                {
                    companyXPaymentVM.Paymentlist = JsonConvert.DeserializeObject<List<PaymentDTO>>
                      (Convert.ToString(PaymentList.Result)).Select(i => new PaymentDTO
                      {
                          PaymentName = i.PaymentName,
                          Id = i.Id,
                          IsActive = companyXPaymentVM.CompanyXPaymentlist.Where(x => x.PaymentId == i.Id && x.CompanyId == companyId).Any()

                      }).ToList();

                }
            };
            return View(companyXPaymentVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateCompanyXPayment(CompanyXPaymentVM companyXPaymentVM)
        {
            if (ModelState.IsValid)
            {

                var response = await _cxpService.CreateAsync<APIResponse>(companyXPaymentVM, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    //	return RedirectToAction(nameof(IndexCarXColor));
                    TempData["success"] = "Payment Add  successfully";
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

            var CompanyXPaymentlist = await _cxpService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (CompanyXPaymentlist != null && CompanyXPaymentlist.IsSuccess)
            {

                List<CompanyXPaymentDTO> model1 = JsonConvert.DeserializeObject<List<CompanyXPaymentDTO>>(Convert.ToString(CompanyXPaymentlist.Result));
                companyXPaymentVM.CompanyXPaymentlist = _mapper.Map<List<CompanyXPaymentCreateDTO>>(model1);
            }

            var PaymentList = await _paymentService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (PaymentList != null && PaymentList.IsSuccess)
            {
                companyXPaymentVM.Paymentlist = JsonConvert.DeserializeObject<List<PaymentDTO>>
                  (Convert.ToString(PaymentList.Result)).Select(i => new PaymentDTO
                  {
                      PaymentName = i.PaymentName,
                      Id = i.Id,
                      IsActive = companyXPaymentVM.CompanyXPaymentlist.Where(x => x.PaymentId == i.Id).Any()


                  }).ToList();
            }

            return View(companyXPaymentVM);
        }

        public async Task<IActionResult> DeleteCompanyXPayment(int id)
        {
            var response = await _cxpService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexCompanyXPayment));
            }

            return View();
        }
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var response = await _cxpService.CreateAsync<APIResponse>(companyXPaymentVM, HttpContext.Session.GetString(SD.SessionToken));
        //        if (response != null && response.IsSuccess)
        //        {
        //            TempData["success"] = "Data Created sucessfully.";
        //            return RedirectToAction(nameof(IndexCompanyXPayment));
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
        //        companyXPaymentVM.CompanyList = JsonConvert.DeserializeObject<List<CompanyDTO>>
        //            (Convert.ToString(resp.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.CompanyName,
        //                Value = i.Id.ToString()
        //            });
        //    }
        //    var res = await _paymentService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (res != null && res.IsSuccess)
        //    {
        //        companyXPaymentVM.PaymentList = JsonConvert.DeserializeObject<List<PaymentDTO>>
        //            (Convert.ToString(res.Result)).Select(i => new PaymentDTO
        //            {
        //                PaymentName = i.PaymentName,
        //                Id = i.Id,
        //                IsCheked = false
        //            }).ToList();
        //    }
        //    return View(companyXPaymentVM);
        //}



        //public async Task<IActionResult> UpdateCompanyXPayment(int id)
        //{
        //    CompanyXPaymentUpdateVM companyXPaymentVM = new();
        //    {
        //        var response = await _cxpService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
        //        if (response != null && response.IsSuccess)
        //        {
        //            CompanyXPaymentDTO model = JsonConvert.DeserializeObject<CompanyXPaymentDTO>(Convert.ToString(response.Result));
        //            companyXPaymentVM.CompanyXPayment = _mapper.Map<CompanyXPaymentUpdateDTO>(model);
        //        }


        //        response = await _companyService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //        if (response != null && response.IsSuccess)
        //        {
        //            companyXPaymentVM.CompanyList = JsonConvert.DeserializeObject<List<CompanyDTO>>
        //                (Convert.ToString(response.Result)).Select(i => new SelectListItem
        //                {
        //                    Text = i.CompanyName,
        //                    Value = i.Id.ToString()
        //                });
        //        }
        //        var response1 = await _paymentService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //        if (response1 != null && response1.IsSuccess)
        //        {
        //            companyXPaymentVM.PaymentList = JsonConvert.DeserializeObject<List<PaymentDTO>>
        //                (Convert.ToString(response1.Result)).Select(i => new PaymentDTO
        //                {
        //                    PaymentName = i.PaymentName,
        //                    Id = i.Id,
        //                    IsCheked = false

        //                }).ToList();
        //        }
        //    };
        //    return View(companyXPaymentVM);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> UpdateCompanyXPayment(CompanyXPaymentUpdateVM companyXPaymentVM)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var response = await _cxpService.UpdateAsync<APIResponse>(companyXPaymentVM, HttpContext.Session.GetString(SD.SessionToken));
        //        if (response != null && response.IsSuccess)
        //        {
        //            TempData["success"] = "Data Updated sucessfully.";
        //            return RedirectToAction(nameof(IndexCompanyXPayment));
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
        //        companyXPaymentVM.CompanyList = JsonConvert.DeserializeObject<List<CompanyDTO>>
        //            (Convert.ToString(resp.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.CompanyName,
        //                Value = i.Id.ToString()
        //            });
        //    }
        //    var res = await _paymentService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (res != null && res.IsSuccess)
        //    {
        //        companyXPaymentVM.PaymentList = JsonConvert.DeserializeObject<List<PaymentDTO>>
        //            (Convert.ToString(res.Result)).Select(i => new PaymentDTO
        //            {
        //                PaymentName = i.PaymentName,
        //                Id = i.Id,
        //                IsCheked = false
        //            }).ToList();
        //    }
        //    return View(companyXPaymentVM);
        //}
    }
}
