using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository
{
    public class TypedUsers_PromotionalsRepository : ITypedUsers_PromotionalsRepository
    {
        private readonly MyDbContext dbcontext;

        public TypedUsers_PromotionalsRepository(MyDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public TypedUsers_PromotionalsVM Add(TypedUsers_PromotionalsModel item)
        {
            var _item = new TypedUsers_Promotionals
            {
                user_id = item.user_id,
                promotional_id = item.promotional_id,
                expirationdate = item.expirationdate,
            };
            dbcontext.Add(_item);
            dbcontext.SaveChanges();
            return new TypedUsers_PromotionalsVM
            {
                user_id = _item.user_id,
                promotional_id = _item.promotional_id,
                expirationdate = _item.expirationdate,
            };
        }

        public void Delete(int userid, int promotionalid)
        {
            var item = dbcontext.typedUsers_Promotionals.Single(h => h.user_id == userid && h.promotional_id == promotionalid);
            if (item != null)
            {
                dbcontext.Remove(item);
                dbcontext.SaveChanges();
            }
        }

        public List<TypedUsers_PromotionalsVM> GetAll()
        {
            var item = dbcontext.typedUsers_Promotionals.Select(e => new TypedUsers_PromotionalsVM
            {
                user_id = e.user_id,
                promotional_id = e.promotional_id,
                expirationdate = e.expirationdate,
            });
            return item.ToList();
        }

        public List<TypedUsers_PromotionalsVM> GetByUserId(int id)
        {
            var item = dbcontext.typedUsers_Promotionals.Where(i => i.user_id == id).Select(e => new TypedUsers_PromotionalsVM
            {
                user_id = e.user_id,
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

        public List<TypedUsers_PromotionalsVM> GetByPromotionalId(int id)
        {
            var item = dbcontext.typedUsers_Promotionals.Where(i => i.promotional_id == id).Select(e => new TypedUsers_PromotionalsVM
            {
                user_id = e.user_id,
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

        public void Update(TypedUsers_PromotionalsModel item)
        {
            var _item = dbcontext.typedUsers_Promotionals.SingleOrDefault(c => c.user_id == item.user_id && c.promotional_id == item.promotional_id);
            if (item != null)
            {
                _item.expirationdate = item.expirationdate;
                dbcontext.SaveChanges();
            }
        }

    }
}
