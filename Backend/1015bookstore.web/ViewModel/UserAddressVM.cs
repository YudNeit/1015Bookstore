using _1015bookstore.web.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.ViewModel
{
    public class UserAddressVM
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public bool is_default { get; set; }

        public string receiver_name { get; set; }

        public string receiver_phone { get; set; }

        public string city { get; set; }

        public string district { get; set; }

        public string sub_district { get; set; }

        public string address_detail { get; set; }

        public float coordinates_X { get; set; }

        public float coordinates_Y { get; set; }
    }
}
