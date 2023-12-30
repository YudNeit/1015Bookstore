using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Categories
{
    public class CategoryCreateRequest
    {
        [Required]
        public string sCate_name {  get; set; }
        public int? iCate_parent_id {  get; set; }
    }
}
