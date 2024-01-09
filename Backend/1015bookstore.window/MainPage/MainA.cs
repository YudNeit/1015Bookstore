using _1015bookstore.window.Main;
using _1015bookstore.window.MainPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window
{
    public partial class MainA : Form
    {
        UserControl cart;
        UserControl infor;
        public MainA()
        {
            InitializeComponent();
            var session = Properties.Settings.Default.session;
            if (string.IsNullOrEmpty(session))
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                button2.Visible = true;
            }
            else
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                button2.Visible = false;
            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Application.Exit();
        }

        #region Login
        private void button2_Click(object sender, EventArgs e)
        {

            Login.Login login = new Login.Login();
            login.Show();
            this.Hide();
        }
        #endregion

        #region Logout
        public void logout()
        {
            Properties.Settings.Default.Reset();
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            button2.Visible = true;
            this.Controls.Remove(infor);
            //redirect main
        }
        #endregion

        #region Search
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
            pn.Controls[3].Focus();
            label.Visible = false;
        }
        
        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }
        private void search()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            label_u.Visible = false;
            search_content.Focus();
        }

        #endregion

        #region Cart
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (cart == null)
            {
                var cart_ = new Cart(Properties.Settings.Default.id);
                this.Controls.Add(cart_);
                cart_.Location = new Point(919, 56);
                cart_.BringToFront();
                cart_.Show();
                cart = cart_;

                pictureBox3.BackColor = Color.FromArgb(213, 255, 234);
            }    
            else
            {
                this.Controls.Remove(cart);
                cart = null;
                pictureBox3.BackColor = Color.White;
            }    
        }
        #endregion

        #region Infor
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (infor == null)
            {
                var informini = new InforMini(Properties.Settings.Default.id);
                this.Controls.Add(informini);
                informini.Location = new Point(1143, 56);
                informini.BringToFront();
                informini.Show();
                infor = informini;

                pictureBox4.BackColor = Color.FromArgb(213, 255, 234);
            }
            else
            {
                this.Controls.Remove(infor);
                infor = null;
                pictureBox4.BackColor = Color.White;
            }
        }
        #endregion


    }
}
