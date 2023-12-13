

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class SecondCategoryRepository : Repository<SecondCategory>, ISecondCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public SecondCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  
        public async Task<SecondCategory> UpdateAsync(SecondCategory entity)
        {
         
            _db.SecondCategories.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
