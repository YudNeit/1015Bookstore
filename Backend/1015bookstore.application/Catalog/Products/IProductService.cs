using _1015bookstore.viewmodel.Catalog.Categories;
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
        Task<ResponseService<ProductViewModel>> Product_Create(ProductCreateRequest request, Guid? creator_id);
        Task<ResponseService> Product_Delete(int id, Guid? updater_id);
        Task<ResponseService> Product_Update(ProductUpdateRequest request, Guid? updater_id);

        Task<ResponseService> Product_UpdateQuantity(int id, int addedQuantity, decimal price, Guid? updater_id);
        Task<ResponseService> Product_UpdatePrice(int id, decimal newPrice, Guid? updater_id);
        Task<ResponseService> Product_AddViewcount(int id);

        Task<ResponseService<ProductViewModel>> Product_GetById(int id);

        Task<PagedResult<ProductViewModel>> Product_GetProductByKeyWordPagingPublic(GetProductByKeyWordPagingRequest request);
        Task<PagedResult<ProductViewModel>> Product_GetProductByCategoryPagingPublic(GetProductByCategoryPagingRequest request);

        Task<PagedResult<ProductViewModel>> Product_GetProductByKeyWordPagingAdmin(GetProductByKeyWordPagingRequest request);
        Task<PagedResult<ProductViewModel>> Product_GetProductByCategoryPagingAdmin(GetProductByCategoryPagingRequest request);

        Task<ResponseService<List<ProductViewModel>>> Product_GetAllAdmin();
        Task<ResponseService<List<ProductViewModel>>> Product_GetAllPublic();
        Task<ResponseService<List<ProductViewModel>>> Product_GetProductByKeywordAllPublic(string? sKeyword);

        Task<ResponseService<List<ProductViewModel>>> Product_GetProductNotInCate(int cate_id);

        Task<ResponseService<List<CategoryViewModel>>> Product_GetCategory(int id);

    }
}
