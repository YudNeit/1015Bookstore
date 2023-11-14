using _1015bookstore.web.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.ViewModel
{
    public class CategoryVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public int categoryparentid { get; set; }
    }
}
