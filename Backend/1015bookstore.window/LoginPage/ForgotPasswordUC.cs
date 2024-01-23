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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace _1015bookstore.window.Login
{
    public partial class ForgotPasswordUC : UserControl
    {
        private readonly UserAPIClient _userAPIClient;
        public ForgotPasswordUC()
        {
            InitializeComponent();
            _userAPIClient = new UserAPIClient();
        }

        private void Typing_Click(object sender, EventArgs e)
        {
            Label label;

            if (sender is CSharp.Winform.UI.TextBox)
            {
                CSharp.Winform.UI.TextBox text = sender as CSharp.Winform.UI.TextBox;
                var panel = text.Parent as CSharp.Winform.UI.Panel;
                label = panel.Controls[0] as Label;
            }
            else
            {
                label = sender as Label;
            }
            var pn = label.Parent as CSharp.Winform.UI.Panel;
            label.Visible = false;
            pn.Controls[1].Focus();
            pn.Controls[1].ForeColor = Color.Black;
        }

        private async Task forgotpassword()
        {
            var email_ = email.Text;
            if (string.IsNullOrEmpty(email_))
            {
                error.Text = "*Vui lòng nhập email";
                error.Visible = true;
                return;
            }

            var response = await _userAPIClient.ForgotPassword(email_);
            if (!response.Status)
            {
                error.Text = response.Message;
                error.Visible = true;
                return;
            }
            else
            {
                var token = response.Data;
                Properties.Settings.Default.fp = token;

                var form = this.TopLevelControl as Login;
                form.confirmpasswordfp();
            } 
        }



        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                forgotpassword();
            }
        }


        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            var form = this.TopLevelControl as Login;
            form.login();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            forgotpassword();
        }
    }
}
