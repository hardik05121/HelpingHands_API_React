using HelpingHands_API.Models.DTO;

namespace HelpingHands_API.Repository.IRepostiory
{
	public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<ApplicationUserDTO> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
