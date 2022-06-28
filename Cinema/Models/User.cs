using Cinema.EntityBases;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Models
{
    public class User : IdentityUser,IUser
    {
        
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
