using System.Linq.Expressions;
using HotelReservation.Core.Models;
using HotelReservation.Services.Models;

namespace HotelReservation.Services.Interfaces;

public interface IRoomServices
{
    Task<Room?> GetById(int id);
    IEnumerable<Room> GetAllRooms(int? maxOccupancy ,int page = 10, int size = 1);
    Task<Room?> CreateRoom(RoomCreateDto dto);
    Room? UpdateRoom(int id, RoomCreateDto dto);
    bool DeleteRoom(int id);
}