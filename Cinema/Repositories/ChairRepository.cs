using Cinema.DB;
using Cinema.Models;
using Cinema.UnitOfWorks.IRepository;
using System.Linq.Expressions;

namespace Cinema.Repositories
{
    public class ChairRepository : Repository<Chair>, IChairRepository
    {

        private ApplicationDbContext _db;

        public ChairRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void Update(Chair obj)
        {
            throw new NotImplementedException();
        }
    }
}
