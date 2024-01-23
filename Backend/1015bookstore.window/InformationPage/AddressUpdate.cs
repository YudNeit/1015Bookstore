using _1015bookstore.window.Business;
using _1015bookstore.window.MainPage.Informations;
using _1015bookstore.window.ViewModel.UserAddresses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.InformationPage
{
    public partial class AddressUpdate : UserControl
    {
        private AddressViewModel address;
        private UserAddressAPIClient client;
        public AddressUpdate(AddressViewModel address)
        {
            InitializeComponent();
            this.address = address;
            client = new UserAddressAPIClient();
            SetData();
        }

        private void SetData()
        {
            ten.Text = address.receiver_name;
            sdt.Text = address.receiver_phone;
            tinhthanh.Text = address.city;
            quanhuyen.Text = address.district;
            phuongxa.Text = address.sub_district;
            detail.Text = address.address_detail;
            setdafault.Checked = address.is_default;
            if (address.is_default )
            {
                setdafault.Enabled = false;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            var form = this.TopLevelControl as MainA;
            form.close_updateaddress();
        }

        private async void update()
        {
            if (string.IsNullOrEmpty(ten.Text) || string.IsNullOrEmpty(sdt.Text) || string.IsNullOrEmpty(tinhthanh.Text) || string.IsNullOrEmpty(quanhuyen.Text) || string.IsNullOrEmpty(phuongxa.Text) || string.IsNullOrEmpty(detail.Text))
            {
                error.Text = "*Vui lòng nhập đầy đủ thông tin";
                error.Visible = true;
                return;
            }

            var request = new UserAddressRequestUpdate
            {
                id = address.id,
                is_default = setdafault.Checked,
                receiver_name = ten.Text,
                receiver_phone = sdt.Text,
                city = tinhthanh.Text,
                district = quanhuyen.Text,
                sub_district = phuongxa.Text,
                address_detail = detail.Text,
            };

            var response = await client.UpdateAddress(Properties.Settings.Default.session, request);

            if (response.Status)
            {
                var form = this.TopLevelControl as MainA;
                form.close_updateaddress();

                var inforpage = form.GetCurrentUC() as Information;

                inforpage.afterupdateaddress();

                //form.afterupdateaddress();
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
