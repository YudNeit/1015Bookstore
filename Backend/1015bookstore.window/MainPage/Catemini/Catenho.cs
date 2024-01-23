using _1015bookstore.window.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.MainPage.Catemini
{
    public partial class Catenho : UserControl
    {
        CategoryAPIClient client;
        ProductAPIClient clientProduct;

        public Catenho()
        {
            InitializeComponent();
            client = new CategoryAPIClient();
            clientProduct = new ProductAPIClient();
            GetTaskbar();
        }


        private async void GetTaskbar()
        {
            var response = await client.GetTaskbar(Properties.Settings.Default.session);

            int count = 0;
            foreach (var item in response.Data)
            {
                count++;
                var root = new TreeNode()
                {
                    Text = item.sCate_name,
                    ForeColor = Color.FromArgb(140, 140, 140),
                };

                if (item.iCate_parent_id == 0 && item.lCate_childs.Count == 0)
                {
                    root.ImageIndex =item.iCate_parent_id;
                }

                if (count != 1)
                {
                    treeView1.Height = treeView1.Height + 17;
                }    

                if (item.lCate_childs.Count != 0)
                {
                    foreach(var child in item.lCate_childs)
                    {
                        root.Nodes.Add(new TreeNode() { 
                            Text = child.sCate_name,
                            ForeColor = Color.FromArgb(140, 140, 140),
                            NodeFont = new Font("Roboto", 9, FontStyle.Regular),
                            ImageIndex = child.iCate_id,
                        });
                    }    
                }   
                treeView1.Nodes.Add(root);
            }

            this.Height = treeView1.Bottom + 10;
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            int cout = e.Node.GetNodeCount(true);
            treeView1.Height = treeView1.Height + cout * 17;
            this.Height = treeView1.Bottom + 10;
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            int cout = e.Node.GetNodeCount(true);
            treeView1.Height = treeView1.Height - cout * 17;
            this.Height = treeView1.Bottom + 10;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node.ImageIndex;
        }

        private async void Categorypage(string name, int id)
        {
            var response = await clientProduct.GetProductByCate(Properties.Settings.Default.session, id);
            var form = this.TopLevelControl as MainA;
            form.close_catemini();
            form.CateAndSearchPage(name, response.Data);

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var index = e.Node.ImageIndex;
            if (index == -1)
            {
                return;
            }
            Categorypage(e.Node.Text, index);
        }
    }
}
