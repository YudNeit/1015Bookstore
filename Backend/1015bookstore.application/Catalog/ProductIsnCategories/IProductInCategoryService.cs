using _1015bookstore.viewmodel.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.Catalog.ProductIsnCategories
{
    public interface IProductInCategoryService
    {
        Task<ResponseService> Create(int iProduct_id, int iCate_id);
        Task<ResponseService> Delete(int iProduct_id, int iCate_id);
    }
}
