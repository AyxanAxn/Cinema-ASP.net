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
            Chair = new ChairRepository(_db);
            Movie = new MovieRepository(_db);
            Room = new RoomRepository(_db);
            Seans = new SeansRepository(_db);
            SeansReserves = new SeansReservesRepository(_db);
            Reserve = new ReserveRepository(_db);
            User = new UserRepostory(_db);
            Actor=new ActorRepository(_db);
      
        }


        public IChairRepository Chair { get; set; }
        public IMovieRepository Movie { get; set; }
        public IRoomRepository Room { get; set; }
        public ISeansRepository Seans { get; set; }
        public ISeansReservesRepository SeansReserves { get; set; }
        public IReservesRepository Reserve { get; set; }
        public IUserRepository User { get; set; }
        public IActorRepository Actor { get; set; }

        public void Save()
        {
           _db.SaveChanges();
        }
    }
}
