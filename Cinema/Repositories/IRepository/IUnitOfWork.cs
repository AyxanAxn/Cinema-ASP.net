namespace Cinema.UnitOfWorks.IRepository
{
    public interface IUnitOfWork
    {
        IChairRepository IChair { get; set; }
        IMovieRepository IMovie { get; set; }
        IReservesRepository IRoom { get; set; }
        IUserRepository IUser { get; set; }
        ISeansRepository ISeans { get; set; }
        ISeansReservesRepository ISeansReserves { get; set; }
        IReservesRepository IReserve { get;set; }

        void Save();

    }
}
