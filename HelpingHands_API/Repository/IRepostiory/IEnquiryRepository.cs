
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface IEnquiryRepository : IRepository<Enquiry>
    {
      
        Task<Enquiry> UpdateAsync(Enquiry entity);
  
    }
}
