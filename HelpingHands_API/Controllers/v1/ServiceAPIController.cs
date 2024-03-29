﻿using AutoMapper;using Azure;
using HelpingHands_API.Data;using HelpingHands_API.Models;using HelpingHands_API.Models.DTO;using HelpingHands_API.Models.Index;
using HelpingHands_API.Repository.IRepostiory;using Microsoft.AspNetCore.Authorization;using Microsoft.AspNetCore.Http.HttpResults;using Microsoft.AspNetCore.JsonPatch;using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore;using System.Data;using System.Net;using System.Security.Claims;using System.Text.Json;namespace HelpingHands_API.Controllers.v1{
	[Route("api/v{version:apiVersion}/[Controller]/[Action]")]
	[ApiController]    [ApiVersion("1.0")]    public class ServiceAPIController : ControllerBase    {        protected APIResponse _response;        private readonly IUnitOfWork _unitOfWork;        private readonly IMapper _mapper;        private readonly ApplicationDbContext _db;        public ServiceAPIController(IUnitOfWork unitOfWork, IMapper mapper,ApplicationDbContext db)        {            _unitOfWork = unitOfWork;            _mapper = mapper;            _response = new();            _db = db;        }


		[HttpGet(Name = "GetServices")]
		[ResponseCache(CacheProfileName = "Default30")]        [ProducesResponseType(StatusCodes.Status403Forbidden)]        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        [ProducesResponseType(StatusCodes.Status200OK)]        public async Task<ActionResult<APIResponse>> GetServices([FromQuery(Name = "filterDisplayOrder")] int? Id,           [FromQuery] string? search, int pageSize = 0, int pageNumber = 1)        {            try            {                IEnumerable<Service> serviceList;                if (Id > 0)                {                    serviceList = await _unitOfWork.Service.GetAllAsync(u => u.Id == Id, includeProperties: "FirstCategory", pageSize: pageSize,                        pageNumber: pageNumber);                }                else                {                    serviceList = await _unitOfWork.Service.GetAllAsync(includeProperties: "FirstCategory", pageSize: pageSize,                        pageNumber: pageNumber);                }                if (!string.IsNullOrEmpty(search))                {                    serviceList = serviceList.Where(u => u.ServiceName.ToLower().Contains(search) ||                                                 u.FirstCategory.FirstCategoryName.ToLower().Contains(search));                }                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));                _response.Result = _mapper.Map<List<ServiceDTO>>(serviceList);                _response.StatusCode = HttpStatusCode.OK;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }

        [HttpGet("{firstCategoryId:int}", Name = "GetServiceByFirstCategoryId")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetServiceByFirstCategoryId(int firstCategoryId)
        {
            try
            {
                if (firstCategoryId == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var states = _db.Services.Include(u => u.FirstCategory).Where(u => u.FirstCategoryId == firstCategoryId).ToList();

                if (states == null || states.Count() == 0)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<List<ServiceDTO>>(states);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet(Name = "ServiceByPagination")]        [ResponseCache(CacheProfileName = "Default30")]        [ProducesResponseType(StatusCodes.Status403Forbidden)]        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        [ProducesResponseType(StatusCodes.Status200OK)]        public async Task<ActionResult<APIResponse>> ServiceByPagination(string term, string orderBy, int currentPage = 1)        {            try            {
                term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

                ServiceIndexVM serviceIndexVM = new ServiceIndexVM();
                IEnumerable<Service> list = await _unitOfWork.Service.GetAllAsync(includeProperties: "FirstCategory");

                var List = _mapper.Map<List<ServiceDTO>>(list);

                serviceIndexVM.NameSortOrder = string.IsNullOrEmpty(orderBy) ? "countryName_desc" : "";

                if (!string.IsNullOrEmpty(term))
                {
                    List = List.Where(u => u.ServiceName.ToLower().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    u.FirstCategory.FirstCategoryName.ToLower().Contains(term, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                switch (orderBy)
                {
                    case "countryName_desc":
                        List = List.OrderByDescending(a => a.ServiceName).ToList();
                        break;

                    default:
                        List = List.OrderBy(a => a.ServiceName).ToList();
                        break;
                }
                int totalRecords = List.Count();
                int pageSize = 10;
                int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
                List = List.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                // current=1, skip= (1-1=0), take=5 
                // currentPage=2, skip (2-1)*5 = 5, take=5 ,
                serviceIndexVM.services = List;
                serviceIndexVM.CurrentPage = currentPage;
                serviceIndexVM.TotalPages = totalPages;
                serviceIndexVM.Term = term;
                serviceIndexVM.PageSize = pageSize;
                serviceIndexVM.OrderBy = orderBy;

                _response.Result = _mapper.Map<ServiceIndexVM>(serviceIndexVM);                _response.StatusCode = HttpStatusCode.OK;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }        [HttpGet("{id:int}", Name = "GetService")]        [ProducesResponseType(StatusCodes.Status403Forbidden)]        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        [ProducesResponseType(StatusCodes.Status200OK)]        [ProducesResponseType(StatusCodes.Status400BadRequest)]        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(CategoryDTO))]
        //        [ResponseCache(Location =ResponseCacheLocation.None,NoStore =true)]
        public async Task<ActionResult<APIResponse>> GetService(int id)        {            try            {                if (id == 0)                {                    _response.StatusCode = HttpStatusCode.BadRequest;                    return BadRequest(_response);                }                var service = await _unitOfWork.Service.GetAsync(u => u.Id == id, includeProperties: "FirstCategory");                if (service == null)                {                    _response.StatusCode = HttpStatusCode.NotFound;                    return NotFound(_response);                }                _response.Result = _mapper.Map<ServiceDTO>(service);                _response.StatusCode = HttpStatusCode.OK;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }


		[HttpPost(Name = "CreateService")]
		// [Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status201Created)]        [ProducesResponseType(StatusCodes.Status400BadRequest)]        [ProducesResponseType(StatusCodes.Status500InternalServerError)]        public async Task<ActionResult<APIResponse>> CreateService([FromForm] ServiceCreateDTO createDTO)            {            try            {
             
                if (await _unitOfWork.Service.GetAsync(u => u.ServiceName.Trim().ToLower() == createDTO.ServiceName.Trim().ToLower() && u.FirstCategoryId == createDTO.FirstCategoryId) != null)                {                    ModelState.AddModelError("ErrorMessages", "Service name already Exists!");                    return BadRequest(ModelState);                }                if (await _unitOfWork.FirstCategory.GetAsync(u => u.Id == createDTO.FirstCategoryId) == null)                {                    ModelState.AddModelError("ErrorMessages", "FirstCategory name is Invalid!");                    return BadRequest(ModelState);                }                if (createDTO == null)                {                    return BadRequest(createDTO);                }                Service service = _mapper.Map<Service>(createDTO);                await _unitOfWork.Service.CreateAsync(service);                _response.Result = _mapper.Map<ServiceDTO>(service);                _response.StatusCode = HttpStatusCode.Created;                return CreatedAtRoute("GetService", new { id = service.Id }, _response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }        [ProducesResponseType(StatusCodes.Status204NoContent)]        [ProducesResponseType(StatusCodes.Status403Forbidden)]        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        [ProducesResponseType(StatusCodes.Status404NotFound)]        [ProducesResponseType(StatusCodes.Status400BadRequest)]        [HttpDelete("{id:int}", Name = "DeleteService")]

        public async Task<ActionResult<APIResponse>> DeleteService(int id)        {            try            {                if (id == 0)                {                    return BadRequest();                }                var service = await _unitOfWork.Service.GetAsync(u => u.Id == id);                if (service == null)                {                    return NotFound();                }                await _unitOfWork.Service.RemoveAsync(service);                _response.StatusCode = HttpStatusCode.NoContent;                _response.IsSuccess = true;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }        [HttpPut("{id:int}", Name = "UpdateService")]        [ProducesResponseType(StatusCodes.Status204NoContent)]        [ProducesResponseType(StatusCodes.Status400BadRequest)]        public async Task<ActionResult<APIResponse>> UpdateService(int id, [FromForm] ServiceUpdateDTO updateDTO)        {            try            {                if (updateDTO == null || id != updateDTO.Id)                {                    return BadRequest();                }
                if (await _unitOfWork.Service.GetAsync(u => u.ServiceName.ToLower() == updateDTO.ServiceName.ToLower() && u.FirstCategoryId == updateDTO.FirstCategoryId && u.Id != updateDTO.Id) != null)                {                    ModelState.AddModelError("ErrorMessages", "ServiceName already Exists!");                    return BadRequest(ModelState);                }                if (await _unitOfWork.FirstCategory.GetAsync(u => u.Id == updateDTO.FirstCategoryId) == null)                {                    ModelState.AddModelError("ErrorMessages", "Service ID is Invalid!");                    return BadRequest(ModelState);                }                Service model = _mapper.Map<Service>(updateDTO);                await _unitOfWork.Service.UpdateAsync(model);                _response.StatusCode = HttpStatusCode.NoContent;                _response.IsSuccess = true;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }        //[HttpPatch("{id:int}", Name = "UpdatePartialService")]        //[ProducesResponseType(StatusCodes.Status204NoContent)]        //[ProducesResponseType(StatusCodes.Status400BadRequest)]        //public async Task<IActionResult> UpdatePartialService(int id, JsonPatchDocument<ServiceUpdateDTO> patchDTO)        //{        //    if (patchDTO == null || id == 0)        //    {        //        return BadRequest();        //    }        //    var state = await _unitOfWork.Service.GetAsync(u => u.Id == id, tracked: false);        //    ServiceUpdateDTO stateDTO = _mapper.Map<ServiceUpdateDTO>(state);        //    if (state == null)        //    {        //        return BadRequest();        //    }        //    patchDTO.ApplyTo(stateDTO, ModelState);        //    Service model = _mapper.Map<Service>(stateDTO);        //    await _unitOfWork.Service.UpdateAsync(model);        //    if (!ModelState.IsValid)        //    {        //        return BadRequest(ModelState);        //    }        //    return NoContent();        //}    }}