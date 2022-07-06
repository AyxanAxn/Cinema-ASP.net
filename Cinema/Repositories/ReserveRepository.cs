using Cinema.DB;
using Cinema.Models;
using Cinema.UnitOfWorks.IRepository;
using System.Linq.Expressions;

namespace Cinema.Repositories
{
    public class ReserveRepository : Repository<Reserve>, IReservesRepository
    {

        private ApplicationDbContext _db;

        public ReserveRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        
        public void Update(Reserve obj)
        {
            _db.Reserves.Update(obj);
        }
    }
}
