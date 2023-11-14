using _1015bookstore.web.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.ViewModel
{
    public class ReviewVM
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
        public int starts { get; set; }
        public string contents { get; set; }
    }
}
