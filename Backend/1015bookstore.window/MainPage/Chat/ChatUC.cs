using _1015bookstore.window.Business;
using _1015bookstore.window.Emun;
using _1015bookstore.window.ViewModel.Chat;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace _1015bookstore.window.MainPage.Chat
{
    public partial class ChatUC : UserControl
    {
        HubConnection connection;
        UserAPIClient client;
        string path_img;
        ChatAPIClient client_chat;
        public ChatUC()
        {
            InitializeComponent();
            client = new UserAPIClient();
            client_chat = new ChatAPIClient();
            GetImg();
            GetData();

            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7139/chat")
                .Build();
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
            LoadAsync();


        }

        private async void GetData()
        {
            var response = await client_chat.GetTop10(Properties.Settings.Default.session, Properties.Settings.Default.id);
            for (int i = response.Data.Count - 1; i >= 0; i--)
            {
                var item = response.Data[i];
                if (item.stChat_type == MessageType.User)
                {
                    var send = new Outcomming(item);
                    flowLayoutPanel1.Controls.Add(send);
                    send.Show();

                    Point controlLocation = send.Location;

                    // Tính toán vị trí cuộn mới dựa trên vị trí của control
                    int newScrollX = Math.Max(0, controlLocation.X - flowLayoutPanel1.AutoScrollPosition.X);
                    int newScrollY = Math.Max(0, controlLocation.Y - flowLayoutPanel1.AutoScrollPosition.Y);

                    // Đặt vị trí cuộn mới
                    flowLayoutPanel1.AutoScrollPosition = new Point(newScrollX, newScrollY);
                }   
                else
                {
                    var send = new Incomming(item);
                    flowLayoutPanel1.Controls.Add(send);
                    send.Show();

                    Point controlLocation = send.Location;

                    // Tính toán vị trí cuộn mới dựa trên vị trí của control
                    int newScrollX = Math.Max(0, controlLocation.X - flowLayoutPanel1.AutoScrollPosition.X);
                    int newScrollY = Math.Max(0, controlLocation.Y - flowLayoutPanel1.AutoScrollPosition.Y);

                    // Đặt vị trí cuộn mới
                    flowLayoutPanel1.AutoScrollPosition = new Point(newScrollX, newScrollY);
                }    
            }    
        }

        private async void GetImg()
        {
            var response = await client.GetUserById(Properties.Settings.Default.session, Properties.Settings.Default.id);
            path_img = response.Data.sUser_avt;
        }


        private async void LoadAsync()
        {
            connection.On<MessageViewModel>("ReceiveMessage", (message) =>
            {
                if (message.stChat_type == MessageType.Admin)
                {
                    NhanMessage(message);
                }
                
            });
            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                await connection.InvokeAsync("JoinPublish", Properties.Settings.Default.id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void HuyConnect()
        {
            await connection.StopAsync();
        }

        private async void GuiMessageAsync()
        {
            string content =textBox1.Text;
            if (!string.IsNullOrEmpty(content))
            { 
                textBox1.Clear();

                var messagechat = new MessageViewModel
                {
                    gUser_id = Properties.Settings.Default.id,
                    sChat_message = content,
                    sChat_time = DateTime.Now,
                    stChat_type = MessageType.User,
                    sUser_avt = path_img,
                };

                try
                {
                    await connection.InvokeAsync("SendMessage", messagechat);
                }
                catch (Exception ex)
                {
                    textBox1.Text = ex.Message;
                }
                var send = new Outcomming(messagechat);
                flowLayoutPanel1.Controls.Add(send);
                send.Show();

                Point controlLocation = send.Location;

                // Tính toán vị trí cuộn mới dựa trên vị trí của control
                int newScrollX = Math.Max(0, controlLocation.X - flowLayoutPanel1.AutoScrollPosition.X);
                int newScrollY = Math.Max(0, controlLocation.Y - flowLayoutPanel1.AutoScrollPosition.Y);

                // Đặt vị trí cuộn mới
                flowLayoutPanel1.AutoScrollPosition = new Point(newScrollX, newScrollY);

            }
        }

        private void NhanMessage(MessageViewModel message)
        {
            if (!string.IsNullOrEmpty(message.sChat_message))
            {
                var send = new Incomming(message);
                flowLayoutPanel1.Controls.Add(send);
                send.Show();

                Point controlLocation = send.Location;

                // Tính toán vị trí cuộn mới dựa trên vị trí của control
                int newScrollX = Math.Max(0, controlLocation.X - flowLayoutPanel1.AutoScrollPosition.X);
                int newScrollY = Math.Max(0, controlLocation.Y - flowLayoutPanel1.AutoScrollPosition.Y);

                // Đặt vị trí cuộn mới
                flowLayoutPanel1.AutoScrollPosition = new Point(newScrollX, newScrollY);

            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            GuiMessageAsync();
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GuiMessageAsync();
            }
        }
    }
}
