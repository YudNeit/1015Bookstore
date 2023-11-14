using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly MyDbContext dbcontext;

        public ProductDetailRepository(MyDbContext _dbcontext) 
        {
            dbcontext = _dbcontext;
        }

        public ProductDetailVM Add(ProductDetailModel item)
        {
            var _item = new ProductDetail
            {
                product_id = item.product_id,
                brand = item.brand,
                suppiler = item.suppiler,
                author = item.author,
            };
            dbcontext.Add(_item);
            dbcontext.SaveChanges();
            return new ProductDetailVM
            {
                product_id = _item.product_id,
                brand = _item.brand,
                suppiler = _item.suppiler,
                author = _item.author,
            };
        }

        public void Delete(int productid)
        {
            var item = dbcontext.ProductDetails.Single(h => h.product_id == productid);
            if (item != null)
            {
                dbcontext.Remove(item);
                dbcontext.SaveChanges();
            }
        }

        public List<ProductDetailVM> GetAll()
        {
            var item = dbcontext.ProductDetails.Select(e => new ProductDetailVM
            {
                product_id = e.product_id,
                brand = e.brand,
                suppiler = e.suppiler,
                author = e.author,
            });
            return item.ToList();
        }

        public List<ProductDetailVM> GetByProductId(int productid)
        {
            var item = dbcontext.ProductDetails.Where(i => i.product_id == productid).Select(e => new ProductDetailVM
            {
                product_id = e.product_id,
                brand = e.brand,
                suppiler = e.suppiler,
                author = e.author,
            });
            if (item.Count() != 0)
            {
                return item.ToList();
            }
            else
                return null;
        }

        public void Update(ProductDetailModel item)
        {
            var _item = dbcontext.ProductDetails.SingleOrDefault(c =>  c.product_id == item.product_id);
            if (item != null)
            {
                _item.brand = item.brand;
                _item.suppiler = item.suppiler;
                _item.author = item.author;
                dbcontext.SaveChanges();
            }
        }
    }
}
