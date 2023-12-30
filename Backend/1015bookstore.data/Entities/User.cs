using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime? dob {  get; set; }
        public bool? sex { get; set; }

        public List<Cart> carts { get; set; }
        public List<Order> orders { get; set; }
        public List<UserAddress> addresses { get; set; }
        public List<Transaction> transactions { get; set; }
        public List<UserUsePromotionalCode> usedpromotionalcode_lists { get; set; }
        public List<CodeForgotPassword> codes { get; set; }
        public List<Log> logs { get; set; }
        public List<Review> reviews { get; set; }
    }
}
