using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1015bookstore.window.MainPage.MainProduct
{
    public partial class AdsUC : UserControl
    {
        private List<string> imageFiles;
        private int currentImageIndex;
        public AdsUC()
        {
            InitializeComponent();
            imageFiles = new List<string>();
            currentImageIndex = 0;
            LoadImageFiles();
            ShowImage();
        }
        private void LoadImageFiles()
        {

            string workingDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string imageFolder = Path.Combine(workingDirectory, @"Img\ads");


            if (Directory.Exists(imageFolder))
            {
                imageFiles.AddRange(Directory.GetFiles(imageFolder, "*.jpg"));
                imageFiles.AddRange(Directory.GetFiles(imageFolder, "*.png"));
            }
        }
        private void ShowImage()
        {
            if (imageFiles.Count > 0)
            {
                string imagePath = imageFiles[currentImageIndex];
                pictureBox3.ImageLocation = imagePath;

                PictureBox pic = this.Controls.Find($"picture{currentImageIndex}", true)[0] as PictureBox;
                string workingDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
                string imageFolder = Path.Combine(workingDirectory, @"Img\circle-g.png");
                Image image = Image.FromFile(imageFolder);
                pic.Image = image;
            }
        }

        private void ShowNextImage()
        {
            PictureBox pic = this.Controls.Find($"picture{currentImageIndex}", true)[0] as PictureBox;
            string workingDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string imageFolder = Path.Combine(workingDirectory, @"Img\circle-b.png");
            Image image = Image.FromFile(imageFolder);
            pic.Image = image;

            currentImageIndex = (currentImageIndex + 1) % imageFiles.Count;
            ShowImage();


        }

        private void ShowPreviousImage()
        {
            PictureBox pic = this.Controls.Find($"picture{currentImageIndex}", true)[0] as PictureBox;
            string workingDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string imageFolder = Path.Combine(workingDirectory, @"Img\circle-b.png");
            Image image = Image.FromFile(imageFolder);
            pic.Image = image;

            currentImageIndex = (currentImageIndex - 1 + imageFiles.Count) % imageFiles.Count;
            ShowImage();
        }

        

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            ShowNextImage();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            ShowPreviousImage();
        }
    }
}
