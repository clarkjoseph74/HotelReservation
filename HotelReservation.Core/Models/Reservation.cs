using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Core.Models;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(Room))]
    public int RoomId { get; set; }
    [ForeignKey(nameof(Guest))]
    public int GuestId { get; set; }
    public decimal TotalCost { get; set; }
    [Required]
    public int GuestsNum { get; set; }
    [Required]

    public DateTime CheckInDate { get; set; }
    [Required]
    public DateTime CheckOutDate { get; set; }

    public bool IsPaid { get; set; } = false;

    public virtual Room? Room { get; set; }
    public virtual Guest? Guest { get; set; }
}