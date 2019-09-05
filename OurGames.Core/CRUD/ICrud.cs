using System;
using System.Collections.Generic;
using System.Text;

namespace OurGames.Core.CRUD
{
    public interface ICrud<T> where T: class
    {
        T Create(T entity);
        T Update(T entity);
        bool DeleteById(int id);
        T GetById(int id);
    }
}
