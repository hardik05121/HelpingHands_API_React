
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface ICompanyXServiceRepository : IRepository<CompanyXService>
    {
      
        Task<CompanyXService> UpdateAsync(CompanyXService entity);
  
    }
}
