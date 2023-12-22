using _1015bookstore.viewmodel.Catalog.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Orders
{
    public interface IOrderService
    {
        Task<int> CreateOrder(OrderCreateRequest request);
        Task<OrderViewModel> GetById(int id);
        Task<bool> Buy(OrderBuyRequest request);
            
    }
}
