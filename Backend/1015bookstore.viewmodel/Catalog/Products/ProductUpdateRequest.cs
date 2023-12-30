using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Products
{
    public class ProductUpdateRequest
    {
        [Required]
        public int iProduct_id {  get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [MaxLength(100, ErrorMessage = "Name is limited max length 100 characters")]
        public string sProduct_name { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The price is bigger than 0")]
        public decimal vProduct_price { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The waranty is bigger than 0")]
        public int iProduct_waranty { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        public string sProduct_description { get; set; }

        #region Detail
        public string? sProduct_brand { get; set; }
        public string? sProduct_madein { get; set; }
        public DateTime? dtProduct_mfgdate { get; set; }
        public string? sProduct_supplier { get; set; }
        public string? sProduct_author { get; set; }
        public string? sProduct_nop { get; set; }
        public int? iProduct_yop { get; set; }
        #endregion

        public IFormFile? sImage_pathThumbnail { get; set; }
    }
}
