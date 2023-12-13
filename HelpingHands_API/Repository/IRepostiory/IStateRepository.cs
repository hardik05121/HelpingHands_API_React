
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface IStateRepository : IRepository<State>
    {
      
        Task<State> UpdateAsync(State entity);
  
    }
}
