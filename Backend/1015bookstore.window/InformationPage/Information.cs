using _1015bookstore.window.Business;
using _1015bookstore.window.InformationPage;
using _1015bookstore.window.Login;
using _1015bookstore.window.ViewModel.Catalog.Orders;
using _1015bookstore.window.ViewModel.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.MainPage.Informations
{
    public partial class Information : UserControl
    {
        private Guid user_id;
        private UserControl currentUC;
        private UserAPIClient _userAPIClient;
        UserControl review;
        public Information(Guid user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            _userAPIClient = new UserAPIClient();
            GetUserInformationAsync();

        }
        private async void GetUserInformationAsync()
        {
            if (currentUC != null)
            { 
                this.Controls.Remove(currentUC);
                currentUC = null;
            }

            var userResponse = await _userAPIClient.GetUserById(Properties.Settings.Default.session, user_id);

            if (userResponse.Status)
            {
                var userViewModel = userResponse.Data;

                var infordetail = new InforDetail(userViewModel);
                infordetail.Location = new Point(380, 30);
                this.Controls.Add(infordetail);
                infordetail.BringToFront();
                infordetail.Show();

                this.Height = infordetail.Bottom + 20 + 400;

                currentUC = infordetail;
            }
            else
            {
                MessageBox.Show($"Error: {userResponse.Message}");
            }
        }
    
        private async void GetUserAddress()
        {
            this.Controls.Remove(currentUC);
            currentUC = null;

            var addressUC = new InforAddress(user_id);

            addressUC.AddressLoadingCompleted += (sender, e) =>
            {
                addressUC.Location = new Point(380, 30);
                this.Controls.Add(addressUC);
                addressUC.BringToFront();
                addressUC.Show();

                this.Height = addressUC.Bottom + 20 + 400;

                currentUC = addressUC;
            };

            await addressUC.LoadAddressAsync();

        }

        public void afterupdateaddress()
        {
            GetUserAddress();
        }

        public void aftercreateaddress()
        {
            GetUserAddress();
        }

        public void afterupdateinfor()
        {
            GetUserInformationAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            GetUserInformationAsync();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            GetUserAddress();
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(48, 207, 130);
            label.Font = new Font("Roboto", 13, FontStyle.Bold);
        }
        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(140, 140, 140);
            label.Font = new Font("Roboto", 13, FontStyle.Regular);
        }

        private void GetHistory()
        {
            this.Controls.Remove(currentUC);
            currentUC = null;

            var history = new OrderHistory();


            history.Location = new Point(380, 30);
            this.Controls.Add(history);
            history.BringToFront();
            history.Show();

            this.Height = history.Bottom + 20 + 400;

            currentUC = history;
        }

        private void label27_Click(object sender, EventArgs e)
        {
            GetHistory();
        }
    
        public void OpenReview(OrderViewModel order)
        {
            var reviewopen = new ReviewAfterBuy(order);
            this.Controls.Add(reviewopen);
            reviewopen.Location = new Point(429, 26);
            reviewopen.BringToFront();
            reviewopen.Show();

            review = reviewopen;
        }    
        public void CloseReview()
        {
            this.Controls.Remove(review);
            review = null;
            GetHistory();
        }

        private void GetReport()
        {
            this.Controls.Remove(currentUC);
            currentUC = null;

            var report = new ReportInfor();


            report.Location = new Point(380, 30);
            this.Controls.Add(report);
            report.BringToFront();
            report.Show();

            this.Height = report.Bottom + 20 + 400;

            currentUC = report;
        }

        private void label28_Click(object sender, EventArgs e)
        {
            GetReport();
        }
    }
}
