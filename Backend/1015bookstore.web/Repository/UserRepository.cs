using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace _1015bookstore.web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext dbcontext;

        public UserRepository(MyDbContext _dbcontext) 
        { 
            dbcontext = _dbcontext;
        }
        public UserVM Add(UserModel user)
        {
            var _user = new User
            {
                username = user.username,
                password = user.password,
                email = user.email,
                firstname = user.firstname,
                lastname = user.lastname,
                phone = user.phone,
            };
            dbcontext.Add(_user);
            dbcontext.SaveChanges();
            return new UserVM
            {
                id = _user.id,
                username = _user.username,
                email = _user.email,
            };
        }

        public void Delete(int id)
        {
            var user = dbcontext.Users.SingleOrDefault(u => u.id == id);
            if (user != null)
            {
                dbcontext.Remove(user);
                dbcontext.SaveChanges();
            }
        }

        public List<UserVM> GetAll()
        {
            var users = dbcontext.Users.Select(e => new UserVM {
                id = e.id,
                username = e.username,
                email = e.email,
            });
            return users.ToList();
        }

        public UserVM GetById(int id)
        {
            var user = dbcontext.Users.SingleOrDefault(u => u.id == id);
            if (user != null)
            {
                return new UserVM
                {
                    id = user.id,
                    username = user.username,
                    email = user.email,
                };
            }
            else
                return null;
        }

        public void Update(int id, UserModel user)
        {
            var _user = dbcontext.Users.SingleOrDefault(u => u.id == id);
            if (_user != null)
            {
                _user.username = user.username;
                _user.password = user.password;
                _user.email = user.email;
                _user.firstname = user.firstname;
                _user.lastname = user.lastname;
                _user.phone = user.phone;
                _user.updatedtime = DateTime.Now;
                dbcontext.SaveChanges();
            }
        }
    }
}
