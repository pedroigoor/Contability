namespace Gs_Contability.Dto.Users
{
    public class UserRequestUpdateDTO
    {
       
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;


    }
}
