using _1015bookstore.window.Business;
using _1015bookstore.window.MainPage.Informations;
using _1015bookstore.window.ViewModel.User;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.InformationPage
{
    public partial class InforDetail : UserControl
    {
        private string filepath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"Img\user-content");
        UserViewModel viewModel;
        FormFile tmp;
        UserAPIClient userAPIClient;
        public InforDetail(UserViewModel user)
        {
            InitializeComponent();
            userAPIClient = new UserAPIClient();
            viewModel = user;
            setdata(user);
        }

        private void setdata(UserViewModel user)
        {
            username.Text = user.sUser_username;
            ho.Text = user.sUser_firstname;
            ten.Text = user.sUser_lastname;
            email.Text = user.sUser_email;
            sdt.Text = user.sUser_phonenumber == null ? null : user.sUser_phonenumber;
            if (user.bUser_sex != null)
            {
                if (user.bUser_sex == false)
                {
                    nu.Checked = true;
                }    
                
            }

            ngaysinh.Value = user.dtUser_dob;
            
            if (user.sUser_avt == null)
            {
                label4.Visible = true;
            }    
            else
            {
                Image image = Image.FromFile(Path.Combine(filepath, user.sUser_avt));
                avt.Image = image;
            }    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var openfile = new System.Windows.Forms.OpenFileDialog();
            openfile.Title = "Chọn một tập tin";
            openfile.Filter = "Hình ảnh PNG (*.png)|*.png|Hình ảnh JPG (*.jpg)|*.jpg|Tất cả các tập tin (*.*)|*.*";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                label4.Visible = false;
                string filePath = openfile.FileName;
                Image image = Image.FromFile(filePath);
                avt.Image = image;
                tmp = new FormFile(openfile.OpenFile(), 0, openfile.OpenFile().Length, null, Path.GetFileName(openfile.FileName));
            }
        }

        private async Task saveinfor()
        {
            if (string.IsNullOrEmpty(ho.Text) || string.IsNullOrEmpty(ten.Text) || string.IsNullOrEmpty(sdt.Text))
            {
                error.Text = "*Vui lòng nhập đầy đủ thông tin";
                error.Visible = true;
                return;
            }
            if (tmp == null && viewModel.sUser_avt == null)
            {
                error.Text = "*Vui lòng chọn ảnh đại diện";
                error.Visible = true;
                return;
            }

            var request = new UserUpdateRequest
            {
                gUser_id = viewModel.gUser_id,
                sUser_firstname = ho.Text,
                sUser_lastname = ten.Text,
                sUser_phonenumber = sdt.Text,
                dtUser_dob = ngaysinh.Value,
                bUser_sex = nam.Checked,
                sUser_avt = tmp
            };

            var response = await userAPIClient.UpdateUser(request, Properties.Settings.Default.session);
            if (response.Status)
            {
                var inforpage = this.Parent as Information;
                inforpage.afterupdateinfor();
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
           await saveinfor();
        }

        private void InforDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
