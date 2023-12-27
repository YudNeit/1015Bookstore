using _1015bookstore.viewmodel.Catalog.Orders;
using _1015bookstore.viewmodel.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Orders
{
    public interface IOrderService
    {
        Task<ResponseService<OrderViewModel>> CreateOrder(OrderCreateRequest request);
        Task<ResponseService<OrderViewModel>> GetById(int id);
        Task<ResponseService> Buy(OrderBuyRequest request);
            
    }
}
