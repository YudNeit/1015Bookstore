using _1015bookstore.window.Emun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.window.ViewModel.Catalog.Categories
{
    public class CategoryViewModel
    {
        public int iCate_id { get; set; }
        public string sCate_name { get; set; }
        public int iCate_parent_id { get; set; }
        public CategoryStatus stCate_status { get; set; }
        public CategoryShow stCate_show { get; set; }
    }
}
