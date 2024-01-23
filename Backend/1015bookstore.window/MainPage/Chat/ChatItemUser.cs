using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.MainPage.Chat
{
    public partial class ChatItemUser : UserControl
    {
        private string content;
        public ChatItemUser(string str)
        {
            InitializeComponent();
            SetMessage(str);


        }

        private void SetMessage(string str)
        {

        }
    }
}
