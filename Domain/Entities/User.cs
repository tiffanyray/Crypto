using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Bio { get; set; }
        public string CoinBaseRefreshToken { get; set; }
    }
}