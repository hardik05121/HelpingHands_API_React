using HelpingHands_Web.Models.DTO;

namespace HelpingHands_Web.Service.IService
{
    public interface IFirstCategoryService
    {
      
            Task<T> GetAllAsync<T>(string token);
            Task<T> GetAsync<T>(int id, string token);
            Task<T> CreateAsync<T>(FirstCategoryCreateDTO dto, string token);
            Task<T> UpdateAsync<T>(FirstCategoryUpdateDTO dto, string token);
            Task<T> DeleteAsync<T>(int id, string token);
        Task<T> FirstCategoryByPagination<T>(string term, string orderBy, int currentPage, string token);
    }
}
