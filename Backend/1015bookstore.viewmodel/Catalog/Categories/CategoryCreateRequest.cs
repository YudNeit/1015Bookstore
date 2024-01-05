using _1015bookstore.data.Enums;
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
        [Display(Name = "Tên danh mục")]
        public string sCate_name {  get; set; }
        [Display(Name = "Danh mục cha")]
        public int? iCate_parent_id {  get; set; }
        [Required]
        [Display(Name = "Hiển thị ở")]
        public CategoryShow stCate_show { get; set; }
    }
}
