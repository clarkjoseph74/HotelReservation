using HotelReservation.Services.Interfaces;
using HotelReservation.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestServices _guestServices;

        public GuestsController(IGuestServices guestServices)
        {
            _guestServices = guestServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var guest = await _guestServices.GetById(id);
            if (guest is null)
            {
                return NotFound(guest);
            }

            return Ok(guest);
        }
        [HttpGet]
        public  IActionResult GetGuests(string? search , int page, int size)
        {
            var guest = _guestServices.GetAllGuests(search , page , size);
            return Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest(GuestCreateDto dto)
        {
            var guest = await _guestServices.CreateGuest(dto);
            if (guest is null)
            {
                return BadRequest("Error while creating the guest");
            }

            return Ok(guest);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var result = _guestServices.DeleteGuest(id);
            if (!result)
            {
                return BadRequest("Error while deleting the guest");
            }

            return Ok("The guest deleted successfully");
        }
    }
}
