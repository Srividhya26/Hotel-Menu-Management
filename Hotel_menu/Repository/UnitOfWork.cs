using Hotel_menu.Data;
using Hotel_menu.Models;
using Hotel_menu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _db;
        private IMenuRepository<Menu> _menu;
        private IMenuRepository<Order> _order;
        
        public UnitOfWork(MyDbContext db)
        {
            _db = db;
        }


        public IMenuRepository<Menu> menus => _menu ??= new Repository<Menu>(_db);
        public IMenuRepository<Order> orders => _order ??= new Repository<Order>(_db);
        

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
