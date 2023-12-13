using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.VM;

namespace HelpingHands_Web.Service.IService
{
    public interface ICompanyXServiceService

	{

        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(CompanyXServiceVM dto, string token);
      //  Task<T> UpdateAsync<T>(CompanyXServiceUpdateVM dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);


    }
}
