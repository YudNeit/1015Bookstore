using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.PromotionalCodes
{
    public class PromotionalCodeCreateRequest
    {
        [Required(ErrorMessage = "The * field is required")]
        public string code { set; get; }

        [Required(ErrorMessage = "The * field is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        public string description { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Range(1,100, ErrorMessage = "The rate in range (1-100)")]
        public int discount_rate { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The amount is bigger than 0")]
        public int amount { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        public DateTime fromdate { set; get; }

        [Required(ErrorMessage = "The * field is required")]
        public DateTime todate { set; get; }
    }
}
