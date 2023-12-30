using _1015bookstore.viewmodel.Catalog.Carts;
using _1015bookstore.viewmodel.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Carts
{
    public interface ICartService
    {
        Task<ResponseService> Cart_SetProduct(CartAddProduct product, Guid user_id);
        Task<ResponseService> Cart_DeleteProduct(int cart_id);
        Task<ResponseService<List<CartViewModel>>> Cart_GetCart(Guid user_id);
        Task<ResponseService> Cart_UpdateAmount(int cart_id, int product_amount);
    }
}
