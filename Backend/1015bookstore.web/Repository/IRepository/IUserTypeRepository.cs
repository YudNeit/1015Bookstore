using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface IUserTypeRepository
    {
        List<UserTypeVM> GetAll();
        UserTypeVM GetById(int id);
        UserTypeVM Add(int userid, UserTypeModel user);
        void Update(int id, int userid, UserTypeModel user);
        void Delete(int id);
    }
}
