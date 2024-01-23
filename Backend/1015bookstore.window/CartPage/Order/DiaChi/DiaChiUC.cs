using _1015bookstore.window.CartPage.Order.DiaChi;
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

namespace _1015bookstore.window.CartPage.Order
{
    public partial class DiaChiUC : UserControl
    {
        List<AddressViewModel> list;
        public DiaChiUC(List<AddressViewModel> list)
        {
            InitializeComponent();
            this.list = list;
            Setdata();
            
        }

        private void Setdata()
        {
            foreach (var item in list)
            {
                var address = new DiaChiItemUC(item);
                diachi.Controls.Add(address);
                address.Show();
            }    
        }

        private void xacnhan_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
