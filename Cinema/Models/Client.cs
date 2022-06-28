using Cinema.EntityBases;

namespace Cinema.Models
{
    public class Client : IUser,IEntityBases
    {
        public int Id { get; set ; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
