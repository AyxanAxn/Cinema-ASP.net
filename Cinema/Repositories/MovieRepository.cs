using Cinema.DB;
using Cinema.Models;
using Cinema.UnitOfWorks.IRepository;
using System.Linq.Expressions;

namespace Cinema.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {

        private ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void Update(Models.Movie obj)
        {
            throw new NotImplementedException();
        }
    }
}
