using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface ITypedProducts_PromotionalsRepository
    {
        List<TypedProducts_PromotionalsVM> GetAll();
        List<TypedProducts_PromotionalsVM> GetByProductId(int id);
        List<TypedProducts_PromotionalsVM> GetByPromotionalId(int id);
        TypedProducts_PromotionalsVM Add(TypedProducts_PromotionalsModel item);
        void Update(TypedProducts_PromotionalsModel item);
        void Delete(int productid, int promotionalid);
    }
}
