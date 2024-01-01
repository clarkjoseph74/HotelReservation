namespace HotelReservation.Services.Models;

public class ReviewDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}