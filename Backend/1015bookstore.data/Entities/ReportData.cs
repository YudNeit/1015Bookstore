using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class ReportData
    {
        public int id {  get; set; }
        public int product_id { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public bool status { get; set; }
        public DateTime time { get; set; }
    }
}
