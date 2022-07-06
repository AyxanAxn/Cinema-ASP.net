using Cinema.Models;

namespace Cinema.UnitOfWorks.IRepository
{
    public interface IChairRepository : IRepository<Chair>
    {
        void Update(Chair obj);
    }
}