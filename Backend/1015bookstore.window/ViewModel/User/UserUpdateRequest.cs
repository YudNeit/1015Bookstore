using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.window.ViewModel.User
{
    public class UserUpdateRequest
    {
        public Guid gUser_id { get; set; }
        public string sUser_firstname { get; set; }
        public string sUser_lastname { get; set; }
        public DateTime dtUser_dob { get; set; }
        public bool bUser_sex { get; set; }
        public string sUser_phonenumber { get; set; }
        public IFormFile sUser_avt { get; set; }
    }
}
