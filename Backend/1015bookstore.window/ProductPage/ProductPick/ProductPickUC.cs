using _1015bookstore.window.Business;
using _1015bookstore.window.ViewModel.Catalog.Carts;
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

namespace _1015bookstore.window.ProductPage.ProductPick
{
    public partial class ProductPickUC : UserControl
    {
        private ProductViewModel product;
        private string filepath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img\user-content");
        private CartAPIClient client;
        public ProductPickUC(ProductViewModel product)
        {
            InitializeComponent();
            soluong.Text = "1";
            this.product = product;
            client = new CartAPIClient();
            SetPicture();
            SetPrice();
            SetCountBuy();
            SetName();
            SetReviewRate();
            SetReviewCount();
            SetSomeInfor();
            SetQuantity();
        }

        private void SetQuantity()
        {
            tonkho.Text = product.iProduct_quantity + " sản phẩm hiện có";
        }

        private void SetSomeInfor()
        {
            nhacungcap.Text = product.sProduct_supplier;
            nhaxuatban.Text = product.sProduct_nop;
            tacgia.Text = product.sProduct_author;
        }    

        private void SetReviewCount()
        {
            danhgia.Text = product.iProduct_review_count.ToString();
        }    

        private void SetReviewRate()
        {
            rating.Text = product.dProduct_start_count.ToString();
        }

        private void SetPicture()
        {
            if (product.sImage_pathThumbnail == null)
            {
                string url = Path.Combine(filepath, "default.png");
                Image image = Image.FromFile(url);
                product_avatar.Image = image;
            }
            else
            {
                string url = Path.Combine(filepath, product.sImage_pathThumbnail);
                Image image = Image.FromFile(url);
                product_avatar.Image = image;
            }



        }
        private void SetPrice()
        {
            giatien.Text = String.Format("{0:0.##}", product.vProduct_price) + " đ";
        }
        private void SetName()
        {
            var name_ = product.sProduct_name;
            if (name_.Length >= 60)
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
            daban.Text = "Đã bán " + product.iProduct_buy_count.ToString() + " sản phẩm";
            luotmua.Text = product.iProduct_buy_count.ToString();
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

        private void soluong_TextChanged(object sender, EventArgs e)
        {
            int sl = 1;
            // Loại bỏ các ký tự phi số
            string text = new string(soluong.Text.Where(char.IsDigit).ToArray());
            // Loại bỏ 0 ở đầu
            if (text.StartsWith("0"))
                text = text.TrimStart('0');

            if (!string.IsNullOrEmpty(text))
            {           
                sl = int.Parse(text);

                if (sl > 99)
                    sl = 99;
            }    

            soluong.Text = sl.ToString();
        }

        // Xử lý nút cộng, trừ số lượng
        private void cong_Click(object sender, EventArgs e)
        {
            int sl = int.Parse(soluong.Text);

            if (sl < 99)
                sl++;
            else
                sl = 1;

            soluong.Text = sl.ToString();
        }

        private void tru_Click(object sender, EventArgs e)
        {
            int sl = int.Parse(soluong.Text);

            if (sl > 1)
                sl--;
            else
                sl = 99;

            soluong.Text = sl.ToString();
        }

        private async void AddCart()
        {
            var cartrequest = new CartAddProduct
            {
                iProduct_id = product.iProduct_id,
                iProduct_amount = Convert.ToInt32(soluong.Text),
            };
            var response = await client.AddCart(Properties.Settings.Default.session, cartrequest, Properties.Settings.Default.id);
            if (response.Status)
            {
                MessageBox.Show("Thêm vào giỏ hàng thành công");
            }    
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.session))
            {
                var form = this.TopLevelControl as MainA;
                form.login();
            }   
            else
            {
                AddCart();
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.session))
            {
                var form = this.TopLevelControl as MainA;
                form.login();
            }
        }
    }
}
