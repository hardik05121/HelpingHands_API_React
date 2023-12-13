
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface ICompanyImageRepository : IRepository<CompanyImage>
    {
      
        Task<CompanyImage> UpdateAsync(CompanyImage entity);
  
    }
}
