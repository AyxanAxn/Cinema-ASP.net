using Cinema.Models;

namespace Cinema.UnitOfWorks.IRepository
{
    public interface IRoomRepository :IRepository<Room>
    {
        void Update(Room obj);
    }
}