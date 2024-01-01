using HotelReservation.Core.Models;
using HotelReservation.Services.Models;

namespace HotelReservation.Services.Interfaces;

public interface IGuestServices 
{
Task<GuestDto?> GetById(int id);
IEnumerable<GuestDto> GetAllGuests(string? name ,int page = 10, int size = 1);
Task<GuestDto?> CreateGuest(GuestCreateDto dto);
bool DeleteGuest(int id);
}