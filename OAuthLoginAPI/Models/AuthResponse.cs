namespace OAuthLoginAPI.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AccessibleRegions { get; set; }
    }
}
