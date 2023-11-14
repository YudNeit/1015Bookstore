using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Data;
using _1015bookstore.web.Model;
using _1015bookstore.web.ViewModel;
using _1015bookstore.web.Repository.IRepository;

namespace _1015bookstore.web.Repository
{
    public class TypedProducts_PromotionalsRepository : ITypedProducts_PromotionalsRepository
    {
        private readonly MyDbContext dbcontext;

        public TypedProducts_PromotionalsRepository(MyDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public TypedProducts_PromotionalsVM Add(TypedProducts_PromotionalsModel item)
        {
            var _item = new TypedProducts_Promotionals
            {
                product_id = item.product_id,
                promotional_id = item.promotional_id,
                expirationdate = item.expirationdate,
            };
            dbcontext.Add(_item);
            dbcontext.SaveChanges();
            return new TypedProducts_PromotionalsVM
            {
                product_id = _item.product_id,
                promotional_id = _item.promotional_id,
                expirationdate = _item.expirationdate,
            };
        }

        public void Delete(int productid, int promotionalid)
        {
            var item = dbcontext.typedProducts_Promotionals.Single(h => h.product_id == productid && h.promotional_id == promotionalid);
            if (item != null)
            {
                dbcontext.Remove(item);
                dbcontext.SaveChanges();
            }
        }

        public List<TypedProducts_PromotionalsVM> GetAll()
        {
            var item = dbcontext.typedProducts_Promotionals.Select(e => new TypedProducts_PromotionalsVM
            {
                product_id = e.product_id,
                promotional_id = e.promotional_id,
                expirationdate = e.expirationdate,
            });
            return item.ToList();
        }

        public List<TypedProducts_PromotionalsVM> GetByProductId(int id)
        {
            var item = dbcontext.typedProducts_Promotionals.Where(i => i.product_id == id).Select(e => new TypedProducts_PromotionalsVM
            {
                product_id = e.product_id,
                promotional_id = e.promotional_id,
                expirationdate = e.expirationdate,
            });
            if (item.Count() != 0)
            {
                return item.ToList();
            }
            else
                return null;
        }

        public List<TypedProducts_PromotionalsVM> GetByPromotionalId(int id)
        {
            var item = dbcontext.typedProducts_Promotionals.Where(i => i.promotional_id == id).Select(e => new TypedProducts_PromotionalsVM
            {
                product_id = e.product_id,
                promotional_id = e.promotional_id,
                expirationdate = e.expirationdate,
            });
            if (item.Count() != 0)
            {
                return item.ToList();
            }
            else
                return null;
        }

        public void Update(TypedProducts_PromotionalsModel item)
        {
            var _item = dbcontext.typedProducts_Promotionals.SingleOrDefault(c => c.product_id == item.product_id && c.promotional_id == item.promotional_id);
            if (item != null)
            {
                _item.expirationdate = item.expirationdate;
                dbcontext.SaveChanges();
            }
        }
    }
}
