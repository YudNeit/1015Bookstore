using _1015bookstore.window.MainPage.Products;
using _1015bookstore.window.ProductPage.ProductPick;
using _1015bookstore.window.ViewModel.Catalog.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.ProductPage
{
    public partial class ProductViewPage : UserControl
    {
        private ProductViewModel product;
        public ProductViewPage(ProductViewModel product)
        {
            InitializeComponent();
            this.product = product;

            var productdetail = new ProductPickUC(product);
            this.Controls.Add(productdetail);
            productdetail.Location = new Point(162, 33);
            productdetail.Show();

            var productinfor = new ProductDetails(product);
            this.Controls.Add(productinfor);
            productinfor.Location = new Point(162, 432);
            productinfor.Show();

            var productreview = new ReviewUC(product);
            this.Controls.Add((productreview));
            productreview.Location = new Point(162, productinfor.Bottom + 20);
            productreview.Show();

            this.Height = productreview.Bottom + 20 + 400;
        }
    }
}
