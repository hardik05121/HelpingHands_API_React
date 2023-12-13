
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface IReviewXCommentRepository : IRepository<ReviewXComment>
    {
      
        Task<ReviewXComment> UpdateAsync(ReviewXComment entity);
  
    }
}
