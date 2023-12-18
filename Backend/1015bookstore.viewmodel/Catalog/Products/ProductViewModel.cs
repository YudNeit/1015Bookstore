using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Products
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public double start_count { get; set; }
        public int review_count { get; set; }
        public int buy_count { get; set; }
        public bool flashsale { get; set; }
        public int like_count { get; set; }
        public int waranty { get; set; }
        public int quanity { get; set; }
        public int view_count { get; set; }
        public string? description { get; set; }
        public string? brand { get; set; }
        public string? madein { get; set; }
        public DateTime mfgdate { get; set; }
        public string? supplier { get; set; }
        public string? author { get; set; }
        public string? nop { get; set; }
        public int yop { get; set; }
        public ProductStatus status { get; set; }
    }
}
