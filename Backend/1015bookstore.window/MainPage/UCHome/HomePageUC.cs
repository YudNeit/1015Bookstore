using _1015bookstore.window.Business;
using _1015bookstore.window.TrendingPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.MainPage.MainProduct
{
    public partial class HomePageUC : UserControl
    {
        

        public HomePageUC()
        {
            InitializeComponent();
            sethomepage();
        }

        private void sethomepage()
        {
            //45, 441 , 45, 1036
            var card1 = new TrendingUC("Sách yêu thích nhất", 38);
            this.Controls.Add(card1);
            card1.Location = new Point(45, 441);
            card1.BringToFront();
            card1.Show();

            var card2 = new TrendingUC("Tiểu Thuyết", 24);
            this.Controls.Add(card2);
            card2.Location = new Point(45, 1080);
            card2.BringToFront();
            card2.Show();

            this.Height = card2.Bottom + 400 + 10;
        }


    }
}
