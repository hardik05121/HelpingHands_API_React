
using HelpingHands_API.Models;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
{
    public interface IAmenityRepository : IRepository<Amenity>
    {
      
        Task<Amenity> UpdateAsync(Amenity entity);
  
    }
}
