using HotelReservation.Core.Models;

namespace HotelReservation.Services.Models;

public class RoomReviews
{
    public IEnumerable<ReviewDto> Reviews { get; set; }
    public double AverageRating { get; set; }
}