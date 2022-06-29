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
            Movie = new MovieRepository(_db);
            Chair = new ChairRepository(_db);
            Room = new IRoomRepository(_db);
            Movie = new MovieRepository(_db);
            Movie = new MovieRepository(_db);
            Movie = new MovieRepository(_db);
            Movie = new MovieRepository(_db);
        }
        public IChairRepository Chair { get; set ; }
        public IMovieRepository Movie { get; set; }
        public IReservesRepository Room { get; set; }
        public IUserRepository User { get; set; }
        public ISeansRepository Seans { get; set;  }
        public ISeansReservesRepository SeansReserves { get; set; }
        public IReservesRepository Reserve { get ; set ; }

        public void Save()
        {
           
        }
    }
}
