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
using System.Reflection;
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SecondCategoryController : Controller
    {
        private readonly IFirstCategoryService _firstService;
        private readonly ISecondCategoryService _secondService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SecondCategoryController(IFirstCategoryService firstService, IMapper mapper, ISecondCategoryService secondService, IWebHostEnvironment webHostEnvironment)
        {
            _firstService = firstService;
            _secondService = secondService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> IndexSecondCategory(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            SecondCategoryIndexVM SecondCategoryIndexVM = new SecondCategoryIndexVM();
            var response = await _secondService.SecondCategoryByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                SecondCategoryIndexVM = JsonConvert.DeserializeObject<SecondCategoryIndexVM>(Convert.ToString(response.Result));
            }
            return View(SecondCategoryIndexVM);
        }

        public async Task<IActionResult> CreateSecondCategory()
        {
            SecondCategoryCreateVM secondCategoryVM = new();
            var response = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                secondCategoryVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                  {
                        Text = i.FirstCategoryName,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(secondCategoryVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSecondCategory(SecondCategoryCreateVM model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string secondcategoryPath = Path.Combine(wwwRootPath, @"images\secondcategory");

                    if (!string.IsNullOrEmpty(model.SecondCategory.SecondCategoryImage))
                    {
                        //delete the old image
                        var oldImagePath =
                        Path.Combine(wwwRootPath, model.SecondCategory.SecondCategoryImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(secondcategoryPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.SecondCategory.SecondCategoryImage = @"\images\secondcategory\" + fileName;
                }

                var response = await _secondService.CreateAsync<APIResponse>(model.SecondCategory, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Created sucessfully.";
                    return RedirectToAction(nameof(IndexSecondCategory));
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




        public async Task<IActionResult> UpdateSecondCategory(int id)
        {
            SecondCategoryUpdateVM secondCategoryVM = new();
            var response = await _secondService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                SecondCategoryDTO model = JsonConvert.DeserializeObject<SecondCategoryDTO>(Convert.ToString(response.Result));
                secondCategoryVM.SecondCategory = _mapper.Map<SecondCategoryUpdateDTO>(model);
            }

            response = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                secondCategoryVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            
            return View(secondCategoryVM);
            }
            return NotFound();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSecondCategory(SecondCategoryUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _secondService.UpdateAsync<APIResponse>(model.SecondCategory, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Updated sucessfully.";
                    return RedirectToAction(nameof(IndexSecondCategory));
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

        //public async Task<IActionResult> DeleteSecondCategory(int id)
        //{
        //    SecondCategoryDeleteVM secondCategoryVM = new();
        //    var response = await _secondService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        SecondCategoryDTO model = JsonConvert.DeserializeObject<SecondCategoryDTO>(Convert.ToString(response.Result));
        //        secondCategoryVM.SecondCategory = model;
        //    }

        //    response = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        secondCategoryVM.FirstCategoryList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>
        //            (Convert.ToString(response.Result)).Select(i => new SelectListItem
        //            {
        //                Text = i.FirstCategoryName,
        //                Value = i.Id.ToString()
        //            });
        //        return View(secondCategoryVM);
        //    }

        //    return NotFound();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSecondCategory(int id)
        {

            var response = await _secondService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Data Delated sucessfully.";
                return RedirectToAction(nameof(IndexSecondCategory));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction(nameof(IndexSecondCategory));
        }
    }
}
