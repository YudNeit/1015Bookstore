using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetById(int id);
        CategoryVM Add(int userid, CategoryModel cate);
        void Update(int id, int userid, CategoryModel cate);
        void Delete(int id);
        List<ListOfCategoryVM> GetFull();
        ListOfCategoryVM GetFullById(int id);
    }
}
