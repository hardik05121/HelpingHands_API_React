using HelpingHands_Web.Models.DTO;

namespace HelpingHands_Web.Service.IService
{
    public interface IEnquiryService
    {

        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(EnquiryDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
        Task<T> EnquiryByPagination<T>(string term, string orderBy, int currentPage, string token);
    }
}
