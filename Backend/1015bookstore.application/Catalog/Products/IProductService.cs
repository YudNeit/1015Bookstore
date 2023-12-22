using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int id);
        Task<ProductViewModel> GetById(int id);
        Task<bool> UpdatePrice(int id, decimal newPrice);
        Task<bool> UpdataQuanity(int id, int addedQuantity);
        Task AddViewcount(int id);
        Task<PagedResult<ProductViewModel>> GetProductByKeyWordPaging(GetProductByKeyWordPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
        Task<PagedResult<ProductViewModel>> GetProductByCategoryId(GetProductByCategoryPagingRequest request);
    }
}
