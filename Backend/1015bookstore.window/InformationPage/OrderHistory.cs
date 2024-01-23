using _1015bookstore.window.Business;
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
    public partial class OrderHistory : UserControl
    {
        OrderAPIClient client;
        public OrderHistory()
        {
            InitializeComponent();
            client = new OrderAPIClient();
            GetData();
        }

        private async void GetData()
        {
            var response = await client.GetHistory(Properties.Settings.Default.session, Properties.Settings.Default.id);
            if (response.Status)
            {
                int count = 0;
                foreach (var item in response.Data)
                {
                    count++;
                    var order = new OrderHistoryDetail(item);
                    flowLayoutPanel1.Controls.Add(order);
                    order.Show();
                    if (count > 3)
                    {
                        flowLayoutPanel1.Height += 130;
                    }
                }
                this.Height = flowLayoutPanel1.Bottom + 10;
                this.Parent.Height = flowLayoutPanel1.Bottom + 400 + 50;
            }    
        }
    }
}
