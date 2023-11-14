using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface IProductDetailRepository
    {
        List<ProductDetailVM> GetAll();
        List<ProductDetailVM> GetByProductId(int productid);
        ProductDetailVM Add(ProductDetailModel item);
        void Update(ProductDetailModel item);
        void Delete(int productid);
    }
}
