using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly MyDbContext dbcontext;

        public CartItemRepository(MyDbContext _dbcontext) 
        {
            dbcontext = _dbcontext;
        }
        public CartItemVM Add(CartItemModel item)
        {
            var _item = new CartItem {
                user_id = item.user_id,
                product_id = item.product_id,
                quantity = item.quantity,
                price = dbcontext.Products.Single(p => p.id == item.product_id).price * item.quantity,
            };
            dbcontext.Add(_item);
            dbcontext.SaveChanges();
            return new CartItemVM
            {
                user_id = _item.user_id,
                product_id = _item.product_id,
                quantity = _item.quantity,
                price = _item.price,
            };
        }

        public void Delete(int userid, int productid)
        {
            var item = dbcontext.CartItems.Single(h => h.user_id == userid && h.product_id == productid);
            if (item != null)
            {
                dbcontext.Remove(item);
                dbcontext.SaveChanges();
            }
        }

        public List<CartItemVM> GetAll()
        {
            var item = dbcontext.CartItems.Select(e => new CartItemVM
            {
                user_id = e.user_id,
                product_id = e.product_id,
                quantity = e.quantity,
                price = e.price,
            });
            return item.ToList();
        }

        public List<CartItemVM> GetByProductId(int productid)
        {
            var item = dbcontext.CartItems.Where(i => i.product_id == productid).Select(e => new CartItemVM {
                user_id = e.user_id,
                product_id = e.product_id,
                quantity = e.quantity,
                price = e.price,
            });
            if (item.Count() != 0)
            {
                return item.ToList();
            }
            else
                return null;
        }

        public List<CartItemVM> GetByUserId(int userid)
        {
            var item = dbcontext.CartItems.Where(i => i.user_id == userid).Select(e => new CartItemVM
            {
                user_id = e.user_id,
                product_id = e.product_id,
                quantity = e.quantity,
                price = e.price,
            });
            if (item.Count() != 0)
            {
                return item.ToList();
            }
            else
                return null;
        }

        public void Update(CartItemModel item)
        {
            var _item = dbcontext.CartItems.SingleOrDefault(c => c.user_id == item.user_id && c.product_id == item.product_id);
            if (item != null)
            {
                _item.quantity = item.quantity;
                dbcontext.SaveChanges();
            }
        }
    }
}
