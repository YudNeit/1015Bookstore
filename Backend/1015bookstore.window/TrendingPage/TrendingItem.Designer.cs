namespace _1015bookstore.window.TrendingPage
{
    partial class TrendingItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrendingItem));
            this.avatar = new System.Windows.Forms.PictureBox();
            this.tensanpham = new System.Windows.Forms.Label();
            this.dongia = new System.Windows.Forms.Label();
            this.buy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // avatar
            // 
            this.avatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatar.Image = ((System.Drawing.Image)(resources.GetObject("avatar.Image")));
            this.avatar.Location = new System.Drawing.Point(4, 6);
            this.avatar.Margin = new System.Windows.Forms.Padding(2);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(180, 180);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            this.avatar.Click += new System.EventHandler(this.avatar_Click);
            // 
            // tensanpham
            // 
            this.tensanpham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tensanpham.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tensanpham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tensanpham.Location = new System.Drawing.Point(3, 191);
            this.tensanpham.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tensanpham.Name = "tensanpham";
            this.tensanpham.Size = new System.Drawing.Size(183, 31);
            this.tensanpham.TabIndex = 1;
            this.tensanpham.Text = "Complete IELTS B1 Student\'s Book with answer with CD-ROM";
            this.tensanpham.Click += new System.EventHandler(this.tensanpham_Click);
            // 
            // dongia
            // 
            this.dongia.AutoSize = true;
            this.dongia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dongia.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(78)))), ((int)(((byte)(52)))));
            this.dongia.Location = new System.Drawing.Point(2, 226);
            this.dongia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(77, 20);
            this.dongia.TabIndex = 1;
            this.dongia.Text = "100.000đ";
            this.dongia.Click += new System.EventHandler(this.dongia_Click);
            // 
            // buy
            // 
            this.buy.AutoSize = true;
            this.buy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buy.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buy.Location = new System.Drawing.Point(160, 230);
            this.buy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.buy.Name = "buy";
            this.buy.Size = new System.Drawing.Size(21, 15);
            this.buy.TabIndex = 1;
            this.buy.Text = "10";
            this.buy.Click += new System.EventHandler(this.buy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label1.Location = new System.Drawing.Point(115, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đã bán";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TrendingItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.buy);
            this.Controls.Add(this.tensanpham);
            this.Controls.Add(this.avatar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0, 16, 28, 0);
            this.Name = "TrendingItem";
            this.Size = new System.Drawing.Size(190, 260);
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Label tensanpham;
        private System.Windows.Forms.Label dongia;
        private System.Windows.Forms.Label buy;
        private System.Windows.Forms.Label label1;
    }
}
