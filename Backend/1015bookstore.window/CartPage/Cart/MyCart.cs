using _1015bookstore.window.Business;
using _1015bookstore.window.MainPage;
using _1015bookstore.window.ViewModel.Catalog;
using _1015bookstore.window.ViewModel.Catalog.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.CartPage.Cart
{
    public partial class MyCart : UserControl
    {
        private readonly CartAPIClient client;
        private List<CartViewModel> list;
        private decimal total = 0;
        private OrderAPIClient clientOrder;
        //public event EventHandler AddressLoadingCompleted;

        public MyCart()
        {
            InitializeComponent();
            client = new CartAPIClient();
            clientOrder = new OrderAPIClient();
            GetCart();
        }


        private async void GetCart()
        {
            var response = await client.GetCart(Properties.Settings.Default.session, Properties.Settings.Default.id);
            if (response.Status)
            {
                list = response.Data;
                int count = 0;
                foreach (var item in response.Data)
                {
                    count++;
                    var cartitem = new CartItemUC(item);
                    cartitem.Name = item.iCart_id.ToString();
                    giohang.Controls.Add(cartitem);
                    cartitem.Show();

                    if (count != 1)
                    {
                        giohang.Height += 150 + 10;
                    }    
                    
                }
            }
            if (giohang.Bottom > 1000)
            {
                this.Height = giohang.Bottom + 400 + 20;
            }    
        }

        public void AddTotal(decimal tong)
        {
            total += tong;
            tongtien.Text = String.Format("{0:0.##}", total) + " đ";
        }
        public void SubTotal(decimal tong)
        {
            total -= tong;
            tongtien.Text = String.Format("{0:0.##}", total) + " đ";
        }

        private async void CreateOrder()
        {
            var listchoose = new List<int>();

            foreach (var item in giohang.Controls) 
            {
                var cart = item as CartItemUC;
                if (cart.IsChoose())
                {
                    listchoose.Add(Convert.ToInt32(cart.Name));
                }    
            }

            if (listchoose.Count > 0)
            {
                var request = new OrderCreateRequest
                {
                    lCart_ids = listchoose,
                    gUser_id = Properties.Settings.Default.id
                };
                var response = await clientOrder.AddOrder(Properties.Settings.Default.session, request);
                if (response.Status)
                {
                    var form = this.TopLevelControl as MainA;
                    form.OrderPage(response.Data);
                }    
            }
        }

        private void thanhtoan_Click(object sender, EventArgs e)
        {
            CreateOrder();
        }
    }
}
