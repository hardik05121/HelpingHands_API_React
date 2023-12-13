using HelpingHands_Utility;
using HelpingHands_Web.Models;
using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.VM;
using HelpingHands_Web.Service.IService;

namespace HelpingHands_Web.Service
{
    public class CompanyXAmenityService : BaseService, ICompanyXAmenityService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string categoryUrl;

        public CompanyXAmenityService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            categoryUrl = configuration.GetValue<string>("ServiceUrls:HelpingHandAPI");

        }

        public Task<T> CreateAsync<T>(CompanyXAmenityVM dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = categoryUrl + "/api/v1/CompanyXAmenityAPI",
                Token = token
            });
        }


        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = categoryUrl + "/api/v1/CompanyXAmenityAPI",
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = categoryUrl + "/api/v1/CompanyXAmenityAPI",
                Token = token,
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = categoryUrl + "/api/v1/CompanyXAmenityAPI/" + id,
                Token = token
            });
        }

        //public Task<T> UpdateAsync<T>(CompanyXAmenityVM dto, string token)
        //{
        //    return SendAsync<T>(new APIRequest()
        //    {
        //        ApiType = SD.ApiType.PUT,
        //        Data = dto,
        //        Url = categoryUrl + "/api/v1/CompanyXAmenityAPI",
        //        Token = token
        //    });
        //}

    }
}

