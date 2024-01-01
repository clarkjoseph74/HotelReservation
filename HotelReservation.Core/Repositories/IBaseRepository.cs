using System.Linq.Expressions;

namespace HotelReservation.Core.Repositories;

public interface IBaseRepository<T> where T : class
{

    Task<T?> GetById(int id);
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? criteria = null, int page =1, int size = 10);
    Task<T?> CreateOne(T entity);
    T UpdateOne(T entity);
    bool DeleteOne(int id);
    

}