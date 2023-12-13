
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface IReviewRepository : IRepository<Review>
    {
      
        Task<Review> UpdateAsync(Review entity);
  
    }
}
