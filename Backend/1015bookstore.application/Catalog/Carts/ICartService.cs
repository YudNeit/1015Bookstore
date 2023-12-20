using _1015bookstore.viewmodel.Catalog.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Carts
{
    public interface ICartService
    {
        Task<int> SetProductInCart(ProductAdd productadd, Guid user_id);
        Task<int> DeleteProductInCart(int cart_id);
        Task<List<CartViewModel>> GetCardOfUser(Guid user_id);
        Task UpdateAmountCart(int cart_id, int amoutadd);
    }
}
