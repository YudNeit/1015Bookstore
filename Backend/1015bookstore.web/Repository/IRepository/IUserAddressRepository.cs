using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface IUserAddressRepository
    {
        List<UserAddressVM> GetAll();
        UserAddressVM GetById(int id);
        List<UserAddressVM> GetByUserId(int userId);
        UserAddressVM Add(UserAddressModel address);
        void Update(int id, UserAddressModel address);
        void Delete(int id);
    }
}
