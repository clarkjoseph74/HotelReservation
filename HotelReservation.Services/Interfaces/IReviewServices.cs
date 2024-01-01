using HotelReservation.Core.Models;
using HotelReservation.Services.Models;

namespace HotelReservation.Services.Interfaces;

public interface IReviewServices
{
    RoomReviews GetRoomReviews( int roomId);
    Task<Review?> AddRoomReview(ReviewCreateDto dto);
}