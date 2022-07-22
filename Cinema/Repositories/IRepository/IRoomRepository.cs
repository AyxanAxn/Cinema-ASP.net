using Cinema.Models;
using Cinema.Models.DTOs;

namespace Cinema.UnitOfWorks.IRepository
{
    public interface IRoomRepository :IRepository<Room>
    {
        void Update(Room obj);
    }
}