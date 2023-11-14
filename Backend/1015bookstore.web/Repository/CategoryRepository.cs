using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Helper;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;

namespace _1015bookstore.web.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext dbcontext;
        public CategoryRepository(MyDbContext _dbcontext) 
        {
            dbcontext = _dbcontext;
        }
        public CategoryVM Add(int userid, CategoryModel cate)
        {
            string username = dbcontext.Users.Single(h => h.id == userid).username;
            var _cate = new Category
            {
                name = cate.name,
                categoryparentid = cate.categoryparentid,
                createdby = username,
                updatedby = username
            };
            dbcontext.Add(_cate);
            dbcontext.SaveChanges();
            return new CategoryVM
            {
                id = _cate.id,
                name = _cate.name,
                categoryparentid = _cate.categoryparentid
            };
        }

        public void Delete(int id)
        {
            var cate = dbcontext.Categories.SingleOrDefault(c => c.id == id);
            if (cate != null)
            {
                dbcontext.Remove(cate);
                dbcontext.SaveChanges();
            }
        }

        public List<CategoryVM> GetAll()
        {
            var cate = dbcontext.Categories.Select(e => new CategoryVM
            {
                id = e.id,
                name = e.name,
                categoryparentid = e.categoryparentid
            });
            return cate.ToList();
        }

        public CategoryVM GetById(int id)
        {
            var cate = dbcontext.Categories.SingleOrDefault(c => c.id == id);
            if (cate != null)
            {
                return new CategoryVM
                {
                    id = cate.id,
                    name = cate.name,
                    categoryparentid = cate.categoryparentid,
                };
            }
            else
                return null;
        }

        public void Update(int id, int userid, CategoryModel cate)
        {
            var _cate = dbcontext.Categories.SingleOrDefault(c => c.id == id);
            if (_cate != null)
            {
                _cate.name = cate.name;
                _cate.categoryparentid = cate.categoryparentid;
                _cate.updatedby = dbcontext.Users.Single(h => h.id == userid).username;
                _cate.updatedtime = DateTime.Now;
                dbcontext.SaveChanges();
            } 
        }
        public List<ListOfCategoryVM> GetFull()
        {
            List<ListOfCategoryVM> list = new List<ListOfCategoryVM>();
            foreach( var item in dbcontext.Categories.ToList())
            {
                list.Add(new ListOfCategoryVM
                {
                    id = item.id,
                    name = item.name,
                    categories = dbcontext.Categories.Where(e => e.categoryparentid == item.id).Select(e => new CategoryVM
                    {
                        id = e.id,
                        name = e.name,
                        categoryparentid = e.categoryparentid,
                    }).ToList(),
                });
            }
            return list;
        }
        public ListOfCategoryVM GetFullById(int id)
        {
            var item = dbcontext.Categories.Single(e => e.id == id);
            return new ListOfCategoryVM
            {
                id = item.id,
                name = item.name,
                categories = dbcontext.Categories.Where(e => e.categoryparentid == item.id).Select(e => new CategoryVM
                {
                    id = e.id,
                    name = e.name,
                    categoryparentid = e.categoryparentid,
                }).ToList(),
            };
        }
    }
}
