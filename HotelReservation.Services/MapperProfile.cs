using AutoMapper;
using HotelReservation.Core.Models;
using HotelReservation.Services.Models;

namespace HotelReservation.Services;

public static class MapperProfile
{
    public static IMapper CreateConfig()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Reservation, ReserveDto>().ReverseMap();
            cfg.CreateMap<Room, RoomCreateDto>().ReverseMap();
            cfg.CreateMap<Guest, GuestCreateDto>().ReverseMap();
            cfg.CreateMap<Guest, GuestDto>().ReverseMap();
            cfg.CreateMap<Reservation, ReservationDto>().ReverseMap();
            cfg.CreateMap<Review, ReviewCreateDto>().ReverseMap();
            cfg.CreateMap<Review, ReviewDto>().ReverseMap();
        });

        return config.CreateMapper();
    }
}