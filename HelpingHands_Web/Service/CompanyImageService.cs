using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.VM;
using HelpingHands_Web.Service.IService;

namespace HelpingHands_Web.Service
{
    public class CompanyImageService : BaseService, ICompanyImageService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string categoryUrl;

        public CompanyImageService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            categoryUrl = configuration.GetValue<string>("ServiceUrls:HelpingHandAPI");
        }

        public Task<T> CreateAsync<T>(CompanyImageCreateVM dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = categoryUrl + "/api/v1/CompanyImageAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = categoryUrl + "/api/v1/CompanyImageAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = categoryUrl + "/api/v1/CompanyImageAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = categoryUrl + "/api/v1/CompanyImageAPI/" + id,
                Token = token
            });
        }

        public Task<T> SetAsync<T>(int imageId, int companyId, string token)
        {
            string apiUrl = $"{categoryUrl}/api/v1/CompanyImageAPI/{imageId}/{companyId}";

            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                // Data = dto,
                Url = apiUrl,
                Token = token
            });
        }

    }
}
