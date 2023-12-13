
using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
	public class ApplicationUserRoleRepository : Repository<ApplicationUserRole>, IApplicationUserRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ApplicationUserRole> UpdateAsync(ApplicationUserRole entity)
        {
            _db.ApplicationUserRoles.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
