using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int id {  get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int waranty { get; set; }
        public int quanity { get; set; }
        public string description { get; set; }

        #region Detail
        public string? brand { get; set; }
        public string? madein { get; set; }
        public DateTime mfgdate { get; set; }
        public string? suppiler { get; set; }
        public string? author { get; set; }
        public string? nop { get; set; }
        public int yop { get; set; }
        #endregion

        public IFormFile? ThumbnailImage { get; set; }
    }
}
