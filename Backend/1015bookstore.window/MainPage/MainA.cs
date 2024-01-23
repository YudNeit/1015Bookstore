using _1015bookstore.window.Business;
using _1015bookstore.window.CartPage.Cart;
using _1015bookstore.window.CartPage.Order;
using _1015bookstore.window.InformationPage;
using _1015bookstore.window.Main;
using _1015bookstore.window.MainPage;
using _1015bookstore.window.MainPage.Catemini;
using _1015bookstore.window.MainPage.Chat;
using _1015bookstore.window.MainPage.Informations;
using _1015bookstore.window.MainPage.MainProduct;
using _1015bookstore.window.ProductPage;
using _1015bookstore.window.ProductPage.ProductCateAndSearch;
using _1015bookstore.window.ViewModel.Catalog.Orders;
using _1015bookstore.window.ViewModel.Catalog.Products;
using _1015bookstore.window.ViewModel.UserAddresses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _1015bookstore.window
{
    public partial class MainA : Form
    {
        UserControl cart;
        UserControl infor;
        UserControl currentUC;
        UserControl updateAddressOpen;
        UserControl createAddressOpen;
        UserControl cate;
        UserControl chat;

        private ProductAPIClient client;

        public MainA()
        {
            InitializeComponent();
            var session = Properties.Settings.Default.session;
            if (string.IsNullOrEmpty(session))
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                button2.Visible = true;
            }
            else
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                button2.Visible = false;
            }
            client = new ProductAPIClient();
            homepage();
        }
        private void close_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Application.Exit();
        }

        public UserControl GetCurrentUC()
        {
            return currentUC;
        }

        #region Login
        public void login()
        {
            Login.Login login = new Login.Login();
            login.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            login();
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
            infor = null;
            //redirect main
            homepage();
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
        private async void search()
        {
            var list = await client.GetProductByKeyword(Properties.Settings.Default.session, search_content.Text);
            CateAndSearchPage($"Danh sách kết quả tìm kiếm {search_content.Text}", list.Data);
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

        #region cate
        //16, 59
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (cate == null)
            {
                var cate_ = new Catenho();
                this.Controls.Add(cate_);
                cate_.Location = new Point(16, 59);
                cate_.BringToFront();
                cate_.Show();
                cate = cate_;

                pictureBox2.BackColor = Color.FromArgb(213, 255, 234);
            }
            else
            {
                this.Controls.Remove(cate);
                cate = null;
                pictureBox2.BackColor = Color.White;
            }
        }

        public void close_catemini()
        {
            this.Controls.Remove(cate);
            cate = null;
            pictureBox2.BackColor = Color.White;
        }    

        #endregion


        #region Cart
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (cart == null)
            {
                var cart_ = new Cart(Properties.Settings.Default.id);
                this.Controls.Add(cart_);
                cart_.Location = new Point(979, 56);
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
                informini.Location = new Point(1212, 56);
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

        public void inforpage()
        {
            this.Controls.Remove(infor);
            pictureBox4.BackColor = Color.White;
            infor = null;

            body.Controls.Remove(currentUC);

            var page = new Information(Properties.Settings.Default.id);
            
            body.Controls.Add(page);
            page.Location = new Point(0, 0);
            page.Show();
            currentUC = page;

            
        }
        #endregion

        #region CreateAddress
        public void open_createaddress(Guid user_id)
        {
            var createaddressUC = new AddressCreate(user_id);
            this.Controls.Add(createaddressUC);
            createaddressUC.Location = new Point(440, 140);
            createaddressUC.BringToFront();
            createaddressUC.Show();

            createAddressOpen = createaddressUC;
        }
        public void close_createaddress()
        {
            this.Controls.Remove(createAddressOpen);
        }
        #endregion

        #region UpdateAddress
        public void open_updateaddress(AddressViewModel address)
        {
            var updateaddressUC = new AddressUpdate(address);
            this.Controls.Add(updateaddressUC);
            updateaddressUC.Location = new Point(440, 140);
            updateaddressUC.BringToFront();
            updateaddressUC.Show();

            updateAddressOpen = updateaddressUC;
        }
        public void close_updateaddress()
        {
            this.Controls.Remove(updateAddressOpen);
        }
        #endregion

        #region body
        public void homepage()
        {
            if (currentUC != null)
            {
                body.Controls.Remove(currentUC);

                var page = new HomePageUC();
                body.Controls.Add(page);
                page.Location = new Point(0,0);
                page.Show();

                currentUC = page;
            }
            else
            {
                var page = new HomePageUC();
                body.Controls.Add(page);
                page.Location = new Point(0, 0);
                page.Show();

                currentUC = page;
            }    
           
        }
        #endregion

        #region returnHomePage
        private void returnHomePage(object sender, EventArgs e)
        {
            homepage();
        }
        #endregion

        #region CateAndSearchPage
        public void CateAndSearchPage(string name, List<ProductViewModel> listproduct)
        {
            body.Controls.Remove(currentUC);

            var page = new CateAndSearchPage(name, listproduct);
            body.Controls.Add(page);
            page.Location = new Point(0, 0);
            page.Show();

            currentUC = page;
        }
        #endregion

        #region ProductViewPage

        public void ProductViewPage(ProductViewModel product)
        {
            body.Controls.Remove(currentUC);

            var page = new ProductViewPage(product);
            body.Controls.Add(page);
            page.Location = new Point(0, 0);
            page.Show();

            currentUC = page;
        }

        #endregion

        #region CartPage

        public void CartPage()
        {
            body.Controls.Remove(currentUC);

            var page = new MyCart();

            body.Controls.Add(page);
            page.Location = new Point(0, 0);
            page.Show();

            currentUC = page;

            this.Controls.Remove(cart);
            cart = null;
            pictureBox3.BackColor = Color.White;
        }

        #endregion

        #region OrderPage
        public void OrderPage(OrderViewModel order)
        {
            body.Controls.Remove(currentUC);

            var page = new MyOrder(order);
            body.Controls.Add(page);
            page.Location = new Point(0, 0);
            page.Show();

            currentUC = page;
        }
        #endregion

        #region Chat
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (chat == null)
            {
                var chat_ = new ChatUC();
                this.Controls.Add(chat_);
                chat_.Location = new Point(831, 58);
                chat_.BringToFront();
                chat_.Show();
                chat = chat_;

                pictureBox5.BackColor = Color.FromArgb(213, 255, 234);
            }
            else
            {
                var chatuc = chat as ChatUC;
                chatuc.HuyConnect();
                this.Controls.Remove(chat);
                chat = null;
                pictureBox5.BackColor = Color.White;
            }
        }
        #endregion
    }
}
