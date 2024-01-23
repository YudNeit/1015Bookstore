using _1015bookstore.window.MainPage.Informations;
using _1015bookstore.window.ViewModel.Catalog.Orders;
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
    public partial class OrderHistoryDetail : UserControl
    {
        OrderViewModel order;
        public OrderHistoryDetail(OrderViewModel order)
        {
            InitializeComponent();
            this.order = order;
            Setdata();
        }

        private void Setdata()
        {
            label1.Text = $"{order.dtOrrder_dateorder.Day}-{order.dtOrrder_dateorder.Month}-{order.dtOrrder_dateorder.Year} {order.dtOrrder_dateorder.Hour}:{order.dtOrrder_dateorder.Minute}";
            label2.Text = order.sOrder_name_receiver;
            label3.Text = order.sOrder_phone_receiver;
            label4.Text = order.sOrder_address_receiver;
            label5.Text = String.Format("{0:0.##}", order.vOrder_total) + " đ";
            if (order.bOrder_review)
            {
                button1.Enabled = false;
                button1.BackColor = Color.WhiteSmoke;
            }
        }

        private void OpenReview()
        {
            var parent = this.Parent.Parent.Parent as Information;
            parent.OpenReview(order);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenReview();
        }
    }
}
