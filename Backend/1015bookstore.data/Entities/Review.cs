using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class Review
    {
        public int id {  get; set; }
        public string? content { get; set; }
        public int starts { get; set; }
        public Guid user_id { get; set; }
        public int product_id { get; set; }
        public DateTime created_at { get; set;}

        public User user { get; set; }
        public Product product { get; set; }

    }
}
