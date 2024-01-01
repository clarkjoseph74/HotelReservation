using System.Linq.Expressions;
using AutoMapper;
using HotelReservation.Core.Models;
using HotelReservation.Core.Repositories;
using HotelReservation.Services.Interfaces;

namespace HotelReservation.Services.Models;

public class ReservationServices : IReservationServices
{
    private readonly IUnitOfWork _unitOfWork;
    IMapper mapper = MapperProfile.CreateConfig();
    public ReservationServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ReservationDto?> GetById(int id)
    {
        var result = await _unitOfWork.Reservations.GetById(id);
        ReservationDto? dto = mapper.Map<ReservationDto>(result);
        return dto;
    }
    public  IEnumerable<ReservationDto> GetByGuestId(int guestId)
    {
        var result =  _unitOfWork.Reservations.GetAll(reservation => reservation.GuestId == guestId);
        IEnumerable<ReservationDto> data = mapper.Map<IEnumerable<ReservationDto>>(result);
        return data;
    }

    public IEnumerable<ReservationDto> GetAllReservations(DateTime? checkInDate, DateTime? checkOutDate, int page = 10, int size = 1)
    {
        Expression<Func<Reservation, bool>>? expression = null;
        if (checkInDate is not null)
        {
            expression = reservation => reservation.CheckInDate.Date == checkInDate.Value.Date;
        }else if (checkOutDate is not null)
        {
            expression = reservation => reservation.CheckOutDate.Date == checkOutDate.Value.Date;
        }else if (checkInDate is not null && checkOutDate is not null)
        {
            expression =reservation => reservation.CheckOutDate.Date == checkOutDate.Value.Date && reservation.CheckInDate.Date == checkInDate.Value.Date;
        }
            
        var data = _unitOfWork.Reservations.GetAll(expression);
        IEnumerable<ReservationDto> results = mapper.Map<IEnumerable<ReservationDto>>(data);
        return results;
    }

    public async Task<ReservationDto?> Reserve(ReserveDto dto)
    {
        DateTime checkIn = dto.CheckInDate;
        DateTime checkOut = dto.CheckOutDate;
        var room = await _unitOfWork.Rooms.GetById(dto.RoomId);
        if (room is not null)
        {
             var roomPricePerNight = room.PricePerNight;
             var totalCost = calculateTotalPrice(checkIn, checkOut, roomPricePerNight);


             Reservation reservation = mapper.Map<Reservation>(dto);
             reservation.TotalCost = totalCost;
             var res =await _unitOfWork.Reservations.CreateOne(reservation);
             if (res is not null)
             {
                 room.IsAvailable = false;
                 _unitOfWork.Complete();
                 ReservationDto? result = mapper.Map<ReservationDto>(res);

                 return result;
             }

             return null;
        }
        return null;

    }

    public async Task<bool> DeleteReservation(int id)
    {
        Reservation? reservation = await _unitOfWork.Reservations.GetById(id);
        if (reservation is not null)
        {
          var room = await _unitOfWork.Rooms.GetById(reservation.RoomId);
          if (room is not null)
              room.IsAvailable = true;
          _unitOfWork.Reservations.DeleteOne(id);
          _unitOfWork.Complete();
          return true;
        }
        return false;
    }

    private decimal calculateTotalPrice(DateTime checkIn , DateTime checkOut, decimal pricePerNight)
    {
        var diff = checkIn.Subtract(checkOut);
        var days = diff.Days;
        return Math.Abs(days * pricePerNight);
    }

    private bool compareDates(DateTime dbDate , DateTime userDate)
    {
        return dbDate.Date == userDate.Date;
    }
}