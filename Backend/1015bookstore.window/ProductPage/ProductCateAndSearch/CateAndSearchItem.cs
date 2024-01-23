using _1015bookstore.window.ViewModel.Catalog.Products;
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

namespace _1015bookstore.window.ProductPage.ProductCateAndSearch
{
    public partial class CateAndSearchItem : UserControl
    {

        private string filepath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img\user-content");
        private ProductViewModel product;
        public CateAndSearchItem(ProductViewModel product)
        {
            InitializeComponent();
            this.product = product;
            SetPicture();
            SetPrice();
            SetName(); SetCountBuy(); 
        }

        

        private void SetPicture()
        {
            if (product.sImage_pathThumbnail == null)
            {
                string url = Path.Combine(filepath, "default.png");
                Image image = Image.FromFile(url);
                avatar.Image = image;
            }
            else
            {
                string url = Path.Combine(filepath, product.sImage_pathThumbnail);
                Image image = Image.FromFile(url);
                avatar.Image = image;
            }

            

        }
        private void SetPrice()
        {
            dongia.Text = String.Format("{0:0.##}", product.vProduct_price) + " đ";
        }
        private void SetName()
        {
            var name_ = product.sProduct_name;
            if (name_.Length >= 33)
            {
                for (int i = 33 - 1; i >= 0; i--)
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
            tensanpham.Text = name_;
        }

        private void SetCountBuy()
        {
            buy.Text = product.iProduct_buy_count.ToString();
        }
        private void ProductViewPage()
        {
            var form = this.TopLevelControl as MainA;
            form.ProductViewPage(product);
        }
        private void avatar_Click(object sender, EventArgs e)
        {
            ProductViewPage();
        }

        private void tensanpham_Click(object sender, EventArgs e)
        {
            ProductViewPage();
        }

        private void dongia_Click(object sender, EventArgs e)
        {
            ProductViewPage();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ProductViewPage();
        }

        private void buy_Click(object sender, EventArgs e)
        {
            ProductViewPage();
        }
    }
}
