using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface IUserRepository
    {
        List<UserVM> GetAll();
        UserVM GetById(int id);
        UserVM Add(UserModel user);
        void Update(int id, UserModel user);
        void Delete(int id);
    }
}
