using _1015bookstore.window.Business;
using _1015bookstore.window.ProductPage.Reviews;
using _1015bookstore.window.ViewModel.Catalog.Products;
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

namespace _1015bookstore.window.ProductPage
{
    public partial class ReviewUC : UserControl
    {
        private ProductViewModel product;
        private List<ReviewViewModel> list;
        private ReviewAPIClient client;
        public ReviewUC(ProductViewModel product)
        {
            InitializeComponent();
            this.product = product;
            client = new ReviewAPIClient();
            Setdata();
        }

        private async void Setdata()
        {
            label6.Text = product.dProduct_start_count.ToString();

            var response = await client.GetReview(Properties.Settings.Default.session, product.iProduct_id);

            list = response.Data;

            btt_1sao.Text = "1 sao (" + list.Where(x => x.iReview_start == 1).Count().ToString() + ")";
            btt_2sao.Text = "2 sao (" + list.Where(x => x.iReview_start == 2).Count().ToString() + ")";
            btt_3sao.Text = "3 sao (" + list.Where(x => x.iReview_start == 3).Count().ToString() + ")";
            btt_4sao.Text = "4 sao (" + list.Where(x => x.iReview_start == 4).Count().ToString() + ")";
            btt_5sao.Text = "5 sao (" + list.Where(x => x.iReview_start == 5).Count().ToString() + ")";

            int cout = 0;
            foreach(var item in list)
            {
                cout++;
                var reviewdetail = new ReviewDetailUC(item);
                commentpanel.Controls.Add(reviewdetail);
                commentpanel.Show();
                if (cout !=1)
                {
                    commentpanel.Height += 148;
                }
            } 
            
            this.Height = commentpanel.Bottom + 20;
            this.Parent.Height = this.Bottom + 400 + 20;

        }

        private void btt_tatca_Click(object sender, EventArgs e)
        {
            commentpanel.Controls.Clear();
            commentpanel.Height = 148;

            int cout = 0;
            foreach (var item in list)
            {
                cout++;
                var reviewdetail = new ReviewDetailUC(item);
                commentpanel.Controls.Add(reviewdetail);
                commentpanel.Show();
                if (cout != 1)
                {
                    commentpanel.Height += 148;
                }
            }

            this.Height = commentpanel.Bottom + 20;
            this.Parent.Height = this.Bottom + 400 + 20;
        }

        private void btt_5sao_Click(object sender, EventArgs e)
        {
            commentpanel.Controls.Clear();
            commentpanel.Height = 148;

            int cout = 0;
            foreach (var item in list.Where(x => x.iReview_start == 5))
            {
                cout++;
                var reviewdetail = new ReviewDetailUC(item);
                commentpanel.Controls.Add(reviewdetail);
                commentpanel.Show();
                if (cout != 1)
                {
                    commentpanel.Height += 148;
                }
            }

            this.Height = commentpanel.Bottom + 20;
            this.Parent.Height = this.Bottom + 400 + 20;
        }

        private void btt_4sao_Click(object sender, EventArgs e)
        {
            commentpanel.Controls.Clear();
            commentpanel.Height = 148;

            int cout = 0;
            foreach (var item in list.Where(x => x.iReview_start == 4))
            {
                cout++;
                var reviewdetail = new ReviewDetailUC(item);
                commentpanel.Controls.Add(reviewdetail);
                commentpanel.Show();
                if (cout != 1)
                {
                    commentpanel.Height += 148;
                }
            }

            this.Height = commentpanel.Bottom + 20;
            this.Parent.Height = this.Bottom + 400 + 20;
        }

        private void btt_3sao_Click(object sender, EventArgs e)
        {
            commentpanel.Controls.Clear();
            commentpanel.Height = 148;

            int cout = 0;
            foreach (var item in list.Where(x => x.iReview_start == 3))
            {
                cout++;
                var reviewdetail = new ReviewDetailUC(item);
                commentpanel.Controls.Add(reviewdetail);
                commentpanel.Show();
                if (cout != 1)
                {
                    commentpanel.Height += 148;
                }
            }

            this.Height = commentpanel.Bottom + 20;
            this.Parent.Height = this.Bottom + 400 + 20;
        }

        private void btt_2sao_Click(object sender, EventArgs e)
        {
            commentpanel.Controls.Clear();
            commentpanel.Height = 148;

            int cout = 0;
            foreach (var item in list.Where(x => x.iReview_start == 2))
            {
                cout++;
                var reviewdetail = new ReviewDetailUC(item);
                commentpanel.Controls.Add(reviewdetail);
                commentpanel.Show();
                if (cout != 1)
                {
                    commentpanel.Height += 148;
                }
            }

            this.Height = commentpanel.Bottom + 20;
            this.Parent.Height = this.Bottom + 400 + 20;
        }

        private void btt_1sao_Click(object sender, EventArgs e)
        {
            commentpanel.Controls.Clear();
            commentpanel.Height = 148;

            int cout = 0;
            foreach (var item in list.Where(x => x.iReview_start == 1))
            {
                cout++;
                var reviewdetail = new ReviewDetailUC(item);
                commentpanel.Controls.Add(reviewdetail);
                commentpanel.Show();
                if (cout != 1)
                {
                    commentpanel.Height += 148;
                }
            }

            this.Height = commentpanel.Bottom + 20;
            this.Parent.Height = this.Bottom + 400 + 20;
        }
    }
}
