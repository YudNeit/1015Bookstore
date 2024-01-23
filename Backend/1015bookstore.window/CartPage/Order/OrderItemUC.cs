using _1015bookstore.window.ViewModel.Catalog.Orders;
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

namespace _1015bookstore.window.CartPage.Order
{
    public partial class OrderItemUC : UserControl
    {
        OrderDetailViewModel order;
        private string filepath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img\user-content");
        public OrderItemUC(OrderDetailViewModel order)
        {
            InitializeComponent();
            this.order = order;
            Setdata();
        }
        private void SetTotal()
        {
            sotien.Text = String.Format("{0:0.##}", order.iProduct_amount * order.vProduct_price) + " đ";
        }

        private void SetPicture()
        {
            if (order.sImage_path == null)
            {
                string url = Path.Combine(filepath, "default.png");
                Image image = Image.FromFile(url);
                avatarsanpham.Image = image;
            }
            else
            {
                string url = Path.Combine(filepath, order.sImage_path);
                Image image = Image.FromFile(url);
                avatarsanpham.Image = image;
            }

        }
        private void SetAmount()
        {
            soluong.Text = order.iProduct_amount.ToString();
        }
        private void SetPrice()
        {
            dongia.Text = String.Format("{0:0.##}", order.vProduct_price) + " đ";
        }
        private void SetName()
        {
            var name_ = order.sProduct_name;
            if (name_.Length >= 44)
            {
                for (int i = 44 - 1; i >= 0; i--)
                {
                    if (name_[i] == ' ')
                    {
                        name_ = name_.Insert(i, "\n");
                        break;
                    }
                }
            }
            if (name_.Length >= 60)
            {
                for (int i = 60 - 1; i >= 0; i--)
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
        private void Setdata()
        {
            SetName();
            SetPrice();
            SetAmount();
            SetPicture();
            SetTotal();
        }

    }
}
