

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  
        public async Task<Company> UpdateAsync(Company entity)
        {
            entity.UpdatedDate = System.DateTime.Now;
            _db.Companies.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
