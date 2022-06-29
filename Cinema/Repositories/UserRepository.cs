using Cinema.DB;
using Cinema.Models;
using Cinema.UnitOfWorks.IRepository;
using System.Linq.Expressions;

namespace Cinema.Repositories
{
    public class UserRepostory : Repository<User>, IUserRepository
    {

        private ApplicationDbContext _db;

        public User(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
