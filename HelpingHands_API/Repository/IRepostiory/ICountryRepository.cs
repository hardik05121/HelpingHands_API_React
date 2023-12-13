
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface ICountryRepository : IRepository<Country>
    {
      
        Task<Country> UpdateAsync(Country entity);
  
    }
}
