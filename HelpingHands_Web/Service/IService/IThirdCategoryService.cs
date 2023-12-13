using HelpingHands_Web.Models.DTO;

namespace HelpingHands_Web.Service.IService
{
    public interface IThirdCategoryService
    {
      
            Task<T> GetAllAsync<T>(string token);
            Task<T> GetAsync<T>(int id, string token);
            Task<T> CreateAsync<T>(ThirdCategoryCreateDTO dto, string token);
            Task<T> UpdateAsync<T>(ThirdCategoryUpdateDTO dto, string token);
            Task<T> DeleteAsync<T>(int id, string token);
        Task<T> ThirdCategoryByPagination<T>(string term, string orderBy, int currentPage, string token);
    }
}
