using Cinema.Models;

namespace Cinema.UnitOfWorks.IRepository
{
    public interface IUserRepository :IRepository<User>
    {
        void Update(User obj);
    }
}