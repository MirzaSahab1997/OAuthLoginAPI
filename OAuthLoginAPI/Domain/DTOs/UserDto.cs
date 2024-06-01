namespace OAuthLoginAPI.Domain.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AccessibleRegions { get; set; }
    }

    public static class StaticUserData
    {
        public static List<UserDto> Users = new List<UserDto>
    {
        new UserDto
        {
            Username = "player1",
            Password = "password1",
            Roles = new List<string> { "player" },
            AccessibleRegions = new List<string> { "b_game" }
        },
        new UserDto
        {
            Username = "admin1",
            Password = "password2",
            Roles = new List<string> { "admin" },
            AccessibleRegions = new List<string> { "b_game", "vip_chararacter_personalize" }
        }
    };
    }
}
