using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface ITypedUsers_UserTypesRepository
    {
        List<TypedUsers_UserTypesVM> GetAll();
        List<TypedUsers_UserTypesVM> GetByUserTypeId(int id);
        List<TypedUsers_UserTypesVM> GetByUserId(int id);
        TypedUsers_UserTypesVM Add(TypedUsers_UserTypesModel item);
        void Update(TypedUsers_UserTypesModel item);
        void Delete(int usertypeid, int userid);
    }
}
