using _1015bookstore.window.ViewModel.Chat;
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
    public partial class Incomming : UserControl
    {

        MessageViewModel message;
        public Incomming(MessageViewModel message)
        {
            InitializeComponent();
            this.message = message;
            Setdata();
        }

        private void Setdata()
        {
            label1.Text = $"{message.sChat_time.Day}-{message.sChat_time.Month}-{message.sChat_time.Year} {message.sChat_time.Hour}:{message.sChat_time.Minute}";
            label2.Text = message.sChat_message;
            label2.Height = GetTextHeight(label2) + 5;
            panel1.Height = label2.Bottom + 10;
            this.Height = panel1.Bottom + 10;
        }

        public int GetTextHeight(Label label)
        {
            using(Graphics g = label.CreateGraphics())
            {
                SizeF size = g.MeasureString(label.Text, label.Font, 258);
                return (int)Math.Ceiling(size.Height);
            }
        }


    }
}
