using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface ITypedUsers_PromotionalsRepository
    {
        List<TypedUsers_PromotionalsVM> GetAll();
        List<TypedUsers_PromotionalsVM> GetByUserId(int id);
        List<TypedUsers_PromotionalsVM> GetByPromotionalId(int id);
        TypedUsers_PromotionalsVM Add(TypedUsers_PromotionalsModel item);
        void Update(TypedUsers_PromotionalsModel item);
        void Delete(int userid, int promotionalid);
    }
}
