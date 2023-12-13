
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface ICompanyXAmenityRepository : IRepository<CompanyXAmenity>
    {
      
        Task<CompanyXAmenity> UpdateAsync(CompanyXAmenity entity);

    }
}
