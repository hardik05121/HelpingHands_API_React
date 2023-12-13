
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface ICompanyRepository : IRepository<Company>
    {
      
        Task<Company> UpdateAsync(Company entity);
  
    }
}
