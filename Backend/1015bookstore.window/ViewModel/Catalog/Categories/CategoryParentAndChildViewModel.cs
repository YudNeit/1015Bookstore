using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.window.ViewModel.Catalog.Categories
{
    public class CategoryParentAndChildViewModel : CategoryViewModel
    {
        public List<CategoryViewModel> lCate_childs { get; set; }
    }
}
