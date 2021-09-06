using Hotel_menu.Data;
using Hotel_menu.Models;
using Hotel_menu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Repository
{
    public class OrderRepository : Repository<Order>,IOrderRepository
    {
        private readonly MyDbContext _db;
        public OrderRepository(MyDbContext db) : base(db)

        {
            _db = db;
        }
    }
}
