namespace HotelReservation.Services.Models;

public class ReservationDto
{
    
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
    public decimal TotalCost { get; set; }
    public int GuestsNum { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public bool IsPaid { get; set; } = false;
    
}