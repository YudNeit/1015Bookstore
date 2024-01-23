namespace _1015bookstore.window.CartPage
{
    partial class TotalUC
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
            this.thanhtoan = new CSharp.Winform.UI.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tongtien = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // thanhtoan
            // 
            this.thanhtoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(207)))), ((int)(((byte)(130)))));
            this.thanhtoan.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanhtoan.ForeColor = System.Drawing.Color.White;
            this.thanhtoan.Location = new System.Drawing.Point(80, 41);
            this.thanhtoan.Name = "thanhtoan";
            this.thanhtoan.Size = new System.Drawing.Size(263, 40);
            this.thanhtoan.TabIndex = 7;
            this.thanhtoan.Text = "Thanh toán";
            this.thanhtoan.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tổng số tiền";
            // 
            // tongtien
            // 
            this.tongtien.AutoSize = true;
            this.tongtien.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tongtien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(67)))), ((int)(((byte)(48)))));
            this.tongtien.Location = new System.Drawing.Point(327, 0);
            this.tongtien.Name = "tongtien";
            this.tongtien.Size = new System.Drawing.Size(95, 24);
            this.tongtien.TabIndex = 8;
            this.tongtien.Text = "100.000đ";
            // 
            // TotalUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tongtien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thanhtoan);
            this.Name = "TotalUC";
            this.Size = new System.Drawing.Size(425, 106);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharp.Winform.UI.Button thanhtoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tongtien;
    }
}
