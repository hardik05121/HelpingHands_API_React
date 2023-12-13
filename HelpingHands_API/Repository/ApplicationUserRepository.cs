
using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser entity)
        {
            _db.ApplicationUsers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
