using Cinema.Models;

namespace Cinema.UnitOfWorks.IRepository
{
    public interface ISeansReservesRepository:IRepository<SeansReserves>
    {
        void Update(SeansReserves obj);
    }
}