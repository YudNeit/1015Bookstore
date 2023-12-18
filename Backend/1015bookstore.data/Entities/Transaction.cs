using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _1015bookstore.data.Entities
{
    public class Transaction
    {
        public int id { set; get; }
        public DateTime transactiondate { set; get; }
        public string externaltransactionid { set; get; }
        public decimal amount { set; get; }
        public decimal fee { set; get; }
        public string result { set; get; }
        public string message { set; get; }
        public TransactionStatus status { set; get; }
        public string provider { set; get; }

        public Guid user_id { set; get; }
        public User user { set; get; }
    }
}
