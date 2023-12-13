

using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
    public class CompanyXAmenityRepository : Repository<CompanyXAmenity>, ICompanyXAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyXAmenityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  
        public async Task<CompanyXAmenity> UpdateAsync(CompanyXAmenity entity)
        {
         
            _db.CompanyXAmenities.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
