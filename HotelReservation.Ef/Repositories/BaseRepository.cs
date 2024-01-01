using System.Linq.Expressions;
using HotelReservation.Core.Models;
using HotelReservation.Core.Repositories;
using HotelReservation.Core.Utilities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Ef.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? criteria = null, int page =1, int size = 10)
    {
        PaginateResult<T> query = _context.Set<T>().Paginate(page,size);
        if (criteria is not null)
            query = _context.Set<T>().Where(criteria).Paginate(page,size);
        IEnumerable<T> itemList = query.Result;
        
        return  itemList;
    }
    
    public async Task<T?> CreateOne(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public T UpdateOne(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }

    public bool DeleteOne(int id)
    {
        var itemToDelete = _context.Set<T>().Find(id);
        if(itemToDelete != null)
        {
            _context.Set<T>().Remove(itemToDelete);
            return true;
        }
        return false;
        
    }
}