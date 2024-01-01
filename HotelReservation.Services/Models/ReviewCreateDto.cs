using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Services.Models;

public class ReviewCreateDto
{
    [Required]
    public int RoomId { get; set; }
    [Required]
    public int Rating { get; set; }
    public string? Comment { get; set; }

}