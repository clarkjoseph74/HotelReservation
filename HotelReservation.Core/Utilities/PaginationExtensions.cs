using HotelReservation.Core.Models;

namespace HotelReservation.Core.Utilities;

public static class PaginationExtensions
{
    public static PaginateResult<T> Paginate<T>(this IEnumerable<T> source , int page =1, int size = 10) where T : class {
        if(page <= 0)
        {
            page = 1;
        }
        if(size <= 0)
        {
            size = 10;
        }
        int total = source.Count();
        var totalPages = (int) Math.Ceiling((decimal)total / size);
        var result = source.Skip((page - 1) * size).Take(size).ToList();
        PaginateResult<T> results = new PaginateResult<T> { Result = result, TotalPages = totalPages };
        return results;
    }
}