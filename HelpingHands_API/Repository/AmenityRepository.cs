

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class AmenityRepository : Repository<Amenity>, IAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        public AmenityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  
        public async Task<Amenity> UpdateAsync(Amenity entity)
        {
         
            _db.Amenities.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
