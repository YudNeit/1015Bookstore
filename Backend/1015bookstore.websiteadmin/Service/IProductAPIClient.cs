using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;

namespace _1015bookstore.websiteadmin.Service
{
    public interface IProductAPIClient
    {
        Task<ResponseAPI<List<ProductViewModel>>> GetProduct(string session);
    }
}
