using System.Linq.Expressions;
using AutoMapper;
using HotelReservation.Core.Models;
using HotelReservation.Core.Repositories;
using HotelReservation.Services.Interfaces;
using HotelReservation.Services.Models;

namespace HotelReservation.Services.Implementations;

public class RoomServices : IRoomServices
{
    private readonly IUnitOfWork _unitOfWork;

    public RoomServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    IMapper mapper = MapperProfile.CreateConfig();

    public async Task<Room?> GetById(int id)
    {
        return await _unitOfWork.Rooms.GetById(id);
    }

    public IEnumerable<Room> GetAllRooms(int?maxOccupancy = null, int page = 10, int size = 1)
    {
        Expression<Func<Room, bool>>? expression = null;
        if(maxOccupancy is not null)
            expression = room => room.MaxOccupancy == maxOccupancy;
        
        return _unitOfWork.Rooms.GetAll( expression ,page, size);
    }

    public async Task<Room?> CreateRoom(RoomCreateDto dto)
    {
        var room = mapper.Map<Room>(dto);
        var result = await _unitOfWork.Rooms.CreateOne(room);
        _unitOfWork.Complete();
        return result;
    }

    public Room? UpdateRoom(int id , RoomCreateDto dto)
    {
        var room = mapper.Map<Room>(dto);
        room.Id = id;
        var result = _unitOfWork.Rooms.UpdateOne(room);
        _unitOfWork.Complete();
        return result;
    }
    public bool DeleteRoom(int id)
    {
        var result = _unitOfWork.Rooms.DeleteOne(id);
        _unitOfWork.Complete();
        return result;
    }
}