using HotelReservation.Core.Models;
using HotelReservation.Core.Repositories;

namespace HotelReservation.Ef.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IBaseRepository<Room> Rooms { get; private set; }

    public IBaseRepository<Reservation> Reservations { get;private set; }
    public IBaseRepository<Guest> Guests { get;private set; }
    public IBaseRepository<Review> Reviews { get;private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Rooms = new BaseRepository<Room>(_context);
        Reservations = new BaseRepository<Reservation>(_context);
        Guests = new BaseRepository<Guest>(_context);
        Reviews = new BaseRepository<Review>(_context);
    }
    public int Complete()
    {
        return _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}