using AutoMapper;using HelpingHands_Utility;using HelpingHands_Web.Models;using HelpingHands_Web.Models.DTO;using HelpingHands_Web.Models.Index;
using HelpingHands_Web.Models.VM;using HelpingHands_Web.Service;using HelpingHands_Web.Service.IService;using Microsoft.AspNetCore.Authorization;using Microsoft.AspNetCore.Mvc;using Microsoft.AspNetCore.Mvc.Rendering;using Newtonsoft.Json;using System.Reflection;
using System.Security.Claims;namespace HelpingHands_Web.Areas.Admin.Controllers{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CompanyController : Controller    {        private readonly ISecondCategoryService _secondService;        private readonly ICompanyService _companyService;        private readonly IFirstCategoryService _firstService;        private readonly IThirdCategoryService _thirdService;        private readonly ICountryService _countryService;        private readonly IStateService _stateService;        private readonly ICityService _cityService;        private readonly IMapper _mapper;        public CompanyController(ISecondCategoryService secondService, IMapper mapper,            ICompanyService companyService, IFirstCategoryService firstService, IThirdCategoryService thirdService,            ICountryService countryService, IStateService stateService, ICityService cityService)        {            _secondService = secondService;            _companyService = companyService;            _firstService = firstService;            _thirdService = thirdService;            _cityService = cityService;            _stateService = stateService;            _countryService = countryService;            _mapper = mapper;        }        public async Task<IActionResult> IndexCompany(string term = "", string orderBy = "", int currentPage = 1)
        {
            ViewData["CurrentFilter"] = term;
            //term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            CompanyIndexVM companyIndexVM = new CompanyIndexVM();
            var response = await _companyService.CompanyByPagination<APIResponse>(term, orderBy, currentPage, HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
            {
                companyIndexVM = JsonConvert.DeserializeObject<CompanyIndexVM>(Convert.ToString(response.Result));
            }
            return View(companyIndexVM);
        }
        // public async Task<IActionResult> IndexCompany()
        //{
        //    List<CompanyDTO> list = new();

        //    var response = await _companyService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<CompanyDTO>>(Convert.ToString(response.Result));
        //    }
        //    return View(list);
        //}


        public async Task<IActionResult> CreateCompany()        {            CompanyCreateVM companyCategoryVM = new();            var response1 = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response2 = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response3 = await _thirdService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response4 = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response5 = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response6 = await _cityService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if (response1 != null && response1.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response1.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                companyCategoryVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }            if (response2 != null && response2.IsSuccess)
            {
                List<SecondCategoryDTO> SecondDTOList = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>
                    (Convert.ToString(response2.Result));
                SecondDTOList = SecondDTOList.OrderBy(i => i.SecondCategoryName).ToList();
                companyCategoryVM.SecondCategoryList = SecondDTOList.Select(i => new SelectListItem
                {
                    Text = i.SecondCategoryName,
                    Value = i.Id.ToString()
                });
            }            if (response3 != null && response3.IsSuccess)            {                List<ThirdCategoryDTO> ThirdCategoryList = JsonConvert.DeserializeObject<List<ThirdCategoryDTO>>                    (Convert.ToString(response3.Result));                ThirdCategoryList= ThirdCategoryList.OrderBy(i => i.ThirdCategoryName).ToList();                companyCategoryVM.ThirdCategoryList = ThirdCategoryList.Select(i => new SelectListItem                    {                        Text = i.ThirdCategoryName,                        Value = i.Id.ToString()                    });            }
            if (response4 != null && response4.IsSuccess)            {                               List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(                           Convert.ToString(response4.Result));                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();                companyCategoryVM.CountryList = countryDTOList.Select(i => new SelectListItem                {                    Text = i.CountryName,                    Value = i.Id.ToString()                });            }            if (response5 != null && response5.IsSuccess)            {                List<StateDTO> stateDTOList = JsonConvert.DeserializeObject<List<StateDTO>>(                           Convert.ToString(response5.Result));                stateDTOList = stateDTOList.OrderBy(i => i.StateName).ToList();                companyCategoryVM.StateList = stateDTOList.Select(i => new SelectListItem
                {
                    Text = i.StateName,
                    Value = i.Id.ToString()
                });            }            if (response6 != null && response6.IsSuccess)            {                List<CityDTO> cityDTOList = JsonConvert.DeserializeObject<List<CityDTO>>(                         Convert.ToString(response6.Result));                cityDTOList = cityDTOList.OrderBy(i => i.CityName).ToList();                companyCategoryVM.CityList = cityDTOList.Select(i => new SelectListItem
                {
                    Text = i.CityName,
                    Value = i.Id.ToString()
                });            }            return View(companyCategoryVM);        }        [HttpPost]        [ValidateAntiForgeryToken]        public async Task<IActionResult> CreateCompany(CompanyCreateVM companyCategoryVM)        {            if (ModelState.IsValid)            {
                //var claimsIdentity = (ClaimsIdentity)User.Identity;
                //var userId = claimsIdentity.FindSecond(ClaimTypes.NameIdentifier).Value;
                //string ApplicationUserId = userId;

                var response = await _companyService.CreateAsync<APIResponse>(companyCategoryVM.Company, HttpContext.Session.GetString(SD.SessionToken));                if (response != null && response.IsSuccess)                {                    TempData["success"] = "Data Created sucessfully.";                    return RedirectToAction(nameof(IndexCompany));                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }            }

            var response1 = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response2 = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response3 = await _thirdService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response4 = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response5 = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response6 = await _cityService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if (response1 != null && response1.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response1.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                companyCategoryVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }            if (response2 != null && response2.IsSuccess)
            {
                List<SecondCategoryDTO> SecondDTOList = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>
                    (Convert.ToString(response2.Result));
                SecondDTOList = SecondDTOList.OrderBy(i => i.SecondCategoryName).ToList();
                companyCategoryVM.SecondCategoryList = SecondDTOList.Select(i => new SelectListItem
                {
                    Text = i.SecondCategoryName,
                    Value = i.Id.ToString()
                });
            }            if (response3 != null && response3.IsSuccess)            {                List<ThirdCategoryDTO> ThirdCategoryList = JsonConvert.DeserializeObject<List<ThirdCategoryDTO>>                    (Convert.ToString(response3.Result));                ThirdCategoryList = ThirdCategoryList.OrderBy(i => i.ThirdCategoryName).ToList();                companyCategoryVM.ThirdCategoryList = ThirdCategoryList.Select(i => new SelectListItem
                {
                    Text = i.ThirdCategoryName,
                    Value = i.Id.ToString()
                });            }
            if (response4 != null && response4.IsSuccess)            {

                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(                           Convert.ToString(response4.Result));                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();                companyCategoryVM.CountryList = countryDTOList.Select(i => new SelectListItem                {                    Text = i.CountryName,                    Value = i.Id.ToString()                });            }            if (response5 != null && response5.IsSuccess)            {                List<StateDTO> stateDTOList = JsonConvert.DeserializeObject<List<StateDTO>>(                           Convert.ToString(response5.Result));                stateDTOList = stateDTOList.OrderBy(i => i.StateName).ToList();                companyCategoryVM.StateList = stateDTOList.Select(i => new SelectListItem
                {
                    Text = i.StateName,
                    Value = i.Id.ToString()
                });            }            if (response6 != null && response6.IsSuccess)            {                List<CityDTO> cityDTOList = JsonConvert.DeserializeObject<List<CityDTO>>(                         Convert.ToString(response6.Result));                cityDTOList = cityDTOList.OrderBy(i => i.CityName).ToList();                companyCategoryVM.CityList = cityDTOList.Select(i => new SelectListItem
                {
                    Text = i.CityName,
                    Value = i.Id.ToString()
                });            }            return View(companyCategoryVM);        }        public async Task<IActionResult> UpdateCompany(int id)        {            CompanyUpdateVM companyCategoryVM = new();            var response = await _companyService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {                companyCategoryVM.Company = JsonConvert.DeserializeObject<CompanyDTO>(Convert.ToString(response.Result));                             }

            var response1 = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response2 = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response3 = await _thirdService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response4 = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response5 = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response6 = await _cityService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if (response1 != null && response1.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response1.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                companyCategoryVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }            if (response2 != null && response2.IsSuccess)
            {
                List<SecondCategoryDTO> SecondDTOList = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>
                    (Convert.ToString(response2.Result));
                SecondDTOList = SecondDTOList.OrderBy(i => i.SecondCategoryName).ToList();
                companyCategoryVM.SecondCategoryList = SecondDTOList.Select(i => new SelectListItem
                {
                    Text = i.SecondCategoryName,
                    Value = i.Id.ToString()
                });
            }            if (response3 != null && response3.IsSuccess)            {                List<ThirdCategoryDTO> ThirdCategoryList = JsonConvert.DeserializeObject<List<ThirdCategoryDTO>>                    (Convert.ToString(response3.Result));                ThirdCategoryList = ThirdCategoryList.OrderBy(i => i.ThirdCategoryName).ToList();                companyCategoryVM.ThirdCategoryList = ThirdCategoryList.Select(i => new SelectListItem
                {
                    Text = i.ThirdCategoryName,
                    Value = i.Id.ToString()
                });            }
            if (response4 != null && response4.IsSuccess)            {

                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(                           Convert.ToString(response4.Result));                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();                companyCategoryVM.CountryList = countryDTOList.Select(i => new SelectListItem                {                    Text = i.CountryName,                    Value = i.Id.ToString()                });            }            if (response5 != null && response5.IsSuccess)            {                List<StateDTO> stateDTOList = JsonConvert.DeserializeObject<List<StateDTO>>(                           Convert.ToString(response5.Result));                stateDTOList = stateDTOList.OrderBy(i => i.StateName).ToList();                companyCategoryVM.StateList = stateDTOList.Select(i => new SelectListItem
                {
                    Text = i.StateName,
                    Value = i.Id.ToString()
                });            }            if (response6 != null && response6.IsSuccess)            {                List<CityDTO> cityDTOList = JsonConvert.DeserializeObject<List<CityDTO>>(                         Convert.ToString(response6.Result));                cityDTOList = cityDTOList.OrderBy(i => i.CityName).ToList();                companyCategoryVM.CityList = cityDTOList.Select(i => new SelectListItem
                {
                    Text = i.CityName,
                    Value = i.Id.ToString()
                });            }            return View(companyCategoryVM);        }        [HttpPost]        [ValidateAntiForgeryToken]        public async Task<IActionResult> UpdateCompany(CompanyUpdateVM companyCategoryVM)        {            if (ModelState.IsValid)            {                var response = await _companyService.UpdateAsync<APIResponse>(companyCategoryVM.Company, HttpContext.Session.GetString(SD.SessionToken));                if (response != null && response.IsSuccess)                {                    TempData["success"] = "Data Updated sucessfully.";                    return RedirectToAction(nameof(IndexCompany));                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = response.ErrorMessages.FirstOrDefault();
                    }
                }            }


            var response1 = await _firstService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response2 = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response3 = await _thirdService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response4 = await _countryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response5 = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            var response6 = await _cityService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

            if (response1 != null && response1.IsSuccess)
            {
                List<FirstCategoryDTO> firstDTOList = JsonConvert.DeserializeObject<List<FirstCategoryDTO>>(
                           Convert.ToString(response1.Result));
                firstDTOList = firstDTOList.OrderBy(i => i.FirstCategoryName).ToList();
                companyCategoryVM.FirstCategoryList = firstDTOList.Select(i => new SelectListItem
                {
                    Text = i.FirstCategoryName,
                    Value = i.Id.ToString()
                }); ;
            }            if (response2 != null && response2.IsSuccess)
            {
                List<SecondCategoryDTO> SecondDTOList = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>
                    (Convert.ToString(response2.Result));
                SecondDTOList = SecondDTOList.OrderBy(i => i.SecondCategoryName).ToList();
                companyCategoryVM.SecondCategoryList = SecondDTOList.Select(i => new SelectListItem
                {
                    Text = i.SecondCategoryName,
                    Value = i.Id.ToString()
                });
            }            if (response3 != null && response3.IsSuccess)            {                List<ThirdCategoryDTO> ThirdCategoryList = JsonConvert.DeserializeObject<List<ThirdCategoryDTO>>                    (Convert.ToString(response3.Result));                ThirdCategoryList = ThirdCategoryList.OrderBy(i => i.ThirdCategoryName).ToList();                companyCategoryVM.ThirdCategoryList = ThirdCategoryList.Select(i => new SelectListItem
                {
                    Text = i.ThirdCategoryName,
                    Value = i.Id.ToString()
                });            }
            if (response4 != null && response4.IsSuccess)            {

                List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(                           Convert.ToString(response4.Result));                countryDTOList = countryDTOList.OrderBy(i => i.CountryName).ToList();                companyCategoryVM.CountryList = countryDTOList.Select(i => new SelectListItem                {                    Text = i.CountryName,                    Value = i.Id.ToString()                });            }            if (response5 != null && response5.IsSuccess)            {                List<StateDTO> stateDTOList = JsonConvert.DeserializeObject<List<StateDTO>>(                           Convert.ToString(response5.Result));                stateDTOList = stateDTOList.OrderBy(i => i.StateName).ToList();                companyCategoryVM.StateList = stateDTOList.Select(i => new SelectListItem
                {
                    Text = i.StateName,
                    Value = i.Id.ToString()
                });            }            if (response6 != null && response6.IsSuccess)            {                List<CityDTO> cityDTOList = JsonConvert.DeserializeObject<List<CityDTO>>(                         Convert.ToString(response6.Result));                cityDTOList = cityDTOList.OrderBy(i => i.CityName).ToList();                companyCategoryVM.CityList = cityDTOList.Select(i => new SelectListItem
                {
                    Text = i.CityName,
                    Value = i.Id.ToString()
                });            }            return View(companyCategoryVM);        }        public async Task<IActionResult> DeleteCompany(int id)        {            var response = await _companyService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {                TempData["success"] = "Data Delated sucessfully.";                return RedirectToAction(nameof(IndexCompany));            }            else
            {
                TempData["error"] = "Data Already used Can not be Delated sucessfully.";
            }            return RedirectToAction(nameof(IndexCompany));        }

        #region Contry, state, city, firstcategory , second category and third category dropdown list        public async Task<IActionResult> GetStatesByCountry(int countryId)        {            List<StateDTO> list = new();            var response = await _stateService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {
                var Model = JsonConvert.DeserializeObject<List<StateDTO>>(Convert.ToString(response.Result));                list = Model.Where(x => x.CountryId == countryId).OrderBy(i => i.StateName).ToList();            }            return Json(list);        }        public async Task<IActionResult> GetCitiesByState(int stateId)        {            List<CityDTO> list = new();            var response = await _cityService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {                var Model = JsonConvert.DeserializeObject<List<CityDTO>>(Convert.ToString(response.Result));                list = Model.Where(x => x.StateId == stateId).OrderBy(i => i.CityName).ToList();            }            return Json(list);        }        public async Task<IActionResult> GetSecondCategoryByFirstCategory(int firstCategoryId)        {            List<SecondCategoryDTO> list = new();            var response = await _secondService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {                var Model = JsonConvert.DeserializeObject<List<SecondCategoryDTO>>(Convert.ToString(response.Result));                list = Model.Where(x => x.FirstCategoryId == firstCategoryId).OrderBy(i => i.SecondCategoryName).ToList();            }            return Json(list);        }        public async Task<IActionResult> GetThirdCategoryBySecondCategory(int secondCategoryId)        {            List<ThirdCategoryDTO> list = new();            var response = await _thirdService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));            if (response != null && response.IsSuccess)            {                var Model = JsonConvert.DeserializeObject<List<ThirdCategoryDTO>>(Convert.ToString(response.Result));                list = Model.Where(x => x.SecondCategoryId == secondCategoryId).OrderBy(i => i.ThirdCategoryName).ToList();            }            return Json(list);        }
        #endregion    }}


// this method are used when company can be delete and all the company image are delete in the data base to pperticular company.

//var productToBeDeleted = await _companyImageService.GetAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
//if (productToBeDeleted == null)
//{
//    TempData["success"] = "Data Delated sucessfully.";
//    return Json(new { success = false, message = "Error while deleting" });
//}

//string productPath = @"images\companies\company-" + companyId;
//string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

//if (Directory.Exists(finalPath))
//{
//    string[] filePaths = Directory.GetFiles(finalPath);
//    foreach (string filePath in filePaths)
//    {
//        System.IO.File.Delete(filePath);
//    }

//    Directory.Delete(finalPath);
//}

//var response = await _companyImageService.DeleteAsync<APIResponse>(id, HttpContext.Session.GetString(SD.SessionToken));
//if (response != null && response.IsSuccess)
//{
//    TempData["success"] = "Data Delated sucessfully.";
//    // return RedirectToAction(nameof(IndexCompanyXAmenity));
//    return RedirectToAction("IndexCompany", "Company");
//}

//return View();