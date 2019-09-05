using Microsoft.EntityFrameworkCore;
using OurGames.Core.CRUD;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurGames.Repository
{
    public abstract class AbstractRepository<T> : ICrud<T> where T : class
    {
        protected readonly OurGamesContext db;
        public abstract T GetById(int id);
        public abstract IEnumerable<T> GetAll();

        public AbstractRepository(DbContextOptions<OurGamesContext> contextOptions)
        {
            db = new OurGamesContext(contextOptions); 
        }

        public virtual T Create(T entity)
        {
            db.Add(entity);

            db.SaveChanges();
           
            return entity;
        }

        public virtual bool DeleteById(int id)
        {
            db.Remove(GetById(id));

            return db.SaveChanges() > 0;
        }


        public virtual T Update(T entity)
        {
            db.Update(entity);

            db.SaveChanges();

            return entity;
        }

        public virtual bool Delete(T entity)
        {
            db.Remove(entity);

            return db.SaveChanges() > 0;
        }

    }
}
