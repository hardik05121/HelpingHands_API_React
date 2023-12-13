using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.VM;

namespace HelpingHands_Web.Service.IService
{
    public interface ICompanyImageService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(CompanyImageCreateVM dto, string token);
        Task<T> SetAsync<T>(int imageId, int companyId, string token);
        Task<T> DeleteAsync<T>(int id, string token);

    }
}
