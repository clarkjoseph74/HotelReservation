namespace HotelReservation.Core.Models;

public class PaginateResult<T> where T : class
{
    public List<T> Result { get; set; }
    public int TotalPages { get; set; }
}