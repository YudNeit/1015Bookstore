using _1015bookstore.viewmodel.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<int> Create(CategoryCreateRequest request);

        Task<int> Update(CategoryUpdateRequest request);

        Task<int> Delete(int id);

        Task<List<CategoryViewModel>> GetAll();

        Task<CategoryViewModel> GetById(int id);

        Task<List<CategoryParentAndChildViewModel>> GetParentAndChildAll();

        Task<CategoryParentAndChildViewModel> GetParentAndChildById(int id);
    }
}
