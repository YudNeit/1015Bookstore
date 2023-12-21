using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.PromotionalCodes
{
    public class PromotionalCodeUpdateRequest
    {
        public int id { get; set; }
        public string code { set; get; }
        public string name { get; set; }
        public string description { get; set; }
        public int discount_rate { get; set; }
        public int amount { get; set; }
        public DateTime fromdate { set; get; }
        public DateTime todate { set; get; }
    }
}
