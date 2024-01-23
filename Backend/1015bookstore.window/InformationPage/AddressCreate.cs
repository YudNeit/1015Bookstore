using _1015bookstore.window.Business;
using _1015bookstore.window.MainPage.Informations;
using _1015bookstore.window.ViewModel.UserAddresses;
using System;
using System.Windows.Forms;

namespace _1015bookstore.window.InformationPage
{
    public partial class AddressCreate : UserControl
    {
        private Guid user_id;
        private UserAddressAPIClient client;
        public AddressCreate(Guid user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            client = new UserAddressAPIClient();
        }

        private void close_Click(object sender, EventArgs e)
        {
            var form = this.TopLevelControl as MainA;
            form.close_createaddress();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = this.TopLevelControl as MainA;
            form.close_createaddress();
        }

        private async void create()
        {
            if (string.IsNullOrEmpty(ten.Text) || string.IsNullOrEmpty(sdt.Text) || string.IsNullOrEmpty(tinhthanh.Text) || string.IsNullOrEmpty(quanhuyen.Text) || string.IsNullOrEmpty(phuongxa.Text) || string.IsNullOrEmpty(detail.Text))
            {
                error.Text = "*Vui lòng nhập đầy đủ thông tin";
                error.Visible = true;
                return;
            }

            var request = new UserAddressRequestCreate
            {
                user_id = user_id,
                is_default = setdafault.Checked,
                receiver_name = ten.Text,
                receiver_phone = sdt.Text,
                city = tinhthanh.Text,
                district = quanhuyen.Text,
                sub_district = phuongxa.Text,
                address_detail = detail.Text,
            };

            var response = await client.CreateAddress(Properties.Settings.Default.session, request);

            if (response.Status)
            {
                var form = this.TopLevelControl as MainA;
                form.close_createaddress();

                var inforpage = form.GetCurrentUC() as Information;

                inforpage.aftercreateaddress();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            create();
        }
    }
}
