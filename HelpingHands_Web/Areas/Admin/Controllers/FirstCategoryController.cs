using AutoMapper;
using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.Index;
using HelpingHands_Web.Service;
using HelpingHands_Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HelpingHands_Web.Areas.Admin.Controllers{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class FirstCategoryController : Controller
    {
        private readonly IFirstCategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FirstCategoryController(IFirstCategoryService categoryService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _mapper = mapper;
              _webHostEnvironment = webHostEnvironment;

        }

        //public async Task<IActionResult> IndexFirstCategory(string term = "", string orderBy = "", int currentPage = 1)
        //{
        //    ViewData["CurrentFilter"] = term;
        //    //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

        //    FirstCategoryIndexVM FirstCategoryIndexVM = new FirstCategoryIndexVM();
        //    var response = await _categoryService.FirstCategoryByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        FirstCategoryIndexVM = JsonConvert.DeserializeObject<FirstCategoryIndexVM>(Convert.ToString(response.Result));
        //    }
        //    return View(FirstCategoryIndexVM);
        //}


        public async Task<IActionResult> IndexFirstCategory(string term = "", string orderBy = "asc", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;

            FirstCategoryIndexVM firstCategoryIndexVM = new FirstCategoryIndexVM();

            // Set the default sorting order to ascending
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "asc";
            }

            var response = await _categoryService.FirstCategoryByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));

            if (response != null && response.IsSuccess)
            {
                firstCategoryIndexVM = JsonConvert.DeserializeObject<FirstCategoryIndexVM>(Convert.ToString(response.Result));
            }

            return View(firstCategoryIndexVM);
        }



        //   [Authorize(Roles ="admin")]
        public async Task<IActionResult> CreateFirstCategory()
        {
            return View();
        }

        //[Authorize(Roles = "admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFirstCategory(FirstCategoryCreateDTO model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string brandPath = Path.Combine(wwwRootPath, @"images\firstcategory");

                    if (!string.IsNullOrEmpty(model.FirstCategoryImage))
                    {
                        //delete the old image
                        var oldImagePath =
                        Path.Combine(wwwRootPath, model.FirstCategoryImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(brandPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.FirstCategoryImage = @"\images\firstcategory\" + fileName;
                }

                var response = await _categoryService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction(nameof(IndexFirstCategory));
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


        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateFirstCategory(int FirstCategoryId)
        {
            var response = await _categoryService.GetAsync<APIResponse>(FirstCategoryId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                FirstCategoryDTO model = JsonConvert.DeserializeObject<FirstCategoryDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<FirstCategoryUpdateDTO>(model));
            }
            return NotFound();
        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFirstCategory(FirstCategoryUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Category updated successfully";
                var response = await _categoryService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexFirstCategory));
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

        // [Authorize(Roles = "admin")]
        //public async Task<IActionResult> DeleteFirstCategory(int FirstCategoryId)
        //{
        //    var response = await _categoryService.GetAsync<APIResponse>(FirstCategoryId, HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        FirstCategoryDTO model = JsonConvert.DeserializeObject<FirstCategoryDTO>(Convert.ToString(response.Result));
        //        return View(model);
        //    }
        //    return NotFound();
        //}

        ////[Authorize(Roles = "admin")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFirstCategory(int FirstCategoryId)
        {

            var response = await _categoryService.DeleteAsync<APIResponse>(FirstCategoryId, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction(nameof(IndexFirstCategory));
            }
            TempData["error"] = response.ErrorMessages.FirstOrDefault();
            return RedirectToAction("Index");
        }
    }}