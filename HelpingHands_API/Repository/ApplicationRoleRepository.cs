
using HelpingHands_API.Data;
using HelpingHands_API.Models;
using HelpingHands_API.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository
{
	public class ApplicationRoleRepository : Repository<ApplicationRole>, IApplicationRoleRepository
	{
        private readonly ApplicationDbContext _db;
        public ApplicationRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ApplicationRole> UpdateAsync(ApplicationRole entity)
        {
            _db.ApplicationRoles.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
