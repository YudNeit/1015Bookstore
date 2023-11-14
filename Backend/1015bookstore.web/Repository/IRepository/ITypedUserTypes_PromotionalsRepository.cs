using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface ITypedUserTypes_PromotionalsRepository
    {
        List<TypedUserTypes_PromotionalsVM> GetAll();
        List<TypedUserTypes_PromotionalsVM> GetByUserTypeId(int id);
        List<TypedUserTypes_PromotionalsVM> GetByPromotionalId(int id);
        TypedUserTypes_PromotionalsVM Add(TypedUserTypes_PromotionalsModel item);
        void Update(TypedUserTypes_PromotionalsModel item);
        void Delete(int usertypeid, int promotionalid);
    }
}
