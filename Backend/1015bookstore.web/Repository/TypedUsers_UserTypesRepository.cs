using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository
{
    public class TypedUsers_UserTypesRepository : ITypedUsers_UserTypesRepository
    {
        private readonly MyDbContext dbcontext;

        public TypedUsers_UserTypesRepository(MyDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public TypedUsers_UserTypesVM Add(TypedUsers_UserTypesModel item)
        {
            var _item = new TypedUsers_UserTypes
            {
                usertype_id = item.usertype_id,
                user_id = item.user_id,
                expirationdate = item.expirationdate,
            };
            dbcontext.Add(_item);
            dbcontext.SaveChanges();
            return new TypedUsers_UserTypesVM
            {
                usertype_id = _item.usertype_id,
                user_id = _item.user_id,
                expirationdate = _item.expirationdate,
            };
        }

        public void Delete(int usertypeid, int userid)
        {
            var item = dbcontext.typedUsers_UserTypes.Single(h => h.usertype_id == usertypeid && h.user_id == userid);
            if (item != null)
            {
                dbcontext.Remove(item);
                dbcontext.SaveChanges();
            }
        }

        public List<TypedUsers_UserTypesVM> GetAll()
        {
            var item = dbcontext.typedUsers_UserTypes.Select(e => new TypedUsers_UserTypesVM
            {
                usertype_id = e.usertype_id,
                user_id = e.user_id,
                expirationdate = e.expirationdate,
            });
            return item.ToList();
        }

        public List<TypedUsers_UserTypesVM> GetByUserTypeId(int id)
        {
            var item = dbcontext.typedUsers_UserTypes.Where(i => i.usertype_id == id).Select(e => new TypedUsers_UserTypesVM
            {
                usertype_id = e.usertype_id,
                user_id = e.user_id,
                expirationdate = e.expirationdate,
            });
            if (item.Count() != 0)
            {
                return item.ToList();
            }
            else
                return null;
        }

        public List<TypedUsers_UserTypesVM> GetByUserId(int id)
        {
            var item = dbcontext.typedUsers_UserTypes.Where(i => i.user_id == id).Select(e => new TypedUsers_UserTypesVM
            {
                usertype_id = e.usertype_id,
                user_id = e.user_id,
                expirationdate = e.expirationdate,
            });
            if (item.Count() != 0)
            {
                return item.ToList();
            }
            else
                return null;
        }

        public void Update(TypedUsers_UserTypesModel item)
        {
            var _item = dbcontext.typedUsers_UserTypes.SingleOrDefault(c => c.usertype_id == item.usertype_id && c.user_id == item.user_id);
            if (item != null)
            {
                _item.expirationdate = item.expirationdate;
                dbcontext.SaveChanges();
            }
        }
    }
}
