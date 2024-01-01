using HotelReservation.Core.Models;

namespace HotelReservation.Core.Repositories;

public interface IUnitOfWork : IDisposable
{
    
    IBaseRepository<Room> Rooms { get; }
    IBaseRepository<Reservation> Reservations { get; }
    IBaseRepository<Guest> Guests { get; }
    IBaseRepository<Review> Reviews { get; }
    int Complete();
}