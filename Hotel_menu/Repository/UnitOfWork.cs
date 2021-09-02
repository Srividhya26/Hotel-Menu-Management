using Hotel_menu.Data;
using Hotel_menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _db;
        private IRepository<Menu> _menu;
        public UnitOfWork(MyDbContext db)
        {
            _db = db;
        }

        public IRepository<Menu> menus => _menu ??= new Repository<Menu>(_db);

        public void Dispose()
        {
            _db.Dispose();
        }

        public void save()
        {
            _db.SaveChanges();
        }
    }
}
