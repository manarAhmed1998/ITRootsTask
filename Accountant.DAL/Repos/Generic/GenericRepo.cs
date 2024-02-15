using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly AccountantContext _context;

    public GenericRepo(AccountantContext context)
    {
        _context = context;

    }
    public void Add(T obj)
    {
        _context.Add(obj);
    }

    public void Delete(T obj)
    {
        _context.Remove(obj);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public T? GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    
}
