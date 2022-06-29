using Cinema.Models;

namespace Cinema.UnitOfWorks.IRepository
{
    public interface ISeansRepository:IRepository<Seans>
    {
        void Update(Seans obj);
    }
}