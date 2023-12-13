
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface IThirdCategoryRepository : IRepository<ThirdCategory>
    {
      
        Task<ThirdCategory> UpdateAsync(ThirdCategory entity);
  
    }
}
