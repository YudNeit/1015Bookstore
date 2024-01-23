using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.Login
{
    public partial class Login : Form
    {
        UserControl currentUC;
        public Login()
        {
            InitializeComponent();
            var loginuc = new LoginUC();
            loginuc.Location = new Point(900, 156);
            this.Controls.Add(loginuc);
            loginuc.BringToFront();
            loginuc.Show();

            currentUC = loginuc;
        }

        public void register()
        {
            this.Controls.Remove(currentUC);

            var registeruc = new RegisterUC();
            registeruc.Location = new Point(900, 90);
            this.Controls.Add(registeruc);
            registeruc.BringToFront();
            registeruc.Show();

            currentUC = registeruc;
        }

        public void login()
        {
            this.Controls.Remove(currentUC);

            var loginuc = new LoginUC();
            loginuc.Location = new Point(900, 156);
            this.Controls.Add(loginuc);
            loginuc.BringToFront();
            loginuc.Show();

            currentUC = loginuc;
        }

        public void forgotpassword()
        {
            this.Controls.Remove(currentUC);

            var forgotpassword = new ForgotPasswordUC();
            forgotpassword.Location = new Point(900, 156);
            this.Controls.Add(forgotpassword);
            forgotpassword.BringToFront();
            forgotpassword.Show();

            currentUC = forgotpassword;
        }

        public void confirmpasswordfp()
        {
            this.Controls.Remove(currentUC);

            var confirmpasswordfp = new ConfirmCodeFPUC();
            confirmpasswordfp.Location = new Point(900, 156);
            this.Controls.Add(confirmpasswordfp);
            confirmpasswordfp.BringToFront();
            confirmpasswordfp.Show();

            currentUC = confirmpasswordfp;
        }

        public void changepasswordfp()
        {
            this.Controls.Remove(currentUC);

            var changepasswordfp = new ChangePasswordFPUC();
            changepasswordfp.Location = new Point(900, 156);
            this.Controls.Add(changepasswordfp);
            changepasswordfp.BringToFront();
            changepasswordfp.Show();

            currentUC = changepasswordfp;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Application.Exit();
        }
    
        public void main()
        {
            MainA main = new MainA();
            main.Show();
            this.Hide();
        }

        public void return_main(object sender, EventArgs e)
        {
            main();
        }
    }
}
