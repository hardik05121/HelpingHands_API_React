
using HelpingHands_API.Models;

namespace HelpingHands_API.Repository.IRepostiory
{
	public interface IApplicationUserRoleRepository : IRepository<ApplicationUserRole>
    {
        Task<ApplicationUserRole> UpdateAsync(ApplicationUserRole entity);
    }
}