using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface ITypedCategories_PromotionalsRepository
    {
        List<TypedCategories_PromotionalsVM> GetAll();
        List<TypedCategories_PromotionalsVM> GetByCategoryId(int id);
        List<TypedCategories_PromotionalsVM> GetByPromotionalId(int id);
        TypedCategories_PromotionalsVM Add(TypedCategories_PromotionalsModel item);
        void Update(TypedCategories_PromotionalsModel item);
        void Delete(int categoryid, int promotionalid);
    }
}
