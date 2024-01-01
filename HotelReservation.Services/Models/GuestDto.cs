namespace HotelReservation.Services.Models;

public class GuestDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string? FullName { get; set; }
}