

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class FirstCategoryRepository : Repository<FirstCategory>, IFirstCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public FirstCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<FirstCategory> UpdateAsync(FirstCategory entity)
        {
            _db.FirstCategories.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
