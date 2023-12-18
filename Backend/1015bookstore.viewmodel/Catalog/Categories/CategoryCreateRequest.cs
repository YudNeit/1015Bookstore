using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Categories
{
    public class CategoryCreateRequest
    {
        public string name {  get; set; }
        public int? parent_id {  get; set; }
    }
}
