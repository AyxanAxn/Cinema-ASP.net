using Cinema.DB;
using Cinema.Models;
using Cinema.Models.DTOs;
using Cinema.UnitOfWorks.IRepository;
using System.Linq.Expressions;

namespace Cinema.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {

        private ApplicationDbContext _db;

        public RoomRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

       

        public void Update(Room obj)
        {
            _db.Rooms.Update(obj);
        }
    }
}
