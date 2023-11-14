using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface IProductRepository
    {
        List<ProductVM> GetAll();
        ProductVM GetById(int id);
        ProductVM Add(int userid, ProductModel product);
        void Update(int id, int userid, ProductModel product);
        void Delete(int id);
    }
}
