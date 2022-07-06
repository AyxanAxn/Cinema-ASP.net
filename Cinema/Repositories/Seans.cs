using Cinema.DB;
using Cinema.Models;
using Cinema.UnitOfWorks.IRepository;
using System.Linq.Expressions;

namespace Cinema.Repositories
{
    public class SeansRepository : Repository<Seans>, ISeansRepository
    {

        private ApplicationDbContext _db;

        public SeansRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void Update(Seans obj)
        {
            _db.Seans.Update(obj);
        }
    }
}
