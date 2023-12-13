

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class CompanyImageRepository : Repository<CompanyImage>, ICompanyImageRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  
        public async Task<CompanyImage> UpdateAsync(CompanyImage entity)
        {
            _db.CompanyImages.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
