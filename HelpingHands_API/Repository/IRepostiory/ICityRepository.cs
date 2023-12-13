
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface ICityRepository : IRepository<City>
    {
      
        Task<City> UpdateAsync(City entity);
  
    }
}
