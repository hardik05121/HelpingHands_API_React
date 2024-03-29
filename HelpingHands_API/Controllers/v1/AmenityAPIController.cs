﻿using AutoMapper;using Azure;
using HelpingHands_API.Data;using HelpingHands_API.Models;using HelpingHands_API.Models.DTO;using HelpingHands_API.Models.Index;
using HelpingHands_API.Repository.IRepostiory;using Microsoft.AspNetCore.Authorization;using Microsoft.AspNetCore.Http.HttpResults;using Microsoft.AspNetCore.JsonPatch;using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore;using System.Data;using System.Net;using System.Security.Claims;using System.Text.Json;namespace HelpingHands_API.Controllers.v1{
    [Route("api/v{version:apiVersion}/[Controller]/[Action]")]
    [ApiController]    [ApiVersion("1.0")]    public class AmenityAPIController : ControllerBase    {        protected APIResponse _response;        private readonly IUnitOfWork _unitOfWork;        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;        public AmenityAPIController(IUnitOfWork unitOfWork, IMapper mapper,ApplicationDbContext db)        {            _unitOfWork = unitOfWork;            _mapper = mapper;            _response = new();            _db = db;        }


		[HttpGet(Name = "GetAmenitys")]
		[ResponseCache(CacheProfileName = "Default30")]        [ProducesResponseType(StatusCodes.Status403Forbidden)]        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        [ProducesResponseType(StatusCodes.Status200OK)]        public async Task<ActionResult<APIResponse>> GetAmenitys([FromQuery(Name = "filterDisplayOrder")] int? Id,           [FromQuery] string? search, int pageSize = 0, int pageNumber = 1)        {            try            {                IEnumerable<Amenity> amenityList;                if (Id > 0)                {                    amenityList = await _unitOfWork.Amenity.GetAllAsync(u => u.Id == Id, includeProperties: "FirstCategory", pageSize: pageSize,                        pageNumber: pageNumber);                }                else                {                    amenityList = await _unitOfWork.Amenity.GetAllAsync(includeProperties: "FirstCategory", pageSize: pageSize,                        pageNumber: pageNumber);                }                if (!string.IsNullOrEmpty(search))                {                    amenityList = amenityList.Where(u => u.AmenityName.ToLower().Contains(search) ||                                                 u.FirstCategory.FirstCategoryName.ToLower().Contains(search));                }                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));                _response.Result = _mapper.Map<List<AmenityDTO>>(amenityList);                _response.StatusCode = HttpStatusCode.OK;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }

        [HttpGet("{firstCategoryId:int}", Name = "GetAmenityByFirstCategoryId")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAmenityByFirstCategoryId(int firstCategoryId)
        {
            try
            {
                if (firstCategoryId == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var states = _db.Amenities.Include(u => u.FirstCategory).Where(u => u.FirstCategoryId == firstCategoryId).ToList();

                if (states == null || states.Count() == 0)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<List<AmenityDTO>>(states);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }        [HttpGet("{id:int}", Name = "GetAmenity")]        [ProducesResponseType(StatusCodes.Status403Forbidden)]        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        [ProducesResponseType(StatusCodes.Status200OK)]        [ProducesResponseType(StatusCodes.Status400BadRequest)]        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(CategoryDTO))]
        //        [ResponseCache(Location =ResponseCacheLocation.None,NoStore =true)]
        public async Task<ActionResult<APIResponse>> GetAmenity(int id)        {            try            {                if (id == 0)                {                    _response.StatusCode = HttpStatusCode.BadRequest;                    return BadRequest(_response);                }                var amenity = await _unitOfWork.Amenity.GetAsync(u => u.Id == id, includeProperties: "FirstCategory");                if (amenity == null)                {                    _response.StatusCode = HttpStatusCode.NotFound;                    return NotFound(_response);                }                _response.Result = _mapper.Map<AmenityDTO>(amenity);                _response.StatusCode = HttpStatusCode.OK;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }        [HttpGet(Name = "AmenityByPagination")]        [ResponseCache(CacheProfileName = "Default30")]        [ProducesResponseType(StatusCodes.Status403Forbidden)]        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        [ProducesResponseType(StatusCodes.Status200OK)]        public async Task<ActionResult<APIResponse>> AmenityByPagination(string term, string orderBy, int currentPage = 1)        {            try            {
                term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

                AmenityIndexVM amenityIndexVM = new AmenityIndexVM();
                IEnumerable<Amenity> list = await _unitOfWork.Amenity.GetAllAsync(includeProperties: "FirstCategory");
                var LIST = list.OrderBy(a => a.AmenityName).ToList();
                var List = _mapper.Map<List<AmenityDTO>>(LIST);

                amenityIndexVM.NameSortOrder = string.IsNullOrEmpty(orderBy) ? "countryName_desc" : "";

                if (!string.IsNullOrEmpty(term))
                {
                    List = List.Where(u => u.AmenityName.ToLower().Contains(term) ||
                    u.FirstCategory.FirstCategoryName.ToLower().Contains(term)).ToList();
                }

                switch (orderBy)
                {
                    case "countryName_desc":
                        List = List.OrderByDescending(a => a.AmenityName).ToList();
                        break;

                    default:
                        List = List.OrderBy(a => a.AmenityName).ToList();
                        break;
                }
                int totalRecords = List.Count();
                int pageSize = 10;
                int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
                List = List.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                // current=1, skip= (1-1=0), take=5 
                // currentPage=2, skip (2-1)*5 = 5, take=5 ,
                amenityIndexVM.amenities = List;
                amenityIndexVM.CurrentPage = currentPage;
                amenityIndexVM.TotalPages = totalPages;
                amenityIndexVM.Term = term;
                amenityIndexVM.PageSize = pageSize;
                amenityIndexVM.OrderBy = orderBy;

                _response.Result = _mapper.Map<AmenityIndexVM>(amenityIndexVM);                _response.StatusCode = HttpStatusCode.OK;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }        [HttpPost(Name = "CreateAmenity")]
        // [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]        [ProducesResponseType(StatusCodes.Status400BadRequest)]        [ProducesResponseType(StatusCodes.Status500InternalServerError)]        public async Task<ActionResult<APIResponse>> CreateAmenity([FromForm] AmenityCreateDTO createDTO)
        {            try            {

                if (await _unitOfWork.Amenity.GetAsync(u => u.AmenityName.Trim().ToLower() == createDTO.AmenityName.Trim().ToLower() && u.FirstCategoryId == createDTO.FirstCategoryId) != null)                {                    ModelState.AddModelError("ErrorMessages", "Amenityname already Exists!");                    return BadRequest(ModelState);                }                if (await _unitOfWork.FirstCategory.GetAsync(u => u.Id == createDTO.FirstCategoryId) == null)                {                    ModelState.AddModelError("ErrorMessages", "FirstCategory name is Invalid!");                    return BadRequest(ModelState);                }                if (createDTO == null)                {                    return BadRequest(createDTO);                }                Amenity amenity = _mapper.Map<Amenity>(createDTO);                await _unitOfWork.Amenity.CreateAsync(amenity);                _response.Result = _mapper.Map<AmenityDTO>(amenity);                _response.StatusCode = HttpStatusCode.Created;                return CreatedAtRoute("GetAmenity", new { id = amenity.Id }, _response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }        [ProducesResponseType(StatusCodes.Status204NoContent)]        [ProducesResponseType(StatusCodes.Status403Forbidden)]        [ProducesResponseType(StatusCodes.Status401Unauthorized)]        [ProducesResponseType(StatusCodes.Status404NotFound)]        [ProducesResponseType(StatusCodes.Status400BadRequest)]        [HttpDelete("{id:int}", Name = "DeleteAmenity")]

        public async Task<ActionResult<APIResponse>> DeleteAmenity(int id)        {            try            {                if (id == 0)                {                    return BadRequest();                }                var amenity = await _unitOfWork.Amenity.GetAsync(u => u.Id == id);                if (amenity == null)                {                    return NotFound();                }                await _unitOfWork.Amenity.RemoveAsync(amenity);                _response.StatusCode = HttpStatusCode.NoContent;                _response.IsSuccess = true;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }        [HttpPut("{id:int}", Name = "UpdateAmenity")]        [ProducesResponseType(StatusCodes.Status204NoContent)]        [ProducesResponseType(StatusCodes.Status400BadRequest)]        public async Task<ActionResult<APIResponse>> UpdateAmenity(int id, [FromForm] AmenityUpdateDTO updateDTO)        {            try            {                if (updateDTO == null || id != updateDTO.Id)                {                    return BadRequest();                }                if (await _unitOfWork.FirstCategory.GetAsync(u => u.Id == updateDTO.FirstCategoryId) == null)                {                    ModelState.AddModelError("ErrorMessages", "Amenity ID is Invalid!");                    return BadRequest(ModelState);                }                if (await _unitOfWork.Amenity.GetAsync(u => u.AmenityName.ToLower() == updateDTO.AmenityName.ToLower() && u.FirstCategoryId == updateDTO.FirstCategoryId && u.Id != updateDTO.Id) != null)                {                    ModelState.AddModelError("ErrorMessages", "AmenityName already Exists!");                    return BadRequest(ModelState);                }                              Amenity model = _mapper.Map<Amenity>(updateDTO);                await _unitOfWork.Amenity.UpdateAsync(model);                _response.StatusCode = HttpStatusCode.NoContent;                _response.IsSuccess = true;                return Ok(_response);            }            catch (Exception ex)            {                _response.IsSuccess = false;                _response.ErrorMessages                     = new List<string>() { ex.ToString() };            }            return _response;        }        //[HttpPatch("{id:int}", Name = "UpdatePartialAmenity")]        //[ProducesResponseType(StatusCodes.Status204NoContent)]        //[ProducesResponseType(StatusCodes.Status400BadRequest)]        //public async Task<IActionResult> UpdatePartialAmenity(int id, JsonPatchDocument<AmenityUpdateDTO> patchDTO)        //{        //    if (patchDTO == null || id == 0)        //    {        //        return BadRequest();        //    }        //    var state = await _unitOfWork.Amenity.GetAsync(u => u.Id == id, tracked: false);        //    AmenityUpdateDTO stateDTO = _mapper.Map<AmenityUpdateDTO>(state);        //    if (state == null)        //    {        //        return BadRequest();        //    }        //    patchDTO.ApplyTo(stateDTO, ModelState);        //    Amenity model = _mapper.Map<Amenity>(stateDTO);        //    await _unitOfWork.Amenity.UpdateAsync(model);        //    if (!ModelState.IsValid)        //    {        //        return BadRequest(ModelState);        //    }        //    return NoContent();        //}    }}