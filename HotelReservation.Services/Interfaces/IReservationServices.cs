using HotelReservation.Core.Models;
using HotelReservation.Services.Models;

namespace HotelReservation.Services.Interfaces;

public interface IReservationServices
{
    Task<ReservationDto?> GetById(int id);
    IEnumerable<ReservationDto> GetByGuestId(int guestId);
    IEnumerable<ReservationDto> GetAllReservations(DateTime? checkInDate ,DateTime? checkOutDate,int page = 10, int size = 1);
    Task<ReservationDto?> Reserve(ReserveDto dto);
    // Room? UpdateRoom(int id, RoomCreateDto dto);
    Task<bool> DeleteReservation(int id);
}