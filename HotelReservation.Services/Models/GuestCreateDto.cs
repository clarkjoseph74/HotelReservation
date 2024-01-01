using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Services.Models;

public class GuestCreateDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
}