using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Helper;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly MyDbContext dbcontext;

        public UserTypeRepository(MyDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public UserTypeVM Add(int userid, UserTypeModel type)
        {
            string username = dbcontext.Users.Single(h => h.id == userid).username;
            var _type = new UserType
            {
                name = type.name,
                alias = RemoveUnicode.Removeunicode(type.name),
                description = type.description,
                createdby = username,
                updatedby = username
            };
            dbcontext.Add(_type);
            dbcontext.SaveChanges();
            return new UserTypeVM
            {
                id = _type.id,
                name = _type.name,
                description = _type.description,
            };
        }

        public void Delete(int id)
        {
            var type = dbcontext.UserTypes.SingleOrDefault(t => t.id == id);
            if (type != null)
            {
                dbcontext.Remove(type);
                dbcontext.SaveChanges();
            }
        }

        public List<UserTypeVM> GetAll()
        {
            var type = dbcontext.UserTypes.Select(e => new UserTypeVM
            {
                id = e.id,
                name = e.name,
                description = e.description
            });
            return type.ToList();
        }

        public UserTypeVM GetById(int id)
        {
            var type = dbcontext.UserTypes.SingleOrDefault(t => t.id == id);
            if (type != null)
            {
                return new UserTypeVM
                {
                    id = type.id,
                    name = type.name,
                    description = type.description,
                };
            }
            else
                return null;
        }

        public void Update(int id, int userid, UserTypeModel type)
        {
            var _type = dbcontext.UserTypes.SingleOrDefault(t => t.id == id);
            if (_type != null)
            {
                _type.name = type.name;
                _type.description = type.description;
                _type.updatedby = dbcontext.Users.Single(h => h.id == userid).username;
                _type.updatedtime = DateTime.Now;
                dbcontext.SaveChanges();
            }

        }
    }
}
