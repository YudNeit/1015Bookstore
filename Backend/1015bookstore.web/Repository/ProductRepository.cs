using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Helper;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext dbcontext;

        public ProductRepository(MyDbContext _dbcontext) 
        {
            dbcontext = _dbcontext;
        }

        public ProductVM Add(int userid, ProductModel product)
        {
            string username = dbcontext.Users.Single(h => h.id == userid).username;
            var _product = new Product
            {
                name = product.name,
                alias = RemoveUnicode.Removeunicode(product.name),
                category_id = product.category_id,
                price = product.price,
                flashsale = product.flashsale,
                waranty = product.waranty,
                quanity = product.quanity,
                description = product.description,
                createdby = username,
                updatedby = username
            };
            dbcontext.Add(_product);
            dbcontext.SaveChanges();
            return new ProductVM
            {
                id = _product.id,
                name = _product.name,
                category_id = _product.category_id,
                price = _product.price,
                flashsale = _product.flashsale,
                waranty = _product.waranty,
                quanity = _product.quanity,
                description = _product.description,
            };
        }

        public void Delete(int id)
        {
            var product = dbcontext.Products.SingleOrDefault(p => p.id == id);
            if (product != null)
            {
                dbcontext.Remove(product);
                dbcontext.SaveChanges();
            }
        }

        
        public List<ProductVM> GetAll()
        {
            var product = dbcontext.Products.Select(e => new ProductVM
            {
                id = e.id,
                name = e.name,
                category_id = e.category_id,
                price = e.price,
                flashsale = e.flashsale,
                waranty = e.waranty,
                quanity = e.quanity,
                description = e.description,
            });
            return product.ToList();
        }

        public ProductVM GetById(int id)
        {
            var product = dbcontext.Products.SingleOrDefault(p => p.id == id);
            if (product != null)
            {
                return new ProductVM
                {
                    id = product.id,
                    name = product.name,
                    category_id = product.category_id,
                    price = product.price,
                    flashsale = product.flashsale,
                    waranty = product.waranty,
                    quanity = product.quanity,
                    description = product.description,
                };
            }
            else
                return null;
        }

        public void Update(int id, int userid, ProductModel user)
        {
            var _product = dbcontext.Products.SingleOrDefault(p => p.id == id);
            if (_product != null)
            {
                _product.name = _product.name;
                _product.category_id = _product.category_id;
                _product.price = _product.price;
                _product.flashsale = _product.flashsale;
                _product.waranty = _product.waranty;
                _product.quanity = _product.quanity;
                _product.description = _product.description;
                _product.updatedby = dbcontext.Users.Single(h => h.id == userid).username;
                _product.updatedtime = DateTime.Now;
                dbcontext.SaveChanges();
            }
        }
    }
}
