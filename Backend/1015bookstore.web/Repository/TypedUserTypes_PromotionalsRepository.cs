using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository
{
    public class TypedUserTypes_PromotionalsRepository : ITypedUserTypes_PromotionalsRepository
    {
        private readonly MyDbContext dbcontext;

        public TypedUserTypes_PromotionalsRepository(MyDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public TypedUserTypes_PromotionalsVM Add(TypedUserTypes_PromotionalsModel item)
        {
            var _item = new TypedUserTypes_Promotionals
            {
                usertype_id = item.usertype_id,
                promotional_id = item.promotional_id,
                expirationdate = item.expirationdate,
            };
            dbcontext.Add(_item);
            dbcontext.SaveChanges();
            return new TypedUserTypes_PromotionalsVM
            {
                usertype_id = _item.usertype_id,
                promotional_id = _item.promotional_id,
                expirationdate = _item.expirationdate,
            };
        }

        public void Delete(int usertypeid, int promotionalid)
        {
            var item = dbcontext.typedUserTypes_Promotionals.Single(h => h.usertype_id == usertypeid && h.promotional_id == promotionalid);
            if (item != null)
            {
                dbcontext.Remove(item);
                dbcontext.SaveChanges();
            }
        }

        public List<TypedUserTypes_PromotionalsVM> GetAll()
        {
            var item = dbcontext.typedUserTypes_Promotionals.Select(e => new TypedUserTypes_PromotionalsVM
            {
                usertype_id = e.usertype_id,
                promotional_id = e.promotional_id,
                expirationdate = e.expirationdate,
            });
            return item.ToList();
        }

        public List<TypedUserTypes_PromotionalsVM> GetByUserTypeId(int id)
        {
            var item = dbcontext.typedUserTypes_Promotionals.Where(i => i.usertype_id == id).Select(e => new TypedUserTypes_PromotionalsVM
            {
                usertype_id = e.usertype_id,
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

        public List<TypedUserTypes_PromotionalsVM> GetByPromotionalId(int id)
        {
            var item = dbcontext.typedUserTypes_Promotionals.Where(i => i.promotional_id == id).Select(e => new TypedUserTypes_PromotionalsVM
            {
                usertype_id = e.usertype_id,
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

        public void Update(TypedUserTypes_PromotionalsModel item)
        {
            var _item = dbcontext.typedUserTypes_Promotionals.SingleOrDefault(c => c.usertype_id == item.usertype_id && c.promotional_id == item.promotional_id);
            if (item != null)
            {
                _item.expirationdate = item.expirationdate;
                dbcontext.SaveChanges();
            }
        }
    }
}
