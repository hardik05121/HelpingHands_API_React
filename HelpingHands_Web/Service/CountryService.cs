

using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Service.IService;

namespace HelpingHands_Web.Service{    public class CountryService : BaseService, ICountryService    {        private readonly IHttpClientFactory _clientFactory;        private string categoryUrl;                public CountryService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)        {            _clientFactory = clientFactory;            categoryUrl = configuration.GetValue<string>("ServiceUrls:HelpingHandAPI");        }        public Task<T> CreateAsync<T>(CountryCreateDTO dto, string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.POST,                Data = dto,                Url = categoryUrl + "/api/v1/CountryAPI/CreateCountry",                Token = token            });        }        public Task<T> DeleteAsync<T>(int id, string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.DELETE,                Url = categoryUrl + "/api/v1/CountryAPI/DeleteCountry/" + id,                Token = token            });        }        public Task<T> GetAllAsync<T>(string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.GET,                Url = categoryUrl + "/api/v1/CountryAPI/GetCountrys",                Token = token            });        }

        public Task<T> CountryByLazyLoading<T>(int pageNum, string token)        {
            string apiUrl = $"{categoryUrl}/api/v1/CountryAPI/CountryByLazyLoading?pageNum={pageNum}";            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.GET,                Url = apiUrl,                Token = token            });
        }

        public Task<T> CountryByPagination<T>(string term, string orderBy, int currentPage, string token)        {
            //string apiUrl = $"{carUrl}/api/v1/StateAPI/GetStatesData/{Id}/{search}/{pageSize}/{pageNumber}";
            string apiUrl = $"{categoryUrl}/api/v1/CountryAPI/CountryByPagination?term={term}&orderBy={orderBy}&currentPage={currentPage}";            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.GET,                Url = apiUrl,                Token = token            });

        }        public Task<T> GetAsync<T>(int id, string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.GET,                Url = categoryUrl + "/api/v1/CountryAPI/GetCountry/" + id,                Token = token            });        }        public Task<T> UpdateAsync<T>(CountryUpdateDTO dto, string token)        {            return SendAsync<T>(new APIRequest()            {                ApiType = SD.ApiType.PUT,                Data = dto,                Url = categoryUrl + "/api/v1/CountryAPI/UpdateCountry/" + dto.Id,                Token = token            });        }    }}
