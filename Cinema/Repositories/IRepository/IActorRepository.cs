using Cinema.Models;

namespace Cinema.UnitOfWorks.IRepository
{
    public interface IActorRepository:IRepository<Actor>
    {
        void Update(Actor obj);
    }
}