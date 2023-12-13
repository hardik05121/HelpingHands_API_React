
using HelpingHands_API.Models;

namespace HelpingHands_API.Repository.IRepostiory
{
	public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {
        Task<ApplicationRole> UpdateAsync(ApplicationRole entity);
    }
}

