using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class CodeForgotPassword
    {
        public int id {  get; set; }
        public Guid user_id {  get; set; }
        public string code { get; set; }
        public DateTime createdate { get; set; }
        public DateTime dateexpire { get; set; }
        public string token { get; set; }
        public bool check {  get; set; }
        public User user { get; set; }
    }
}
