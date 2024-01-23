using _1015bookstore.window.Business;
using _1015bookstore.window.MainPage.Informations;
using _1015bookstore.window.ViewModel.Catalog.Orders;
using _1015bookstore.window.ViewModel.Catalog.Reviews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.InformationPage
{
    public partial class ReviewAfterBuy : UserControl
    {
        OrderViewModel order;
        ReviewAPIClient client;
        public ReviewAfterBuy(OrderViewModel order)
        {
            InitializeComponent();
            this.order = order;
            client = new ReviewAPIClient();
            setdata();
        }

        private void setdata()
        {
            foreach(var item in order.lOrder_items)
            {
                var orderdetail = new ReviewAfterBuyDetail(item);
                flowLayoutPanel1.Controls.Add(orderdetail);
                orderdetail.Show();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void binhluan()
        {
            List<ReviewProduct> list = new List<ReviewProduct>();
            foreach (var item in flowLayoutPanel1.Controls)
            {
                var product = item as ReviewAfterBuyDetail;
                var productreview = product.GetReviewProduct();
                list.Add(productreview);
            }

            ReviewRequestCreate request = new ReviewRequestCreate { 
                iOrder_id = order.iOrder_id,
                lReview_products = list
            };

            var response = await client.AddReview(Properties.Settings.Default.session, request);
            if(response.Status)
            {
                var parent = this.Parent as Information;
                parent.CloseReview();
            }    
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            binhluan();
        }
    }
}
