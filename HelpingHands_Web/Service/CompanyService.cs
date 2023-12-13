using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Service.IService;

namespace HelpingHands_Web.Service
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string categoryUrl;

        public CompanyService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            categoryUrl = configuration.GetValue<string>("ServiceUrls:HelpingHandAPI");

        }

        public Task<T> CreateAsync<T>(CompanyDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = categoryUrl + "/api/v1/CompanyAPI/CreateCompany",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = categoryUrl + "/api/v1/CompanyAPI/DeleteCompany/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = categoryUrl + "/api/v1/CompanyAPI/GetCompanys",
                Token = token
            });
        }

        public Task<T> CompanyByPagination<T>(string term, string orderBy, int currentPage, string token)
        {
            //string apiUrl = $"{carUrl}/api/v1/StateAPI/GetStatesData/{Id}/{search}/{pageSize}/{pageNumber}";
            string apiUrl = $"{categoryUrl}/api/v1/CompanyAPI/CompanyByPagination?term={term}&orderBy={orderBy}&currentPage={currentPage}";

            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl,
                Token = token
            });

        }

        public Task<T> CompanySearchByLazyLoading<T>(int pageNum, string searchText,string token)
        {
            string apiUrl = $"{categoryUrl}/api/v1/CompanyAPI/CompanySearchByLazyLoading?pageNum={pageNum}&searchText={searchText}";
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl,
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = categoryUrl + "/api/v1/CompanyAPI/GetCompany/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(CompanyDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = categoryUrl + "/api/v1/CompanyAPI/UpdateCompany/" + dto.Id,
                Token = token
            });
        }
    }
}
