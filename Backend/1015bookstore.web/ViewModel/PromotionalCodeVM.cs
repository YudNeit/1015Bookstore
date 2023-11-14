using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.ViewModel
{
    public class PromotionalCodeVM
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int discount_rate { get; set; }
    }
}
