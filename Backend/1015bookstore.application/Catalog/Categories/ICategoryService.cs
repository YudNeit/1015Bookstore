using _1015bookstore.viewmodel.Catalog.Categories;
using _1015bookstore.viewmodel.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<ResponseService<CategoryViewModel>> Cate_Create(CategoryCreateRequest request, Guid? creator_id);

        Task<ResponseService> Cate_Update(CategoryUpdateRequest request, Guid? updater_id);

        Task<ResponseService> Cate_Delete(int id, Guid? updater_id);

        //Task<List<CategoryViewModel>> Cate_GetAll();

        //Task<CategoryViewModel> Cate_GetById(int id);

        Task<ResponseService<List<CategoryParentAndChildViewModel>>> Cate_GetAll();

        Task<ResponseService> Cate_ChangeParent(int id, int parent_id, Guid? updater_id);

        Task<ResponseService<List<CategoryViewModel>>> Cate_GetParent();

        Task<ResponseService<List<CategoryParentAndChildViewModel>>> Cate_GetTaskbar();

        //Task<CategoryParentAndChildViewModel> Cate_GetParentAndChildById(int id);
        Task<ResponseService<List<CategoryViewModel>>> Cate_GetAddCate(int id);
        Task<ResponseService<CategoryViewModel>> Cate_GetById(int id);
    }
}
