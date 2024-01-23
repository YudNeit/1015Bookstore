namespace _1015bookstore.window.MainPage
{
    partial class CartItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartItem));
            this.pic = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.amount = new System.Windows.Forms.Label();
            this.minus = new FontAwesome.Sharp.IconPictureBox();
            this.plus = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plus)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(8, 4);
            this.pic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(50, 50);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.name.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(60, 4);
            this.name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(190, 28);
            this.name.TabIndex = 1;
            this.name.Text = "Combo Sách Hướng Dẫn Nói Và Viết \r\nVăn - Nghị Luận Xã Hội ...";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(78)))), ((int)(((byte)(52)))));
            this.price.Location = new System.Drawing.Point(60, 38);
            this.price.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(59, 15);
            this.price.TabIndex = 2;
            this.price.Text = "000.000đ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(261, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(12, 12);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // amount
            // 
            this.amount.AutoSize = true;
            this.amount.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount.Location = new System.Drawing.Point(234, 37);
            this.amount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(14, 15);
            this.amount.TabIndex = 4;
            this.amount.Text = "5";
            // 
            // minus
            // 
            this.minus.BackColor = System.Drawing.Color.White;
            this.minus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.minus.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.minus.IconColor = System.Drawing.SystemColors.ControlText;
            this.minus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.minus.IconSize = 20;
            this.minus.Location = new System.Drawing.Point(209, 35);
            this.minus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(20, 20);
            this.minus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minus.TabIndex = 6;
            this.minus.TabStop = false;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // plus
            // 
            this.plus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plus.Image = ((System.Drawing.Image)(resources.GetObject("plus.Image")));
            this.plus.Location = new System.Drawing.Point(253, 35);
            this.plus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(20, 20);
            this.plus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.plus.TabIndex = 7;
            this.plus.TabStop = false;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel1.Location = new System.Drawing.Point(7, 57);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 1);
            this.panel1.TabIndex = 8;
            // 
            // CartItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.price);
            this.Controls.Add(this.name);
            this.Controls.Add(this.pic);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CartItem";
            this.Size = new System.Drawing.Size(282, 60);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label amount;
        private FontAwesome.Sharp.IconPictureBox minus;
        private System.Windows.Forms.PictureBox plus;
        private System.Windows.Forms.Panel panel1;
    }
}
