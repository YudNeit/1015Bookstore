namespace _1015bookstore.window.CartPage
{
    partial class CartItemUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartItemUC));
            this.xoa = new System.Windows.Forms.PictureBox();
            this.avatarsanpham = new System.Windows.Forms.PictureBox();
            this.tensanpham = new System.Windows.Forms.Label();
            this.dongia = new System.Windows.Forms.Label();
            this.soluong = new System.Windows.Forms.TextBox();
            this.cong = new CSharp.Winform.UI.Button();
            this.tru = new CSharp.Winform.UI.Button();
            this.sotien = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarsanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // xoa
            // 
            this.xoa.Image = ((System.Drawing.Image)(resources.GetObject("xoa.Image")));
            this.xoa.Location = new System.Drawing.Point(868, 9);
            this.xoa.Margin = new System.Windows.Forms.Padding(2);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(19, 19);
            this.xoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.xoa.TabIndex = 0;
            this.xoa.TabStop = false;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // avatarsanpham
            // 
            this.avatarsanpham.Image = ((System.Drawing.Image)(resources.GetObject("avatarsanpham.Image")));
            this.avatarsanpham.Location = new System.Drawing.Point(54, 12);
            this.avatarsanpham.Margin = new System.Windows.Forms.Padding(2);
            this.avatarsanpham.Name = "avatarsanpham";
            this.avatarsanpham.Size = new System.Drawing.Size(120, 120);
            this.avatarsanpham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarsanpham.TabIndex = 0;
            this.avatarsanpham.TabStop = false;
            // 
            // tensanpham
            // 
            this.tensanpham.AutoSize = true;
            this.tensanpham.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tensanpham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tensanpham.Location = new System.Drawing.Point(220, 12);
            this.tensanpham.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tensanpham.Name = "tensanpham";
            this.tensanpham.Size = new System.Drawing.Size(339, 34);
            this.tensanpham.TabIndex = 1;
            this.tensanpham.Text = "Bài Tập Trắc Nghiệm Tiếng Anh 9 Theo Chương Trình Thí \r\nĐiểm (Không Đáp Án)";
            // 
            // dongia
            // 
            this.dongia.AutoSize = true;
            this.dongia.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(78)))), ((int)(((byte)(52)))));
            this.dongia.Location = new System.Drawing.Point(219, 54);
            this.dongia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(77, 20);
            this.dongia.TabIndex = 1;
            this.dongia.Text = "100.000đ";
            // 
            // soluong
            // 
            this.soluong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.soluong.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(620, 12);
            this.soluong.Margin = new System.Windows.Forms.Padding(2);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(48, 20);
            this.soluong.TabIndex = 17;
            this.soluong.Text = "1";
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cong
            // 
            this.cong.BackColor = System.Drawing.Color.White;
            this.cong.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cong.ForeColor = System.Drawing.Color.Black;
            this.cong.Location = new System.Drawing.Point(669, 11);
            this.cong.Margin = new System.Windows.Forms.Padding(2);
            this.cong.Name = "cong";
            this.cong.Size = new System.Drawing.Size(24, 23);
            this.cong.TabIndex = 15;
            this.cong.Text = "+";
            this.cong.UseVisualStyleBackColor = false;
            this.cong.Click += new System.EventHandler(this.cong_Click);
            // 
            // tru
            // 
            this.tru.BackColor = System.Drawing.Color.White;
            this.tru.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tru.ForeColor = System.Drawing.Color.Black;
            this.tru.Location = new System.Drawing.Point(594, 11);
            this.tru.Margin = new System.Windows.Forms.Padding(2);
            this.tru.Name = "tru";
            this.tru.Size = new System.Drawing.Size(24, 23);
            this.tru.TabIndex = 16;
            this.tru.Text = "-";
            this.tru.UseVisualStyleBackColor = false;
            this.tru.Click += new System.EventHandler(this.tru_Click);
            // 
            // sotien
            // 
            this.sotien.AutoSize = true;
            this.sotien.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(207)))), ((int)(((byte)(130)))));
            this.sotien.Location = new System.Drawing.Point(748, 9);
            this.sotien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(93, 24);
            this.sotien.TabIndex = 1;
            this.sotien.Text = "100.000đ";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 65);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CartItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.cong);
            this.Controls.Add(this.tru);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.tensanpham);
            this.Controls.Add(this.avatarsanpham);
            this.Controls.Add(this.xoa);
            this.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.Name = "CartItemUC";
            this.Size = new System.Drawing.Size(900, 150);
            ((System.ComponentModel.ISupportInitialize)(this.xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarsanpham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox xoa;
        private System.Windows.Forms.PictureBox avatarsanpham;
        private System.Windows.Forms.Label tensanpham;
        private System.Windows.Forms.Label dongia;
        private System.Windows.Forms.TextBox soluong;
        private CSharp.Winform.UI.Button cong;
        private CSharp.Winform.UI.Button tru;
        private System.Windows.Forms.Label sotien;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
