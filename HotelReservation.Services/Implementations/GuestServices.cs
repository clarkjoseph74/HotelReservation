using System.Linq.Expressions;
using AutoMapper;
using HotelReservation.Core.Models;
using HotelReservation.Core.Repositories;
using HotelReservation.Services.Interfaces;
using HotelReservation.Services.Models;

namespace HotelReservation.Services.Implementations;

public class GuestServices : IGuestServices
{
    private readonly IUnitOfWork _unitOfWork;
    IMapper mapper = MapperProfile.CreateConfig();
    public GuestServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GuestDto?> GetById(int id)
    {
        var guest = await _unitOfWork.Guests.GetById(id);
        var dto = mapper.Map<GuestDto>(guest);
        return dto;
    }

    public IEnumerable<GuestDto> GetAllGuests(string? name, int page = 10, int size = 1)
    {
        Expression<Func<Guest, bool>>? expression = null;
        if (name is not null)
            expression = guest => guest.FullName.Contains(name); 

        var guests =  _unitOfWork.Guests.GetAll(expression, page, size);
        var dtos = mapper.Map<IEnumerable<GuestDto>>(guests);
        return dtos;
    }

    public async Task<GuestDto?> CreateGuest(GuestCreateDto dto)
    {
        Guest guest = mapper.Map<Guest>(dto);
        var result = await _unitOfWork.Guests.CreateOne(guest);
        if (result is not null)
        {
            _unitOfWork.Complete();
        }
        GuestDto guestDto = mapper.Map<GuestDto>(result);

        return guestDto;
    }

    public bool DeleteGuest(int id)
    {
       var result =  _unitOfWork.Guests.DeleteOne(id);
       if (result)
       {
           _unitOfWork.Complete();
       }

       return result;
    }
}