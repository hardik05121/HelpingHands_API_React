

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class ThirdCategoryRepository : Repository<ThirdCategory>, IThirdCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public ThirdCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  
        public async Task<ThirdCategory> UpdateAsync(ThirdCategory entity)
        {
         
            _db.ThirdCategories.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
