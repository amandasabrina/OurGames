using System;
using System.Collections.Generic;
using System.Text;

namespace OurGames.Repository.Abstractions
{
    public interface ICrud<T> where T: class
    {
        T Create(T entity);
        T Update(T entity);
        T GetByKey(params object[] keyValues);
        IEnumerable<T> GetBy(Func<T, bool> func);

        bool DeleteByKey(params object[] keyValues);
        int DeleteBy(Func<T, bool> func);
        IEnumerable<T> GetAll();
    }
}
