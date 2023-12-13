

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class CompanyXServiceRepository : Repository<CompanyXService>, ICompanyXServiceRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyXServiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  
        public async Task<CompanyXService> UpdateAsync(CompanyXService entity)
        {
         
            _db.CompanyXServices.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
