using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Categories
{
    public class CategoryUpdateRequest
    {
        [Required]
        public int iCate_id {  get; set; }
        [Required]
        [Display(Name = "Tên danh mục")]
        public string sCate_name { get; set; }
        [Display(Name = "Trạng thái danh mục")]
        public CategoryStatus stCate_status { get; set; }
        [Display(Name = "Trạng thái hiển thị")]
        public CategoryShow stCate_show { get; set; }
    }
}
