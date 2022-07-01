using Cinema.EntityBases;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    [NotMapped]
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
