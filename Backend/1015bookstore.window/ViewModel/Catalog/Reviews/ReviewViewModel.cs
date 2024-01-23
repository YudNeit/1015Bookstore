using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.window.ViewModel.Catalog.Reviews
{
    public class ReviewViewModel
    {
        public string sUser_username { get; set; }
        public int iReview_start { get; set; }
        public string sReview_content { get; set; }
        public DateTime dtReview_date { get; set; }
        public string sUser_avt { get; set; }
    }
}
