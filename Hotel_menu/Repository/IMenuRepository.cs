using Hotel_menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Repository
{
    public interface IMenuRepository : IMenuRepository<Menu>
    {
        public void Update(Menu menu);
    }
}
