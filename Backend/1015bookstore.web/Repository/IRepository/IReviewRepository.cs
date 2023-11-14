using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface IReviewRepository
    {
        List<ReviewVM> GetAll();
        ReviewVM GetById(int id);
        ReviewVM Add(ReviewModel model);
        void Delete(int id);
    }
}
