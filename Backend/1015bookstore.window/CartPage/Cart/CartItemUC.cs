using _1015bookstore.window.Business;
using _1015bookstore.window.CartPage.Cart;
using _1015bookstore.window.ViewModel.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _1015bookstore.window.CartPage
{
    public partial class CartItemUC : UserControl
    {
        CartViewModel cart;
        CartAPIClient client;
        private string filepath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img\user-content");
        public CartItemUC(CartViewModel cart)
        {
            InitializeComponent();
            this.cart = cart;
            client = new CartAPIClient();
            SetPicture();
            SetAmount();
            SetPrice();
            SetName();
            SetTotal();
        }

        public bool IsChoose()
        {
            return checkBox1.Checked;
        }

        private async void RemoveCart()
        {
            var flag = checkBox1.Checked;   
            var response = await client.DeleteCart(Properties.Settings.Default.session, cart.iCart_id);
            if (response.Status)
            {
                var parent = this.Parent.Parent as MyCart;
                if (flag)
                {
                    parent.SubTotal(Convert.ToInt32(soluong.Text) * cart.vProduct_price);
                }    

                var flowpanel = this.Parent;
                flowpanel.Height -= 150; 
                flowpanel.Controls.Remove(this);

                if (flowpanel.Bottom > 1000)
                {
                    parent.Height = flowpanel.Bottom + 400 + 20;
                }
            }
        }

        private void SetTotal()
        {
            sotien.Text = String.Format("{0:0.##}", cart.iProduct_amount * cart.vProduct_price) + " đ";
        }

        private void SetPicture()
        {
            if (cart.sImage_path == null)
            {
                string url = Path.Combine(filepath, "default.png");
                Image image = Image.FromFile(url);
                avatarsanpham.Image = image;
            }
            else
            {
                string url = Path.Combine(filepath, cart.sImage_path);
                Image image = Image.FromFile(url);
                avatarsanpham.Image = image;
            }

        }
        private void SetAmount()
        {
            soluong.Text = cart.iProduct_amount.ToString();
        }
        private void SetPrice()
        {
            dongia.Text =  String.Format("{0:0.##}", cart.vProduct_price) + " đ";
        }
        private void SetName()
        {
            var name_ = cart.sProduct_name;
            if (name_.Length >= 54)
            {
                for (int i = 54 - 1; i >= 0; i--)
                {
                    if (name_[i] == ' ')
                    {
                        name_ = name_.Insert(i, "\n");
                        break;
                    }
                }
            }
            if (name_.Length >= 80)
            {
                for (int i = 80 - 1; i >= 0; i--)
                {
                    if (name_[i] == ' ')
                    {
                        name_ = new string(name_.Take(i).ToArray()) + new string('.', 3);
                        break;
                    }
                }
            }
            tensanpham.Text = name_;
        }

        private async void addproduct()
        {
            var response = await client.PlusCart(Properties.Settings.Default.session, cart.iCart_id, 1);
            if (response.Status)
            {
                soluong.Text = (Convert.ToInt32(soluong.Text) + 1).ToString();
                sotien.Text =  String.Format("{0:0.##}", (Convert.ToInt32(soluong.Text) * cart.vProduct_price)) + " đ";
            }
            else
            {
                MessageBox.Show("Số lượng không đủ để thêm vào vỏ hàng");
            }
        }

        private async void subproduct()
        {
            if (soluong.Text == 1.ToString())
            {
                return;
            }
            var response = await client.MinusCart(Properties.Settings.Default.session, cart.iCart_id, -1);
            if (response.Status)
            {
                soluong.Text = (Convert.ToInt32(soluong.Text) - 1).ToString();
                sotien.Text = String.Format("{0:0.##}", Convert.ToInt32(soluong.Text) * cart.vProduct_price) + " đ";
            }
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            RemoveCart();
        }

        private void cong_Click(object sender, EventArgs e)
        {
            addproduct();
        }

        private void tru_Click(object sender, EventArgs e)
        {
            subproduct();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var parent = this.Parent.Parent as MyCart;
            if (checkBox1.Checked)
            {
                
                parent.AddTotal(Convert.ToInt32(soluong.Text) * cart.vProduct_price);
            }
            else
            {
                parent.SubTotal(Convert.ToInt32(soluong.Text) * cart.vProduct_price);
            }    
        }
    }
}
