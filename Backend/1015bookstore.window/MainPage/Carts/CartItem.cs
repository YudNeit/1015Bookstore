using _1015bookstore.window.Business;
using _1015bookstore.window.Emun;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.MainPage
{
    public partial class CartItem : UserControl
    {
        private int id_;
        private string name_;
        private decimal price_;
        private int amount_;
        private string picture_;
        private CartStatus status_;
        private string filepath = "D:\\Data\\MonHoc\\Web-SE347\\Project\\1015bookstore__git\\1015Bookstore\\Backend\\1015bookstore.window\\Img\\user-content\\";
        private CartAPIClient _cartAPIClient;
        public CartItem(int _id, string _name, decimal _price, int _amount, string _picture, CartStatus _status)
        {
            InitializeComponent();
            _cartAPIClient = new CartAPIClient();
            id_ = _id;
            name_ = _name;
            price_ = _price;
            amount_ = _amount;
            picture_ = _picture;
            status_ = _status;
            if (status_ == CartStatus.OOS)
            {
                this.BackColor = Color.LightGoldenrodYellow;
                this.plus.Enabled = false;
                this.minus.Enabled = false;
            }    
            SetPicture();
            SetName();
            SetPrice();
            SetAmount();
        }

        private void SetPicture()
        {
            if (picture_ == null)
            {
                string url = filepath + "default.png";
                Image image = Image.FromFile(url);
                pic.Image = image;
            }
            else
            {
                string url = filepath + picture_;
                Image image = Image.FromFile(url);
                pic.Image = image;
            }
            
        }
        private void SetAmount()
        {
            amount.Text = amount_.ToString();
        }
        private void SetPrice()
        {
            price.Text = price_.ToString();
        }
        private void SetName()
        {
            if (name_.Length >= 33)
            {
                for (int i = 34 - 1; i >= 0; i--)
                {
                    if (name_[i] == ' ')
                    {
                        name_ = name_.Insert(i, "\n");
                        break;
                    }
                }
            }    
            if (name_.Length >= 50)
            {
                for (int i = 50 - 1; i >= 0; i--)
                {
                    if (name_[i] == ' ')
                    {
                        name_ = new string(name_.Take(i).ToArray()) + new string('.', 3);
                        break;
                    }
                }
            }
            name.Text = name_;
        }

        private async Task addproduct()
        {
            var response =  await _cartAPIClient.PlusCart(Properties.Settings.Default.session, id_, 1);
            if (response.Status)
            {
                amount.Text = (Convert.ToInt32(amount.Text) + 1).ToString();
            }
            else
            {
                MessageBox.Show("Số lượng không đủ để thêm vào vỏ hàng");
            }    
        }

        private async Task subproduct()
        {
            if (amount.Text == 1.ToString())
            {
                return;
            }    
            var response = await _cartAPIClient.MinusCart(Properties.Settings.Default.session, id_, -1);
            if (response.Status)
            {
                amount.Text = (Convert.ToInt32(amount.Text) - 1).ToString();
            }
        }

        private void plus_Click(object sender, EventArgs e)
        {
            addproduct();
        }

        private void minus_Click(object sender, EventArgs e)
        {
            subproduct();
        }

        private async Task RemoveCart()
        {
            var response = await _cartAPIClient.DeleteCart(Properties.Settings.Default.session, id_);
            if (response.Status)
            {
                var flowpanel = this.Parent;
                flowpanel.Controls.Remove(this);
                var uc = flowpanel.Parent;
                uc.Controls.Find("label2",true)[0].Text = $"Đã có {flowpanel.Controls.Count} sản phẩm";
            }    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RemoveCart();
        }
    }
}
