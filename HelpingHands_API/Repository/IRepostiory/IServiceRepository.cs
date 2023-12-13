
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface IServiceRepository : IRepository<Service>
    {
      
        Task<Service> UpdateAsync(Service entity);
  
    }
}
