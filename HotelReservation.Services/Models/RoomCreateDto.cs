using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Services.Models;

public class RoomCreateDto
{
    [Required, MaxLength(100)] public string RoomType { get; set; } = default!;
    [Required]
    public decimal PricePerNight { get; set; }
    [Required]
    public int  MaxOccupancy { get; set; } 
}