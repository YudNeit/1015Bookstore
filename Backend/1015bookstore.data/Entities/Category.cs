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
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? categoryparentid { get; set; }
        public string createdby { get; set; }
        public DateTime datecreated { get; set; }
        public string updatedby { get; set; }
        public DateTime dateupdated { get; set; }
        public CategoryStatus status { get; set; }
        public CategoryShow show { get; set; }

        public List<ProductInCategory> productincategory { get; set; }
    }
}
