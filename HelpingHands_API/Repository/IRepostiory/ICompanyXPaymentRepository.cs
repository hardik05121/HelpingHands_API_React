
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface ICompanyXPaymentRepository : IRepository<CompanyXPayment>
    {
      
        Task<CompanyXPayment> UpdateAsync(CompanyXPayment entity);
  
    }
}
