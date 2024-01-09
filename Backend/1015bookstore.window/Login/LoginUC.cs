using _1015bookstore.window.Business;
using _1015bookstore.window.ViewModel.User;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.Login
{
    public partial class LoginUC : UserControl
    {
        private readonly UserAPIClient _userAPIClient;

        public LoginUC()
        {
            InitializeComponent();
            _userAPIClient = new UserAPIClient();
        }

        private void eye_Click(object sender, EventArgs e)
        {
            if (eye.BackColor == Color.White)
            {
                password.PasswordChar = '\0';
                eye.BackColor = Color.Transparent;
                eye.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
            else if (eye.BackColor == Color.Transparent)
            {
                password.PasswordChar = '*';
                eye.BackColor = Color.White;
                eye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
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

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private async Task login()
        {
            var username_ = username.Text;
            var password_ = password.Text;
            if (string.IsNullOrEmpty(username_) || string.IsNullOrEmpty(password_)) 
            {
                error.Text = "*Vui lòng nhập username và password";
                error.Visible = true;
                return;
            }

            var loginrequest = new LoginRequest
            {
                sUser_username = username_,
                sUser_password = password_,
            };

            var response = await _userAPIClient.Authenticate(loginrequest);
            if (!response.Status)
            {
                error.Text = "*Tên đăng nhập hoặc mật khẩu không đúng";
                error.Visible = true;
                return;
            }    
            else
            {
                var token = (string)response.Data["sUser_tokenL"];
                Properties.Settings.Default.session = token;
                var id = (string)response.Data["gUser_id"];
                Properties.Settings.Default.id = new Guid(id);
                var userPrincipal = this.ValidateToken(token);
                var roleClaim = userPrincipal.FindFirst("Role");
                var roleValue = roleClaim.Value;
                Properties.Settings.Default.role = roleValue;

                var form = this.TopLevelControl as Login;
                form.main();
            }


        }



        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            Microsoft.IdentityModel.Tokens.SecurityToken validatedToken;

            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.RequireAudience = false;
            validationParameters.ValidateAudience = false;
            validationParameters.ValidateIssuer = false;

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidateIssuerSigningKey = true;

            validationParameters.IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("0123456789ABCDEF"));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            var form = this.TopLevelControl as Login;
            form.register();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var form = this.TopLevelControl as Login;
            form.forgotpassword();
        }
    }
}
