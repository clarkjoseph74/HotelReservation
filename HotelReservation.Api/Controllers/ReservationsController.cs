using HotelReservation.Services.Interfaces;
using HotelReservation.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationServices _reservationServices;

        public ReservationsController(IReservationServices reservationServices)
        {
            _reservationServices = reservationServices;
        }

        [HttpGet]
        public IActionResult GetAll(int page, int size ,DateTime? checkInDate , DateTime? checkOutDate)
        {
            var res = _reservationServices.GetAllReservations(checkInDate , checkOutDate , page , size);
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _reservationServices.GetById(id);
            if (res is null)
            {
                return NotFound("Reservation Not Found");
            }
            return Ok(res);
        }

        [HttpGet("Guest/{id}")]
        public IActionResult GetByGuestId(int id)
        {
            var res = _reservationServices.GetByGuestId(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(ReserveDto dto)
        {
           var res = await _reservationServices.Reserve(dto);
           return Ok(res);
        }
        [HttpDelete("{resId}")]
        public async Task<IActionResult> Reserve(int resId)
        {
            var isDeleted = await _reservationServices.DeleteReservation(resId);
            if (!isDeleted)
            {
                return BadRequest("Error while deleting the reservation");
            }
            return Ok(isDeleted);
        }
    }
}
