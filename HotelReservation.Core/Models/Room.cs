using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.Models;

public class Room
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)] public string RoomType { get; set; } = default!;
    [Required]
    public decimal PricePerNight { get; set; }
    [Required]
    public int  MaxOccupancy { get; set; }

    public bool IsAvailable { get; set; } = true;
    
}