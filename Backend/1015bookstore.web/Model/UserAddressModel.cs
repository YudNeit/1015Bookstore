namespace _1015bookstore.web.Model
{
    public class UserAddressModel
    {
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
