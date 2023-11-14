using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository
{
    public class TypedCategories_PromotionalsRepository: ITypedCategories_PromotionalsRepository
    {
        private readonly MyDbContext dbcontext;

        public TypedCategories_PromotionalsRepository(MyDbContext _dbcontext) 
        {
            dbcontext = _dbcontext;
        }

        public TypedCategories_PromotionalsVM Add(TypedCategories_PromotionalsModel item)
        {
            var _item = new TypedCategories_Promotionals
            {
                category_id = item.category_id,
                promotional_id = item.promotional_id,
                expirationdate = item.expirationdate,
            };
            dbcontext.Add(_item);
            dbcontext.SaveChanges();
            return new TypedCategories_PromotionalsVM
            {
                category_id = _item.category_id,
                promotional_id = _item.promotional_id,
                expirationdate = _item.expirationdate,
            };
        }

        public void Delete(int categoryid, int promotionalid)
        {
            var item = dbcontext.typedCategories_Promotionals.Single (h => h.category_id == categoryid && h.promotional_id == promotionalid);
            if (item != null)
            {
                dbcontext.Remove(item);
                dbcontext.SaveChanges();
            }
        }

        public List<TypedCategories_PromotionalsVM> GetAll()
        {
            var item = dbcontext.typedCategories_Promotionals.Select(e => new TypedCategories_PromotionalsVM
            {
                category_id = e.category_id,
                promotional_id = e.promotional_id,
                expirationdate = e.expirationdate,
            });
            return item.ToList();
        }

        public List<TypedCategories_PromotionalsVM> GetByCategoryId(int categoryid)
        {
            var item = dbcontext.typedCategories_Promotionals.Where(i => i.category_id == categoryid).Select(e => new TypedCategories_PromotionalsVM
            {
                category_id = e.category_id,
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

        public List<TypedCategories_PromotionalsVM> GetByPromotionalId(int Promotionalid)
        {
            var item = dbcontext.typedCategories_Promotionals.Where(i => i.promotional_id == Promotionalid).Select(e => new TypedCategories_PromotionalsVM
            {
                category_id = e.category_id,
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

        public void Update(TypedCategories_PromotionalsModel item)
        {
            var _item = dbcontext.typedCategories_Promotionals.SingleOrDefault(c => c.category_id == item.category_id && c.promotional_id == item.promotional_id);
            if (item != null)
            {
                _item.expirationdate = item.expirationdate;
                dbcontext.SaveChanges();
            }
        }
    }
}
