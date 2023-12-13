
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface IPaymentRepository : IRepository<Payment>
    {
      
        Task<Payment> UpdateAsync(Payment entity);
  
    }
}
