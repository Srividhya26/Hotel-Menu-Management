using Hotel_menu.Data;
using Hotel_menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Repository
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly MyDbContext _db;

        public Repository(MyDbContext db)
        {
            _db = db;
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public void Add(T entity)
        {
           _db.Set<T>().Add(entity);            
        }

        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

    }
}
