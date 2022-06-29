using Cinema.Models;

namespace Cinema.UnitOfWorks.IRepository
{
    public interface IReservesRepository: IRepository<Reserve>
    {
        void Update(Reserve obj);
    }
}