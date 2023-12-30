using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1015bookstore.data.Enums;

namespace _1015bookstore.data.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public decimal price { get; set; }
        public float start_count { get; set; }
        public int review_count { get; set; }
        public int buy_count { get; set; }
        public bool flashsale { get; set; }
        public int like_count { get; set; }
        public int waranty { get; set; }
        public int quanity { get; set; }
        public int view_count { get; set; }
        public string description { get; set; }

        #region Detail
        public string? brand { get; set; }
        public string? madein { get; set; }
        public DateTime? mfgdate { get; set; }
        public string? suppiler { get; set; }
        public string? author { get; set; }
        public string? nop { get; set; }
        public int? yop { get; set; }
        #endregion

        public string createdby { get; set; }
        public DateTime datecreated { get; set; }
        public string updatedby { get; set; }
        public DateTime dateupdated { get; set; }
        public ProductStatus status { get; set; }

        public List<ProductInCategory> productincategory { get; set; }
        public List<OrderDetail> orderdetails { get; set; }
        public List<Cart> carts { get; set; }   
        public List<ProductImage> productimages { get; set; }
        public List<Review> reviews { get; set; }
    }
}
