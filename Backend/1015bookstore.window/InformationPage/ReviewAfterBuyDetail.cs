using _1015bookstore.window.ViewModel.Catalog.Orders;
using _1015bookstore.window.ViewModel.Catalog.Reviews;
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

namespace _1015bookstore.window.InformationPage
{
    public partial class ReviewAfterBuyDetail : UserControl
    {
        OrderDetailViewModel order;
        private string filepath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img\user-content");
        private string filepath_ = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img");
        public ReviewAfterBuyDetail(OrderDetailViewModel order)
        {
            InitializeComponent();
            this.order = order;
            setdata();
        }

        public ReviewProduct GetReviewProduct()
        {
            var reviewProduct = new ReviewProduct {
                iProduct_id = order.iProduct_id,
                iReview_start = GetStar(),
                sReview_content = textBox1.Text
            };
            return reviewProduct;
        }

        public int GetStar()
        {
            int count = 0;
            for (int i = 1; i <=5; i++)
            {
                var pic_ = panel1.Controls.Find($"S{i}", true)[0] as PictureBox;
                if (pic_.BackColor == Color.White)
                {
                    count++;
                }    
            }
            return count;
        }

        private void SetPicture()
        {
            if (order.sImage_path == null)
            {
                string url = Path.Combine(filepath, "default.png");
                Image image = Image.FromFile(url);
                pictureBox1.Image = image;
            }
            else
            {
                string url = Path.Combine(filepath, order.sImage_path);
                Image image = Image.FromFile(url);
                pictureBox1.Image = image;
            }

        }

        private void SetStart(object sender, EventArgs e)
        {
            var pic = sender as PictureBox;
            int number = Convert.ToInt32(pic.Name[pic.Name.Length - 1].ToString());
            for (int i = 5; i> number; i-- )
            {
                var pic_ = panel1.Controls.Find($"S{i}", true)[0] as PictureBox;

                string url = Path.Combine(filepath_, "Vector.png");
                Image image = Image.FromFile(url);
                pic_.Image = image;
                pic_.BackColor = Color.Transparent;
            }    
            for (int i = 1; i<= number; i++)
            {
                var pic_ = panel1.Controls.Find($"S{i}", true)[0] as PictureBox;

                string url = Path.Combine(filepath_, "Star.png");
                Image image = Image.FromFile(url);
                pic_.Image = image;
                pic_.BackColor = Color.White;
            }    
        }

        private void SetName()
        {
            var name_ = order.sProduct_name;
            if (name_.Length >= 47)
            {
                for (int i = 48 - 1; i >= 0; i--)
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
                for (int i = 61 - 1; i >= 0; i--)
                {
                    if (name_[i] == ' ')
                    {
                        name_ = new string(name_.Take(i).ToArray()) + new string('.', 3);
                        break;
                    }
                }
            }
            label1.Text = name_;
        }

        private void setdata()
        {
            SetPicture();
            SetName();
        }
    }
}
