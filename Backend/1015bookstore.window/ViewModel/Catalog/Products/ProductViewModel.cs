using _1015bookstore.window.Emun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.window.ViewModel.Catalog.Products
{
    public class ProductViewModel
    {
        public int iProduct_id { get; set; }
        public string sProduct_name { get; set; }
        public decimal vProduct_price { get; set; }
        public double dProduct_start_count { get; set; }
        public int iProduct_review_count { get; set; }
        public int iProduct_buy_count { get; set; }
        public bool bProduct_flashsale { get; set; }
        public int iProduct_like_count { get; set; }
        public int iProduct_waranty { get; set; }
        public int iProduct_quantity { get; set; }
        public int iProduct_view_count { get; set; }
        public string sProduct_description { get; set; }
        public string sProduct_brand { get; set; }
        public string sProduct_madein { get; set; }
        public DateTime? dtProduct_mfgdate { get; set; }
        public string sProduct_supplier { get; set; }
        public string sProduct_author { get; set; }
        public string sProduct_nop { get; set; }
        public int? iProduct_yop { get; set; }
        public ProductStatus stProduct_status { get; set; }
        public string sImage_pathThumbnail { get; set; }
    }
}
