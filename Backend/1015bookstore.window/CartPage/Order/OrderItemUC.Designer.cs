namespace _1015bookstore.window.CartPage.Order
{
    partial class OrderItemUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderItemUC));
            this.sotien = new System.Windows.Forms.Label();
            this.dongia = new System.Windows.Forms.Label();
            this.tensanpham = new System.Windows.Forms.Label();
            this.avatarsanpham = new System.Windows.Forms.PictureBox();
            this.soluong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatarsanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // sotien
            // 
            this.sotien.AutoSize = true;
            this.sotien.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(207)))), ((int)(((byte)(130)))));
            this.sotien.Location = new System.Drawing.Point(941, 14);
            this.sotien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(77, 20);
            this.sotien.TabIndex = 22;
            this.sotien.Text = "100.000đ";
            // 
            // dongia
            // 
            this.dongia.AutoSize = true;
            this.dongia.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dongia.Location = new System.Drawing.Point(566, 18);
            this.dongia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(59, 15);
            this.dongia.TabIndex = 23;
            this.dongia.Text = "100.000đ";
            // 
            // tensanpham
            // 
            this.tensanpham.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tensanpham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tensanpham.Location = new System.Drawing.Point(142, 14);
            this.tensanpham.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tensanpham.Name = "tensanpham";
            this.tensanpham.Size = new System.Drawing.Size(289, 48);
            this.tensanpham.TabIndex = 24;
            this.tensanpham.Text = "Bài Tập Trắc Nghiệm Tiếng Anh 9 Theo Chương Trình Thí Điểm (Không Đáp Án)";
            // 
            // avatarsanpham
            // 
            this.avatarsanpham.Image = ((System.Drawing.Image)(resources.GetObject("avatarsanpham.Image")));
            this.avatarsanpham.Location = new System.Drawing.Point(27, 13);
            this.avatarsanpham.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.avatarsanpham.Name = "avatarsanpham";
            this.avatarsanpham.Size = new System.Drawing.Size(90, 90);
            this.avatarsanpham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarsanpham.TabIndex = 18;
            this.avatarsanpham.TabStop = false;
            // 
            // soluong
            // 
            this.soluong.AutoSize = true;
            this.soluong.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.soluong.Location = new System.Drawing.Point(818, 14);
            this.soluong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(14, 15);
            this.soluong.TabIndex = 22;
            this.soluong.Text = "1";
            // 
            // OrderItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.tensanpham);
            this.Controls.Add(this.avatarsanpham);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OrderItemUC";
            this.Size = new System.Drawing.Size(1080, 120);
            ((System.ComponentModel.ISupportInitialize)(this.avatarsanpham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label sotien;
        private System.Windows.Forms.Label dongia;
        private System.Windows.Forms.Label tensanpham;
        private System.Windows.Forms.PictureBox avatarsanpham;
        private System.Windows.Forms.Label soluong;
    }
}
