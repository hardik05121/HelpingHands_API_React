using AutoMapper;
using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.Index;
using HelpingHands_Web.Models.VM;
using HelpingHands_Web.Service;
using HelpingHands_Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ThirdCategoryController : Controller
    {
        private readonly ISecondCategoryService _secondService;
        private readonly IThirdCategoryService _thirdService;
        private readonly IFirstCategoryService _firstService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ThirdCategoryController(ISecondCategoryService secondService, IMapper mapper, IThirdCategoryService thirdService, IFirstCategoryService firstService, IWebHostEnvironment webHostEnvironment)
        {
            _secondService = secondService;
            _thirdService = thirdService;
            _firstService = firstService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> IndexThirdCategory(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            ThirdCategoryIndexVM ThirdCategoryIndexVM = new ThirdCategoryIndexVM();
            var response = await _thirdService.ThirdCategoryByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ThirdCategoryIndexVM = JsonConvert.DeserializeObject<ThirdCategoryIndexVM>(Convert.ToString(response.Result));
            }
            return View(ThirdCategoryIndexVM);
        }

        //public async Task<IActionResult> IndexThirdCategory()
        //{
        //    List<ThirdCategoryDTO> list = new();

        //    var response = await _thirdService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<ThirdCategoryDTO>>(Convert.ToString(response.Result));
        //    }
        //    return View(list);
        //}


        public async Task<IActionResult> CreateThirdCategory()
        {
            ThirdCategoryCreateVM thirdCategoryVM = new();
            var response = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<SecondCategoryDTO> SecondDTOList = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>
                    (Convert.ToString(response.Result));
                SecondDTOList = SecondDTOList.OrderBy(i => i.SecondCategoryName).ToList();
                thirdCategoryVM.SecondCategoryList = SecondDTOList.Select(i => new SelectListItem
                    {
                        Text = i.SecondCategoryName,
                        Value = i.Id.ToString()
                    });
            }


            var response1 = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response1 != null && response1.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response1.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                thirdCategoryVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }
            return View(thirdCategoryVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateThirdCategory(ThirdCategoryCreateVM model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {



                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string brandPath = Path.Combine(wwwRootPath, @"images\thirdcategory");

                    if (!string.IsNullOrEmpty(model.ThirdCategory.ThirdCategoryImage))
                    {
                        //delete the old image
                        var oldImagePath =
                        Path.Combine(wwwRootPath, model.ThirdCategory.ThirdCategoryImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(brandPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.ThirdCategory.ThirdCategoryImage = @"\images\thirdcategory\" + fileName;
                }





                //var claimsIdentity = (ClaimsIdentity)User.Identity;
                //var userId = claimsIdentity.FindSecond(ClaimTypes.NameIdentifier).Value;
                //string ApplicationUserId = userId;

                var response = await _thirdService.CreateAsync<APIResponse>(model.ThirdCategory, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Created sucessfully.";
                    return RedirectToAction(nameof(IndexThirdCategory));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }
            }

            var resp = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (resp != null && resp.IsSuccess)
            {
                List<SecondCategoryDTO> SecondDTOList = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>
                    (Convert.ToString(resp.Result));
                SecondDTOList = SecondDTOList.OrderBy(i => i.SecondCategoryName).ToList();
                model.SecondCategoryList = SecondDTOList.Select(i => new SelectListItem
                {
                    Text = i.SecondCategoryName,
                    Value = i.Id.ToString()
                });
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



        public async Task<IActionResult> UpdateThirdCategory(int id)
        {
            ThirdCategoryUpdateVM thirdCategoryVM = new();
            var response = await _thirdService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                ThirdCategoryDTO model = JsonConvert.DeserializeObject<ThirdCategoryDTO>(Convert.ToString(response.Result));
                thirdCategoryVM.ThirdCategory = _mapper.Map<ThirdCategoryUpdateDTO>(model);
            }

            response = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<SecondCategoryDTO> SecondDTOList = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>
                    (Convert.ToString(response.Result));
                SecondDTOList = SecondDTOList.OrderBy(i => i.SecondCategoryName).ToList();
                thirdCategoryVM.SecondCategoryList = SecondDTOList.Select(i => new SelectListItem
                {
                    Text = i.SecondCategoryName,
                    Value = i.Id.ToString()
                });
            }
            response = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                thirdCategoryVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }
            return View(thirdCategoryVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateThirdCategory(ThirdCategoryUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _thirdService.UpdateAsync<APIResponse>(model.ThirdCategory, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Updated sucessfully.";
                    return RedirectToAction(nameof(IndexThirdCategory));
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
                List<SecondCategoryDTO> SecondDTOList = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>
                    (Convert.ToString(resp.Result));
                SecondDTOList = SecondDTOList.OrderBy(i => i.SecondCategoryName).ToList();
                model.SecondCategoryList = SecondDTOList.Select(i => new SelectListItem
                {
                    Text = i.SecondCategoryName,
                    Value = i.Id.ToString()
                });
            }


            var res = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
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
        public async Task<IActionResult> DeleteThirdCategory(int id)

        {

            var response = await _thirdService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexThirdCategory));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction(nameof(IndexThirdCategory));
        }

        public async Task<IActionResult> GetSecondCategoryByFirstCategory(int firstCategoryId)
        {
            List<SecondCategoryDTO> list = new();

            var response = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                var Model = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>(Convert.ToString(response.Result));
                list = Model.Where(x => x.FirstCategoryId == firstCategoryId).OrderBy(i => i.SecondCategoryName).ToList();
            }
            return Json(list);
        }

    }
}
