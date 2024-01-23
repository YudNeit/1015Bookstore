using _1015bookstore.window.ViewModel.UserAddresses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace _1015bookstore.window.CartPage.Order.DiaChi
{
    public partial class DiaChiItemUC : UserControl
    {
        AddressViewModel address;
        public DiaChiItemUC(AddressViewModel address)
        {
            InitializeComponent();
            this.address = address;
            Setdata();
        }

        private void Setdata()
        {
            hoten.Text = address.receiver_name;
            sodienthoai.Text = address.receiver_phone;
            diachi.Text = address.address_detail;
            label1.Text = address.sub_district + ", " + address.district + ", " + address.city;
            if (address.is_default)
            {
                label5.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var Myorder = this.Parent.Parent.Parent as MyOrder;
            Myorder.Update_address(address);
            var parent = this.Parent.Parent;
            parent.Hide();
        }
    }
}
