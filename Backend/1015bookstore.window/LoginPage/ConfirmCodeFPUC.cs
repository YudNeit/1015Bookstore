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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace _1015bookstore.window.Login
{
    public partial class ConfirmCodeFPUC : UserControl
    {
        private readonly UserAPIClient _userAPIClient;
        public ConfirmCodeFPUC()
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

        private async Task cofirmcode()
        {
            var code_ = code.Text;
            if (string.IsNullOrEmpty(code_))
            {
                error.Text = "*Vui lòng nhập mã xác nhận";
                error.Visible = true;
                return;
            }
            if (!Regex.IsMatch(code_, @"^\d{6}$"))
            {
                error.Text = "*Mã xác nhận tối đa 6 số";
                error.Visible = true;
                return;
            }

            var confirmcodefpRequest = new ConfirmCodeFPRequest
            {
                sUser_codeFP = code_,
                sUser_tokenFP = Properties.Settings.Default.fp
            };

            var response = await _userAPIClient.CofirmCodeForgotPassword(confirmcodefpRequest);

            if (!response.Status)
            {
                error.Text = response.Message;
                error.Visible = true;
                return;
            }    
            else
            {
                var form = this.TopLevelControl as Login;
                form.changepasswordfp();
            }    
        }

        private void resencode()
        {

        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cofirmcode();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            cofirmcode();
        }

        private void resend_Click(object sender, EventArgs e)
        {
            resencode();
        }
    }
}
