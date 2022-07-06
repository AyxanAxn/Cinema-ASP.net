namespace Cinema.UnitOfWorks.IRepository
{
    public interface IUnitOfWork
    {
        IChairRepository Chair { get; set; }
        IMovieRepository Movie { get; set; }
        IRoomRepository Room { get; set; }
        IUserRepository User { get; set; }
        ISeansRepository Seans { get; set; }
        ISeansReservesRepository SeansReserves { get; set; }
        IReservesRepository Reserve { get; set; }

        void Save();

    }
}
