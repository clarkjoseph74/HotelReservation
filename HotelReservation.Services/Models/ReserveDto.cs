using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Services.Models;

public class ReserveDto
{
    [Required]
    public int RoomId { get; set; }
    [Required]
    public int GuestId { get; set; }
    [Required]
    public int GuestsNum { get; set; }
    [Required]
    public DateTime CheckInDate { get; set; }
    [Required]
    public DateTime CheckOutDate { get; set; }

    public bool IsPaid { get; set; } = false;
}