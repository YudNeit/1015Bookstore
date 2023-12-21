using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class PromotionalCode
    {
        public int id { set; get; }
        public DateTime fromdate { set; get; }
        public DateTime todate { set; get; }
        public string code { set; get; }
        public string name { get; set; }
        public string description { get; set; }

        public string createdby { get; set; }
        public DateTime datecreated { get; set; }
        public string updatedby { get; set; }
        public DateTime dateupdated { get; set; }

        public int discount_rate { get; set; }
        public int amount {  get; set; }
        public PromotionalCodeStatus status { set; get; }

        public List<UserUsePromotionalCode> usedpromotionalcode_lists { get; set; }
    }
}
