using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface ICartItemRepository
    {
        List<CartItemVM> GetAll();
        List<CartItemVM> GetByUserId(int id);
        List<CartItemVM> GetByProductId(int id);
        CartItemVM Add(CartItemModel item);
        void Update(CartItemModel item);
        void Delete(int userid, int productid);
    }
}
