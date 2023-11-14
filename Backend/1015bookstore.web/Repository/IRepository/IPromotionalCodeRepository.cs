using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface IPromotionalCodeRepository
    {
        List<PromotionalCodeVM> GetAll();
        PromotionalCodeVM GetById(int id);
        PromotionalCodeVM Add(int userid, PromotionalCodeModel user);
        void Update(int id, int userid, PromotionalCodeModel user);
        void Delete(int id);
    }
}
