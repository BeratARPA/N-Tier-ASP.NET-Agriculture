using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class, new()
    {
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        T GetById(int id);
        List<T> GetAll();
    }
}
