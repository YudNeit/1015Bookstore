using _1015bookstore.window.Business;
using _1015bookstore.window.MainPage;
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

namespace _1015bookstore.window.Main
{
    public partial class Cart : UserControl
    {
        private Guid _user_id;
        private readonly CartAPIClient _client;
        public Cart(Guid user_id)
        {
            _client = new CartAPIClient();
            InitializeComponent();
            _user_id = user_id;
            GetCart();
        }
        public async Task GetCart()
        {
            var response = await _client.GetCart(Properties.Settings.Default.session, _user_id);
            if (response.Status)
            {
                foreach (var item in response.Data)
                {
                    var cartitem = new CartItem(item.iCart_id, item.sProduct_name, item.vProduct_price, item.iProduct_amount, item.sImage_path, item.stCart_status);
                    flowLayoutPanel1.Controls.Add(cartitem);
                    cartitem.Show();
                }
            }
            label2.Text = $"Đã có {response.Data.Count} sản phẩm";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = this.TopLevelControl as MainA;

            form.CartPage();
        }
    }
}
