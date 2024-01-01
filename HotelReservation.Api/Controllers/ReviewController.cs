using HotelReservation.Services.Interfaces;
using HotelReservation.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;

        public ReviewController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }

        [HttpGet("{roomId}")]
        public IActionResult GetRoomReviews(int roomId)
        {
            return Ok(_reviewServices.GetRoomReviews(roomId));
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewCreateDto dto)
        {
           var result = await _reviewServices.AddRoomReview(dto);
           if (result is null)
           {
               return BadRequest("Error while adding the review");
           }

           return Ok(result);
        }
    }
}
