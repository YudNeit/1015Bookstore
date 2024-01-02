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
        Task<ResponseService<OrderViewModel>> Order_Create(OrderCreateRequest request);
        Task<ResponseService> Order_Buy(OrderBuyRequest request);
        Task<ResponseService<List<OrderViewModel>>> Order_HistoryOfUser(Guid user_id);

        Task<ResponseService<OrderViewModel>> Order_GetById(int iOrder_id);
    }
}
