using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Abstract;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;
using Microsoft.VisualBasic;

namespace _1015bookstore.web.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly MyDbContext dbcontext;

        public ReviewRepository(MyDbContext _dbcontext) 
        {
            dbcontext = _dbcontext;
        }

        public ReviewVM Add(ReviewModel model)
        {
            var _review = new Review
            {
                user_id = model.user_id,
                product_id = model.product_id,
                starts = model.starts,
                contents = model.contents,
            };
            dbcontext.Add(_review);
            dbcontext.SaveChanges();
            return new ReviewVM
            {
                id = _review.id,
                user_id = _review.user_id,
                product_id = _review.product_id,
                starts = _review.starts,
                contents = _review.contents,
            };
        }

        public void Delete(int id)
        {
            var review = dbcontext.Reviews.SingleOrDefault(x => x.id == id);
            if (review != null)
            {
                dbcontext.Remove(review);
                dbcontext.SaveChanges();
            }
        }

        public List<ReviewVM> GetAll()
        {
            var reviews = dbcontext.Reviews.Select(x => new ReviewVM
            {
                id = x.id,
                user_id = x.user_id,
                product_id = x.product_id,
                starts = x.starts,
                contents = x.contents,
            });
            return reviews.ToList();
        }

        public ReviewVM GetById(int id)
        {
            var user = dbcontext.Reviews.SingleOrDefault(x => x.id == id);
            if (user != null)
            {
                return new ReviewVM
                {
                    id = user.id,
                    user_id = user.user_id,
                    product_id = user.product_id,
                    starts = user.starts,
                    contents = user.contents,
                };
            }
            else
                return null;
        }
    }
}
