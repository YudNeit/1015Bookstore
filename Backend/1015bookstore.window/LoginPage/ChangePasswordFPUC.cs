using _1015bookstore.window.Business;
using _1015bookstore.window.ViewModel.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.Login
{
    public partial class ChangePasswordFPUC : UserControl
    {
        private readonly UserAPIClient _userAPIClient;
        public ChangePasswordFPUC()
        {
            InitializeComponent();
            _userAPIClient = new UserAPIClient();
        }
        private void eye_Click(object sender, EventArgs e)
        {
            FontAwesome.Sharp.IconPictureBox picbox = sender as FontAwesome.Sharp.IconPictureBox;
            CSharp.Winform.UI.Panel panel = picbox.Parent as CSharp.Winform.UI.Panel;
            CSharp.Winform.UI.TextBox text = panel.Controls[2] as CSharp.Winform.UI.TextBox;

            if (picbox.BackColor == Color.White)
            {
                text.PasswordChar = '\0';
                picbox.BackColor = Color.Transparent;
                picbox.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
            else if (picbox.BackColor == Color.Transparent)
            {
                text.PasswordChar = '*';
                picbox.BackColor = Color.White;
                picbox.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
        }
        private void Typing_Click_u(object sender, EventArgs e)
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
            if (pn.Controls.Count == 3)
            {
                pn.Controls[2].Focus();
                pn.Controls[2].ForeColor = Color.Black;
            }
            else
            {
                pn.Controls[1].Focus();
                pn.Controls[1].ForeColor = Color.Black;
            }
            label.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            confirm();
        }
        private async Task confirm()
        {
            var password_ = password.Text;
            var confirmpassword_ = confirmpassword.Text;
            if (string.IsNullOrEmpty(password_) || string.IsNullOrEmpty(confirmpassword_))
            {
                error.Text = "*Vui lòng nhập điền đầy đủ thông tin";
                error.Visible = true;
                return;
            }
            if (!Regex.IsMatch(password_, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$"))
            {
                error.Text = "*Mật khẩu sai định dạng";
                error.Visible = true;
                return;
            }
            if (confirmpassword_ != password_)
            {
                error.Text = "*Mật khẩu và xác nhận mật khẩu khác nhau";
                error.Visible = true;
                return;
            }

            var request = new ChangePasswordFPRequest {
                sUser_tokenFP = Properties.Settings.Default.fp,
                sUser_password = password_,
                sUser_confirmpassword = confirmpassword_,
            };

            var response = await _userAPIClient.ChangePasswordForgotPassword(request);

            if (response.Status)
            {
                Properties.Settings.Default.fp = "";

                var form = this.TopLevelControl as Login;
                form.login();
            }    
            else
            {
                error.Text = response.Message;
                error.Visible = true;
                return;
            }    
        }

    }
}
