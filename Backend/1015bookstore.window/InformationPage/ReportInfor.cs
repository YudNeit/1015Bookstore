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
using System.Windows.Forms.DataVisualization.Charting;

namespace _1015bookstore.window.InformationPage
{
    public partial class ReportInfor : UserControl
    {
        ReportAPIClient client;
        public ReportInfor()
        {
            InitializeComponent();
            client = new ReportAPIClient();
            GetDate();
        }

        private async void GetDate()
        {
            if (datefrom.Value >  dateto.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày tới");
                return;
            }

            var response = await client.GetSoldOutUser(Properties.Settings.Default.session, Properties.Settings.Default.id, datefrom.Value, dateto.Value);
            if (response.Status)
            {
                var data = response.Data;

                chart1.Series["Mua"].Points.Clear();

                foreach (var item in data)
                {
                    chart1.Series["Mua"].Points.AddXY($"{item.date.Day}-{item.date.Month}-{item.date.Year}", (int)item.total);
                }
                chart1.Titles.Clear();
                chart1.Titles.Add("Thống kê mua của người dùng");
                

            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDate();
        }
    }
}
