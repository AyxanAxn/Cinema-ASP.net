using Cinema.DB;
using Cinema.UnitOfWorks.IRepository;

namespace Cinema.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            IMovie = new MovieRepository(_db);
            IChair = new ChairRepository(_db);
            IRoom = new  RoomRepository(_db);
            IMovie = new MovieRepository(_db);
            IMovie = new MovieRepository(_db);
            IMovie = new MovieRepository(_db);
            IMovie = new MovieRepository(_db);
        }


        public IChairRepository IChair { get; set; }
        public IMovieRepository IMovie { get; set; }
        public IRoomRepository IRoom{ get; set; }
        public IUserRepository IUser { get; set; }
        public ISeansRepository ISeans { get; set; }
        public ISeansReservesRepository ISeansReserves { get; set; }
        public IReservesRepository IReserve { get; set; }
       
        public void Save()
        {
           
        }
    }
}
