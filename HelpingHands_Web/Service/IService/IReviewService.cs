using HelpingHands_Web.Models.DTO;
using HelpingHands_Web.Models.VM;

namespace HelpingHands_Web.Service.IService
{
    public interface IReviewService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(ReviewCreateVM dto, string token);
        Task<T> UpdateAsync<T>(ReviewUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
        Task<T> ReviewByPagination<T>(string term, string orderBy, int currentPage, string token);
    }
}
