using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.Models;

public class Review
{
    [Key]
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }

    public virtual Room? Room { get; set; }
}