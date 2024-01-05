using _1015bookstore.viewmodel.Catalog.Categories;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;

namespace _1015bookstore.websiteadmin.Service
{
    public interface ICategoryAPIClient
    {
        Task<ResponseAPI<List<CategoryParentAndChildViewModel>>> GetCate(string session);
        Task<ResponseAPI<string>> ChangeParent(string session, int id, int parent_id, Guid updater_id);
         Task<ResponseAPI<List<CategoryViewModel>>> GetAddCate(string session, int id);
        Task<ResponseAPI<CategoryViewModel>> GetById(string session, int id);
        Task<ResponseAPI<List<ProductViewModel>>> GetProductByCate(string session, int id);
        Task<ResponseAPI<string>> DeleteProductInCate(string session, int id_cate, int id_product);
        Task<ResponseAPI<string>> SetProductInCate(string session, int id_cate, int id_product);
        Task<ResponseAPI<List<ProductViewModel>>> GetProductNotInCate(string session, int id);
        Task<ResponseAPI<List<CategoryViewModel>>> GetCateParent(string session);

        Task<ResponseAPI<string>> CreateCate(string session, CategoryCreateRequest request, Guid? gUser_id);
        Task<ResponseAPI<string>> UpdateCate(string session, CategoryUpdateRequest request, Guid? gUser_id);
    }
}
