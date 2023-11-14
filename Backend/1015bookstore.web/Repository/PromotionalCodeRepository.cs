using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Data;
using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.Helper;

namespace _1015bookstore.web.Repository
{
    public class PromotionalCodeRepository : IPromotionalCodeRepository
    {
        private readonly MyDbContext dbcontext;

        public PromotionalCodeRepository(MyDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public PromotionalCodeVM Add(int userid, PromotionalCodeModel promotion)
        {
            string username = dbcontext.Users.Single(h => h.id == userid).username;
            var _promotion = new PromotionalCode
            {
                name = promotion.name,
                alias = RemoveUnicode.Removeunicode(promotion.name),
                description = promotion.description,
                discount_rate = promotion.discount_rate,
                createdby = username,
                updatedby = username,
            };
            dbcontext.Add(_promotion);
            dbcontext.SaveChanges();
            return new PromotionalCodeVM
            {
                id = _promotion.id,
                name = _promotion.name,
                description = _promotion.description,
                discount_rate = _promotion.discount_rate,
            };
        }

        public void Delete(int id)
        {
            var promotion = dbcontext.PromotionalCodes.SingleOrDefault(p => p.id == id);
            if (promotion != null)
            {
                dbcontext.Remove(promotion);
                dbcontext.SaveChanges();
            }
        }

        public List<PromotionalCodeVM> GetAll()
        {
            var promotion = dbcontext.PromotionalCodes.Select(e => new PromotionalCodeVM
            {
                id = e.id,
                name = e.name,
                description = e.description,
                discount_rate = e.discount_rate,
            });
            return promotion.ToList();
        }

        public PromotionalCodeVM GetById(int id)
        {
            var promotion = dbcontext.PromotionalCodes.SingleOrDefault(e => e.id == id);
            if (promotion != null)
            {
                return new PromotionalCodeVM
                {
                    id = promotion.id,
                    name = promotion.name,
                    description = promotion.description,
                    discount_rate = promotion.discount_rate,
                };
            }
            else
                return null;
        }

        public void Update(int id, int userid, PromotionalCodeModel promotion)
        {
            var _promotion = dbcontext.PromotionalCodes.SingleOrDefault(p => p.id == id);
            if (_promotion != null)
            {
                _promotion.name = promotion.name;
                _promotion.description = promotion.description;
                _promotion.discount_rate = promotion.discount_rate;
                _promotion.updatedby = dbcontext.Users.Single(h => h.id == userid).username;
                _promotion.updatedtime = DateTime.Now;
                dbcontext.SaveChanges();
            }
        }
    }
}
