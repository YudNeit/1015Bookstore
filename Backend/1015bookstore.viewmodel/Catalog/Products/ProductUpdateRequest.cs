using _1015bookstore.data.Enums;
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
        [Display(Name = "Tên sản phẩm")]
        public string sProduct_name { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The price is bigger than 0")]
        [Display(Name = "Giá sản phẩm")]
        [DataType(DataType.Currency)]
        public decimal vProduct_price { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The waranty is bigger than 0")]
        [Display(Name = "Thời hạn bảo hành")]
        public int iProduct_waranty { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Display(Name = "Mô tả sản phẩm")]
        public string sProduct_description { get; set; }

        [Display(Name = "Trạng thái sản phẩm")]
        public ProductStatus stProduct_status { get; set; }

        #region Detail
        [Display(Name = "Thương hiệu sản phẩm")]
        public string? sProduct_brand { get; set; }
        [Display(Name = "Xuất xứ sản phẩm")]
        public string? sProduct_madein { get; set; }
        [Display(Name = "Ngày xuất xứ")]
        [DataType(DataType.Date)]
        public DateTime? dtProduct_mfgdate { get; set; }
        [Display(Name = "Nhà cung cấp")]
        public string? sProduct_supplier { get; set; }
        [Display(Name = "Tác giả")]
        public string? sProduct_author { get; set; }
        [Display(Name = "Nhà phát hành")]
        public string? sProduct_nop { get; set; }
        [Display(Name = "Năm phát hành")]
        public int? iProduct_yop { get; set; }
        #endregion
        [Display(Name = "Thumbnail sản phẩm")]
        public IFormFile? sImage_pathThumbnail { get; set; }
    }
}
