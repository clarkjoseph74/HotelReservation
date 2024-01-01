
using HotelReservation.Services.Interfaces;
using HotelReservation.Services.Models;

using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomServices _roomServices;

        public RoomsController(IRoomServices roomServices)
        {
            _roomServices = roomServices;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _roomServices.GetById(id);
            if (res is null)
            {
                return NotFound("Reservation Not Found");
            }
            return Ok(res);
        }
        
        [HttpGet]
        public IActionResult GetAll(int? maxOccupancy= null, int page = 1, int size = 10)
        {
            return Ok(_roomServices.GetAllRooms(maxOccupancy,page,size));
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateDto dto)
        {
            var room = await _roomServices.CreateRoom(dto);
            if (room is null)
            {
                return BadRequest("Error While Creating the Room");
            }
            return Ok(room );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RoomCreateDto dto)
        {
            var room = _roomServices.UpdateRoom(id, dto);
            if (room is null)
            {
                return BadRequest("Error While Updating the Room");
            }
            return Ok(room );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _roomServices.DeleteRoom(id);
            if (!isDeleted)
            {
                return BadRequest("Error while Deleting this Room !");
            }

            return Ok("The Room is deleted successfully");
        }
    }
    
    
}
