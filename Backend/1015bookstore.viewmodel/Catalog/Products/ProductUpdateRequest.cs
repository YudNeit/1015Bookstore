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
        public int id {  get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [MaxLength(100, ErrorMessage = "Name is limited max length 100 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The price is bigger than 0")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The waranty is bigger than 0")]
        public int waranty { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The quantity is bigger than 0")]
        public int quanity { get; set; }

        [Required(ErrorMessage = "The * field is required")]
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

        public IFormFile? ThumbnailImage { get; set; }
    }
}
