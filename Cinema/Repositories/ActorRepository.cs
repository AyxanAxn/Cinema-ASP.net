using Cinema.DB;
using Cinema.Models;
using Cinema.UnitOfWorks.IRepository;
using System.Linq.Expressions;

namespace Cinema.Repositories
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {

        private ApplicationDbContext _db;

        public ActorRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        
        public void Update(Actor obj)
        {
            _db.Actors.Update(obj);
        }
    }
}
