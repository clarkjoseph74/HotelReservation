using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Core.Models;

public class Guest
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public string? FullName { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
}