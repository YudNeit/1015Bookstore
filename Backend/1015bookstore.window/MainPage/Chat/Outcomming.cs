using _1015bookstore.window.ViewModel.Chat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.MainPage.Chat
{
    public partial class Outcomming : UserControl
    {

        private string filepath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img\user-content");
        MessageViewModel message;
        public Outcomming(MessageViewModel message)
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
            SetPicture();
        }

        private void SetPicture()
        {
            if (message.sUser_avt == null)
            {
                string url = Path.Combine(filepath, "default.png");
                Image image = Image.FromFile(url);
                pictureBox1.Image = image;
            }
            else
            {
                string url = Path.Combine(filepath, message.sUser_avt);
                Image image = Image.FromFile(url);
                pictureBox1.Image = image;
            }

        }

        public int GetTextHeight(Label label)
        {
            using (Graphics g = label.CreateGraphics())
            {
                SizeF size = g.MeasureString(label.Text, label.Font, 258);
                return (int)Math.Ceiling(size.Height);
            }
        }
    }
}
