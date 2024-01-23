using _1015bookstore.window.Business;
using _1015bookstore.window.ViewModel.Catalog.Orders;
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

namespace _1015bookstore.window.CartPage.Order
{
    public partial class MyOrder : UserControl
    {
        OrderViewModel order;
        private List<AddressViewModel> addresses;
        private UserAddressAPIClient client;
        private PromotionalCodeAPIClient clientCode;
        private OrderAPIClient clientOrder;
        public MyOrder(OrderViewModel order)
        {
            InitializeComponent();
           this.order = order;
            client = new UserAddressAPIClient();
            clientCode = new PromotionalCodeAPIClient();
            clientOrder = new OrderAPIClient();
            GetAddress();
            Setdata();
        }




        private void Setdata() 
        {
            int count = 0;
            foreach (var item in order.lOrder_items)
            {
                count++;
                var orderdetail = new OrderItemUC(item);
                flowLayoutPanel1.Controls.Add(orderdetail);
                orderdetail.Show();
                if (count != 1)
                {
                    flowLayoutPanel1.Height += 120 + 10;
                }
                    
            }
            voucher_panel.Location = new Point(161, flowLayoutPanel1.Bottom + 20);
            total_panel.Location = new Point(161, voucher_panel.Bottom + 20);
            this.Height = total_panel.Bottom + 400 + 20;

            tienhang.Text = String.Format("{0:0.##}", order.vOrder_total - 30000) + " đ";

            tongtien.Text = String.Format("{0:0.##}", order.vOrder_total) + " đ";
        }

        private async void GetAddress()
        {
            var response = await client.GetAddressByUser(Properties.Settings.Default.session, Properties.Settings.Default.id);
            if (response.Status)
            {
                addresses = response.Data;
                var addressdefault = response.Data.FirstOrDefault(x => x.is_default);
                hoten.Text = addressdefault.receiver_name;
                sodienthoai.Text = addressdefault.receiver_phone;
                diachicuthe.Text = addressdefault.address_detail;
                tinhthanh.Text = $"{addressdefault.sub_district}, {addressdefault.district}, {addressdefault.city}";
            }    
        }

        private void doidiachi_Click(object sender, EventArgs e)
        {
            //518, 156
            var opendiachi = new DiaChiUC(addresses);
            this.Controls.Add(opendiachi);
            opendiachi.Location = new Point(518, 156);
            opendiachi.BringToFront();
            opendiachi.Show();

        }

        public void Update_address(AddressViewModel address)
        {
            hoten.Text = address.receiver_name;
            sodienthoai.Text = address.receiver_phone;
            diachicuthe.Text = address.address_detail;
            tinhthanh.Text = $"{address.sub_district}, {address.district}, {address.city}";
        }

        private async void checkcode()
        {
            var code = voucher.Text;
            if (string.IsNullOrEmpty(code))
            {
                error.Text = "Vui lòng điền mã code";
                error.Visible = true;
                return;
            }
            var response = await clientCode.CheckCode(Properties.Settings.Default.session, code, Properties.Settings.Default.id);
            if (response.Status)
            {
                tiengiamgia.Text = $"-{(int)order.vOrder_total * 1.0 * (response.Data.iPromotionalCode_discount_rate*1.0 / 100)} đ";
                tongtien.Text = $"{(int)order.vOrder_total - (int)order.vOrder_total * 1.0 * (response.Data.iPromotionalCode_discount_rate * 1.0 / 100)} đ";
                error.Text = "Code có thể sử dụng";
                error.ForeColor = Color.FromArgb(48, 207, 130);
                error.Visible = true;
                voucher.BackColor = Color.WhiteSmoke;
                return;
            }
            else 
            {
                error.Text = "Code không thể sử dụng";
                error.Visible = true;
                voucher.Text = "";
                return;
            }
            
        }

        private void apdungvoucher_Click(object sender, EventArgs e)
        {
            checkcode();
        }

        private async void ThanhToan()
        {
            if (!string.IsNullOrEmpty(voucher.Text)&&voucher.BackColor == Color.White)
            {
                error.Text = "Vui lòng kiểm tra code trước khi sử dụng";
                error.Visible = true;
                voucher.Text = "";
                return;
            }

            var request = new OrderBuyRequest
            {
                iOrder_id = order.iOrder_id,
                sOrder_address_receiver = $"{diachicuthe.Text}, {tinhthanh.Text}",
                sOrder_name_receiver = hoten.Text,
                sOrder_phone_receiver = sodienthoai.Text,
                sPromotionalCode_code = voucher.Text,
            };

            var response = await clientOrder.BuyOrder(Properties.Settings.Default.session, request);

            if(response.Status)
            {
                var form = this.TopLevelControl as MainA;
                form.homepage();
            }  
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void dathang_Click(object sender, EventArgs e)
        {
            ThanhToan();
        }
    }
}
