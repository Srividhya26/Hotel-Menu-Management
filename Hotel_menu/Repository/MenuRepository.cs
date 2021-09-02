using Hotel_menu.Data;
using Hotel_menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Repository
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        private readonly MyDbContext _db;
        public MenuRepository(MyDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Menu menu)
        {
            _db.Update(menu);              
        }

    }
}
