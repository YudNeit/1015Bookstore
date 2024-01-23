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

namespace _1015bookstore.window.ProductPage.Reviews
{
    public partial class ReviewDetailUC : UserControl
    {
        private ReviewViewModel reivew;
        private string filepath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img\user-content");
        private string filepath_ = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img");
        public ReviewDetailUC(ReviewViewModel reivew)
        {
            InitializeComponent();
            this.reivew = reivew;
            Setdata();
            Load_binhluan();
        }

        private void SetPicture()
        {
            if (reivew.sUser_avt == null)
            {
            }
            else
            {
                string url = Path.Combine(filepath, reivew.sUser_avt);
                Image image = Image.FromFile(url);
                avatar.Image = image;
            }
        }

        public void Setdata()
        {
            SetPicture();
            username.Text = reivew.sUser_username;
            thoigian.Text = reivew.dtReview_date.Day.ToString() + "/" + reivew.dtReview_date.Month.ToString() + "/" + reivew.dtReview_date.Year.ToString();
            binhluan.Text = reivew.sReview_content;

            for (int i = 5; i > reivew.iReview_start; i--)
            {
                var pic = panel1.Controls.Find($"pictureBox{i}", true)[0] as PictureBox;
                string url = Path.Combine(filepath_, "Vector.png");
                Image image = Image.FromFile(url);
                pic.Image = image;
            }    
        }    

        public void Load_binhluan()
        {
            int totallength = binhluan.Text.Length;
            int wordperline = 386;
            int x = (totallength / wordperline);

            if (x >= 2)
                binhluan.Height = (x) * 30;
            else
                binhluan.Height = 60;

            this.Height = binhluan.Bottom + 40;
        }
    }
}
