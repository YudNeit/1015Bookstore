using _1015bookstore.data.Enums;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.viewmodel.Catalog.Products
{
    public class ProductViewModel
    {
        [Display(Name = "Mã sản phẩm")]
        public int iProduct_id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string? sProduct_name { get; set; }
        [Display(Name = "Giá sản phẩm")]
        public decimal vProduct_price { get; set; }
        [Display(Name = "Số sao của sản phẩm")]
        public double dProduct_start_count { get; set; }
        [Display(Name = "Số bình luận của sản phẩm")]
        public int iProduct_review_count { get; set; }
        [Display(Name = "Số lượt mua của sản phẩm")]
        public int iProduct_buy_count { get; set; }
        public bool bProduct_flashsale { get; set; }
        [Display(Name = "Số lượt yêu thích của sản phẩm")]
        public int iProduct_like_count { get; set; }
        [Display(Name = "Thời gian bảo hành sản phẩm")]
        public int iProduct_waranty { get; set; }
        [Display(Name = "Số lượng sản phẩm")]
        public int iProduct_quantity { get; set; }
        [Display(Name = "Số lượt xem của sản phẩm")]
        public int iProduct_view_count { get; set; }
        [Display(Name = "Mô tả sản phẩm")]
        public string? sProduct_description { get; set; }
        [Display(Name = "Thương hiệu sản phẩm")]
        public string? sProduct_brand { get; set; }
        [Display(Name = "Nơi sản xuất sản phẩm")]
        public string? sProduct_madein { get; set; }
        [Display(Name = "Ngày sản xuất sản phẩm")]
        [DataType(DataType.Date)]
        public DateTime? dtProduct_mfgdate { get; set; }
        [Display(Name = "Nhà cung cấp sản phẩm")]
        public string? sProduct_supplier { get; set; }
        [Display(Name = "Tác giả sản phẩm")]
        public string? sProduct_author { get; set; }
        [Display(Name = "Nhà xuất bản sản phẩm")]
        public string? sProduct_nop { get; set; }
        [Display(Name = "Năm xuất bản sản phẩm")]
        public int? iProduct_yop { get; set; }
        [Display(Name = "Tình trạng sản phẩm")]
        public ProductStatus stProduct_status { get; set; }
        [Display(Name = "Thumbnail sản phẩm")]
        public string? sImage_pathThumbnail { get; set; }
    }
}
