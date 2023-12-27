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
        Task<ResponseService> SetProductInCart(ProductAdd productadd, Guid user_id);
        Task<ResponseService> DeleteProductInCart(int cart_id);
        Task<ResponseService<List<CartViewModel>>> GetCardOfUser(Guid user_id);
        Task<ResponseService> UpdateAmountCart(int cart_id, int amoutadd);
    }
}
