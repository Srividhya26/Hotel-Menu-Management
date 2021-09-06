using Hotel_menu.Models;
using Hotel_menu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_menu.Repository
{
    public interface IOrderRepository : IMenuRepository<Order>
    {

    }
}
