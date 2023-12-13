
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface IFirstCategoryRepository : IRepository<FirstCategory>
    {
      
        Task<FirstCategory> UpdateAsync(FirstCategory entity);
  
    }
}
