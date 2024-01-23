using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.window.ViewModel.Catalog.Reviews
{
    public class ReviewRequestCreate
    {
        public int iOrder_id { get; set; }
        public List<ReviewProduct> lReview_products { get; set; }
    }
}
