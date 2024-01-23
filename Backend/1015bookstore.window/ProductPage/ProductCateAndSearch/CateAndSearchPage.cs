using _1015bookstore.window.TrendingPage;
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

namespace _1015bookstore.window.ProductPage.ProductCateAndSearch
{
    public partial class CateAndSearchPage : UserControl
    {
        private string name;
        private List<ProductViewModel> listproduct;
        public CateAndSearchPage(string name, List<ProductViewModel> listproduct)
        {
            InitializeComponent();
            this.name = name;
            this.listproduct = listproduct;
            setcard();
        }

        private void setcard()
        {
            label2.Text = name;
            
            foreach (var item in listproduct)
            {
                var card = new CateAndSearchItem(item);
                flowLayoutPanel1.Controls.Add(card);
                card.Show();
            }

            int count = (int)Math.Ceiling((double)listproduct.Count / 6);
            if (count > 2)
            {
                flowLayoutPanel1.Height = flowLayoutPanel1.Height + (count - 2) * (260 + 10);
            }

            this.Height = flowLayoutPanel1.Bottom + 400 + 20;

        }
    }
}
