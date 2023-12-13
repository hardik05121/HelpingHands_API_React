namespace HelpingHands_API.Models.DTO
{
	public class LoginResponseDTO
    {
        public ApplicationUserDTO ApplicationUser { get; set; }
        public string Token { get; set; }
    }
}
