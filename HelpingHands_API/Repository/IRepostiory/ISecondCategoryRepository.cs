
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface ISecondCategoryRepository : IRepository<SecondCategory>
    {
      
        Task<SecondCategory> UpdateAsync(SecondCategory entity);
  
    }
}
