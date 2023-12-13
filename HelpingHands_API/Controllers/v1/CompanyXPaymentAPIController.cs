using AutoMapper;
using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Models.DTO;
using HelpingHands_API.Models.VM;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace HelpingHands_API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[Controller]/[Action]")]
    [ApiController]
    [ApiVersion("1.0")]

    public class CompanyXPaymentAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public CompanyXPaymentAPIController(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = new();
            _db = db;
        }

        [HttpGet(Name = "GetCompanyXPayments")]
        [ResponseCache(CacheProfileName = "Default30")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetCompanyXPayments([FromQuery(Name = "filterDisplayOrder")] int? Id,
                 [FromQuery] string? search, int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                IEnumerable<CompanyXPayment> companyXPaymentList;

                if (Id > 0)
                {

                    companyXPaymentList = await _unitOfWork.CompanyXPayment.GetAllAsync(u => u.Id == Id, includeProperties: "Company,Payment", pageSize: pageSize,
                        pageNumber: pageNumber);
                }
                else
                {
                    companyXPaymentList = await _unitOfWork.CompanyXPayment.GetAllAsync(includeProperties: "Company,Payment", pageSize: pageSize,
                        pageNumber: pageNumber);
                }
                if (!string.IsNullOrEmpty(search))
                {
                    companyXPaymentList = companyXPaymentList.Where(u => u.Company.CompanyName.ToLower().Contains(search) ||
                                                 u.Payment.PaymentName.ToLower().Contains(search));

                }
                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
                _response.Result = _mapper.Map<List<CompanyXPaymentDTO>>(companyXPaymentList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("{companyId:int}", Name = "GetCompanyXPaymentByCompanyId")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetCompanyXPaymentByCompanyId(int companyId)
        {
            try
            {
                if (companyId == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var states = _db.CompanyXPayments.Include(u => u.Company).Include(u => u.Payment).Where(u => u.CompanyId == companyId).ToList();

                if (states == null || states.Count() == 0)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<List<CompanyXPaymentDTO>>(states);
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

        [HttpGet("{id:int}", Name = "GetCompanyXPayment")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(CategoryDTO))]
        //        [ResponseCache(Location =ResponseCacheLocation.None,NoStore =true)]
        public async Task<ActionResult<APIResponse>> GetCompanyXPayment(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var category = await _unitOfWork.CompanyXPayment.GetAsync(u => u.Id == id, includeProperties: "Payment,Company");
                if (category == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<CompanyXPaymentDTO>(category);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost(Name = "CreateCompanyXPayment")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateCompanyXPayment([FromForm] CxpDTO createDTO)
        {
            try
            {
                await _unitOfWork.CompanyXPayment.RemoveRangeAsync(u => u.CompanyId == createDTO.CompanyId, false);

                foreach (var companyId in createDTO.SelectedPaymentIds)
                {
                    CompanyXPayment companyXPayment = new();
                    companyXPayment.CompanyId = createDTO.CompanyId;
                    companyXPayment.PaymentId = Convert.ToInt32(companyId);
                    await _unitOfWork.CompanyXPayment.CreateAsync(companyXPayment);
                }
                _response.StatusCode = HttpStatusCode.Created;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        //[HttpPost(Name = "CreateCompanyXPayment")]
        ////[Authorize(Roles = "admin")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<APIResponse>> CreateCompanyXPayment([FromForm] CompanyXPaymentVM createDTO)
        //{
        //    try
        //    {
        //        List<Payment> PaymentList = _mapper.Map<List<Payment>>(createDTO.Paymentlist);

        //        Company company = _mapper.Map<Company>(createDTO.Company);


        //        await _unitOfWork.CompanyXPayment.RemoveRangeAsync(x => x.CompanyId == company.Id, false);


        //        foreach (var paymentList in PaymentList)
        //        {

        //            if (paymentList.IsActive == true)
        //            {
        //                CompanyXPayment cxp = new();
        //                cxp.CompanyId = company.Id;
        //                cxp.PaymentId = paymentList.Id;
        //                await _unitOfWork.CompanyXPayment.CreateAsync(cxp);
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //        }
        //        _response.StatusCode = HttpStatusCode.Created;
        //        return _response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages
        //             = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteCompanyXPayment")]

        public async Task<ActionResult<APIResponse>> DeleteCompanyXPayment(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var category = await _unitOfWork.CompanyXPayment.GetAsync(u => u.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                await _unitOfWork.CompanyXPayment.RemoveAsync(category);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}

