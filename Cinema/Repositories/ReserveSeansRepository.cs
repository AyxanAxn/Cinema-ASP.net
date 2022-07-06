using Cinema.DB;
using Cinema.Models;
using Cinema.UnitOfWorks.IRepository;
using System.Linq.Expressions;

namespace Cinema.Repositories
{
    public class SeansReservesRepository : Repository<SeansReserves>, ISeansReservesRepository
    {

        private ApplicationDbContext _db;

        public SeansReservesRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void Update(SeansReserves obj)
        {
            _db.SeansReserves.Update(obj);
        }
    }
}
