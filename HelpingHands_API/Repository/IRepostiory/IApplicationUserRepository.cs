
using HelpingHands_API.Models;

namespace HelpingHands_API.Repository.IRepostiory
{
	public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> UpdateAsync(ApplicationUser entity);
    }
}