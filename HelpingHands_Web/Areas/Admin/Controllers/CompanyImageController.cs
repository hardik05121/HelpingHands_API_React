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
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Security.Claims;

namespace HelpingHands_Web.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CompanyImageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly ICompanyImageService _companyImageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyImageController(ICompanyService companyService, IMapper mapper, ICompanyImageService companyImageService, IWebHostEnvironment webHostEnvironment)
        {
            _companyService = companyService;
            _mapper = mapper;
            _companyImageService = companyImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> IndexCompanyImage()
        {
            List<CompanyImageDTO> list = new();

            var response = await _companyImageService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CompanyImageDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCompanyImage(int companyId)
        {
            CompanyImageCreateVM companyImageCreateVM = new();
            {
                var response = await _companyService.GetAsync<APIResponse>(companyId, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null &&
                    response.IsSuccess)
                {
                    CompanyDTO model = JsonConvert.DeserializeObject<CompanyDTO>(Convert.ToString(response.Result));
                    companyImageCreateVM.Company = _mapper.Map<CompanyCreateDTO>(model);
                }

                var CompanyImagelist = await _companyImageService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
                if (CompanyImagelist != null && CompanyImagelist.IsSuccess)
                {
                    List<CompanyImageDTO> model1 = JsonConvert.DeserializeObject<List<CompanyImageDTO>>(Convert.ToString(CompanyImagelist.Result));
                    var imageList = _mapper.Map<List<CompanyImageCreateDTO>>(model1);
                    companyImageCreateVM.CompanyImagelist = imageList.Where(x => x.CompanyId == companyId).ToList();

				}
            };
            return View(companyImageCreateVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompanyImage(CompanyImageCreateVM companyImageVM, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
                {
                    foreach (IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string carPath = @"images\companies\company-" + companyImageVM.Company.Id;
                        string finalPath = Path.Combine(wwwRootPath, carPath);

                        if (!Directory.Exists(finalPath))
                            Directory.CreateDirectory(finalPath);

                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        CompanyImageCreateDTO companyImageDTO = new()
                        {
                            Image = @"\" + carPath + @"\" + fileName,
                            CompanyId = companyImageVM.Company.Id,
                        };

                        if (companyImageVM.CompanyImagelist == null)
                            companyImageVM.CompanyImagelist = new List<CompanyImageCreateDTO>();

                        companyImageVM.CompanyImagelist.Add(companyImageDTO);
                    }
                }

                var response = await _companyImageService.CreateAsync<APIResponse>(companyImageVM, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    //	return RedirectToAction(nameof(IndexCarXColor));
                    TempData["success"] = "Image Add  successfully";
                    return RedirectToAction("IndexCompany", "Company");
                    // var url = Url.Action("CreateCompanyImage", "Company", new { area = "Admin", companyId = companyImageVM.Company.Id });
                    // return  // Output the URL to the debug console
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var CompanyImagelist = await _companyImageService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (CompanyImagelist != null && CompanyImagelist.IsSuccess)
            {
                List<CompanyImageDTO> model1 = JsonConvert.DeserializeObject<List<CompanyImageDTO>>(Convert.ToString(CompanyImagelist.Result));
                companyImageVM.CompanyImagelist = _mapper.Map<List<CompanyImageCreateDTO>>(model1);
            }

            return View(companyImageVM);
        }

        public async Task<IActionResult> DeleteCompanyImage(int imageId, int companyId)
        {
            CompanyImageDTO companyImageDTO = new();

            var imageToBeDeleted = await _companyImageService.GetAsync<APIResponse>(imageId, HttpContext.Session.GetString(SD.SessionToken));
            if (imageToBeDeleted != null && imageToBeDeleted.IsSuccess)
            {
                companyImageDTO = JsonConvert.DeserializeObject<CompanyImageDTO>(Convert.ToString(imageToBeDeleted.Result));
            }

            if (companyImageDTO != null)
            {
                if (!string.IsNullOrEmpty(companyImageDTO.Image))
                {
                    var oldImagePath =
                                   Path.Combine(_webHostEnvironment.WebRootPath,
                                   companyImageDTO.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                var response = await _companyImageService.DeleteAsync<APIResponse>(companyImageDTO.Id, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Data Delated sucessfully.";
                    // return RedirectToAction(nameof(IndexCompanyXAmenity));
                    return RedirectToAction("IndexCompany", "Company");
                }
            }

            return View();
        }

        public async Task<IActionResult> SetCompanyImage(int imageId, int companyId)
        {   
            if (ModelState.IsValid)
            {
                var response = await _companyImageService.SetAsync<APIResponse>(imageId, companyId, HttpContext.Session.GetString(SD.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Set default image sucessfully.";
                    return RedirectToAction("IndexCompany", "Company");
                }
            }
            TempData["error"] = "Error encountered.";
            return RedirectToAction("CreateCompanyImage", "CompanyImage", new { companyId = companyId });
        }

    }
}
