using Cinema.Models;

namespace Cinema.UnitOfWorks.IRepository
{
    public interface IMovieRepository:IRepository<Movie>
    {
        void Update(Movie obj);
    }
}