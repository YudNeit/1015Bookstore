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
        public string sCate_name { get; set; }
        [Required]
        public int? iCate_parent_id { get; set; }
    }
}
