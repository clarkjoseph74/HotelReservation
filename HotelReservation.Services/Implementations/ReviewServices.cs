using AutoMapper;
using HotelReservation.Core.Models;
using HotelReservation.Core.Repositories;
using HotelReservation.Services.Interfaces;
using HotelReservation.Services.Models;

namespace HotelReservation.Services.Implementations;

public class ReviewServices : IReviewServices
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper = MapperProfile.CreateConfig();
    public ReviewServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public RoomReviews GetRoomReviews(int roomId)
    {
        var data =  _unitOfWork.Reviews.GetAll();
        var reviews = _mapper.Map<IEnumerable<ReviewDto>>(data);
        double average = reviews.Average(rev => rev.Rating);
        RoomReviews result = new RoomReviews()
        {
            Reviews = reviews,
            AverageRating = average
        };
        return result;

    }

    public async Task<Review?> AddRoomReview(ReviewCreateDto dto)
    {
        Review review = _mapper.Map<Review>(dto);
        var addedReview = await _unitOfWork.Reviews.CreateOne(review);
        _unitOfWork.Complete();
        return addedReview;
    }
}