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
    public partial class AddressDetail : UserControl
    {
        private AddressViewModel address;
        private UserAddressAPIClient client;
        public AddressDetail(AddressViewModel address)
        {
            InitializeComponent();
            this.address = address;
            this.client = new UserAddressAPIClient();
            Setdata();
        }

        private void Setdata()
        {
            ten.Text = address.receiver_name;
            sdt.Text = address.receiver_phone;
            chitiet.Text = address.address_detail;
            diachi.Text = address.sub_district + ", " + address.district + ", " + address.city;
            if (address.is_default)
            {
                label5.Visible = true;
                button1.Enabled = false;
                label7.Visible = false;
            }    
        }

        private async void Delete()
        {
            var response = await client.DeleteAddress(Properties.Settings.Default.session, address.id);
            if (response.Status)
            {
                var flowpanel = this.Parent;
                flowpanel.Controls.Remove(this);
                var uc = flowpanel.Parent;
            }
        }    

        private void label7_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void OpenUpdateAddress()
        {
            var form = this.TopLevelControl as MainA;
            form.open_updateaddress(address);
        }    

        private void label6_Click(object sender, EventArgs e)
        {
            OpenUpdateAddress();
        }

        private async void Setdefault()
        {
            var response = await client.SetDefaultAddress(Properties.Settings.Default.session, address.id);
            if(response.Status)
            {
                var inforpage = this.Parent.Parent.Parent as Information;
                inforpage.afterupdateaddress();
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setdefault();
        }
    }
}
