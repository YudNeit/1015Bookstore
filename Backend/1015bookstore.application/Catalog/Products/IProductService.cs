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
        Task<ResponseService<ProductViewModel>> Create(ProductCreateRequest request);
        Task<ResponseService> Update(ProductUpdateRequest request);
        Task<int> Delete(int id);
        Task<ResponseService<ProductViewModel>> GetById(int id);
        Task<ResponseService> UpdatePrice(int id, decimal newPrice);
        Task<ResponseService> UpdataQuanity(int id, int addedQuantity);
        Task AddViewcount(int id);
        Task<PagedResult<ProductViewModel>> GetProductByKeyWordPaging(GetProductByKeyWordPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
        Task<PagedResult<ProductViewModel>> GetProductByCategoryId(GetProductByCategoryPagingRequest request);
    }
}
