using _1015bookstore.window.Business;
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

namespace _1015bookstore.window.TrendingPage
{
    public partial class TrendingUC : UserControl
    {
        public ProductAPIClient client;
        private string namecard;
        private int cate_id;
        private List<ProductViewModel> products;
        public TrendingUC(string namecard, int cate_id)
        {
            InitializeComponent();
            this.namecard = namecard;
            client = new ProductAPIClient();
            this.cate_id = cate_id;
            setcard();
        }

        private async void setcard()
        {
            label4.Text = namecard;

            var response = await client.GetProductByCate(Properties.Settings.Default.session, cate_id);
            products = response.Data;
            int count = 0;
            foreach (var item in response.Data)
            {
                count++;
                var card = new TrendingItem(item);
                flowLayoutPanel1.Controls.Add(card);
                card.Show();
                if (count == 13)
                {
                    break;
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            var form = this.TopLevelControl as MainA;
            form.CateAndSearchPage(namecard, products);
        }
    }
}
