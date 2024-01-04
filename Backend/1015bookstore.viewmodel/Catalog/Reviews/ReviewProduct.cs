using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Reviews
{
    public class ReviewProduct
    {
        [Required]
        public int iProduct_id { get; set; }
        [Range(0,5,ErrorMessage ="Wrong format start")]
        public int iReview_start {  get; set; }
        public string? sReview_content { get; set; }
    }
}
