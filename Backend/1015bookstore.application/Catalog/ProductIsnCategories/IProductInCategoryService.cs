using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.ProductIsnCategories
{
    public interface IProductInCategoryService
    {
        Task<int> Create(int product_id, int category_id);
        Task<int> Delete(int product_id, int category_id);
    }
}
