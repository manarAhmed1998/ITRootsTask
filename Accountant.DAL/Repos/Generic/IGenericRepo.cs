using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public interface IGenericRepo<T> where T:class
{
    public IEnumerable<T> GetAll();
    public T? GetById(Guid id);
    void Add(T obj);
}
