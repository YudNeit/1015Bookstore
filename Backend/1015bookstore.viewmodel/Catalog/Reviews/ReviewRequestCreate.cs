using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Reviews
{
    public class ReviewRequestCreate
    {
        [Required]
        public int iOrder_id {  get; set; }
        [Required]
        public List<ReviewProduct> lReview_products { get; set; }
    }
}
