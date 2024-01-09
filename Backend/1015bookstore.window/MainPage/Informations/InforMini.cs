using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.MainPage
{
    public partial class InforMini : UserControl
    {
        private Guid user_id;
        public InforMini(Guid user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
        }
        private void Label_MouseHover(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(48, 207, 130);
            label.Font = new Font("Roboto", 9, FontStyle.Bold);
        }
        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.FromArgb(140,140,140);
            label.Font = new Font("Roboto", 9, FontStyle.Regular);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var form = this.TopLevelControl as MainA;
            form.logout();
        }
    }
}
