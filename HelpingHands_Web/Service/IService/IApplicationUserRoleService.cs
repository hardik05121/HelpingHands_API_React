
using HelpingHands_Web.Models.VM;

namespace HelpingHands_Web.Service.IService
{
    public interface IApplicationUserRoleService
    {

        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(string Id, string token);
    }
}
