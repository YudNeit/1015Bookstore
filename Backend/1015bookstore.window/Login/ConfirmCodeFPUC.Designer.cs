namespace _1015bookstore.window.Login
{
    partial class ConfirmCodeFPUC
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
            this.panel3 = new CSharp.Winform.UI.Panel();
            this.label_u = new System.Windows.Forms.Label();
            this.code = new CSharp.Winform.UI.TextBox();
            this.error = new CSharp.Winform.UI.Label();
            this.label2 = new CSharp.Winform.UI.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new CSharp.Winform.UI.Label();
            this.panel1 = new CSharp.Winform.UI.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.resend = new CSharp.Winform.UI.Label();
            this.time = new CSharp.Winform.UI.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label_u);
            this.panel3.Controls.Add(this.code);
            this.panel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel3.Location = new System.Drawing.Point(25, 157);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 40);
            this.panel3.TabIndex = 25;
            // 
            // label_u
            // 
            this.label_u.AutoSize = true;
            this.label_u.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_u.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_u.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.label_u.Location = new System.Drawing.Point(3, 9);
            this.label_u.Name = "label_u";
            this.label_u.Size = new System.Drawing.Size(104, 22);
            this.label_u.TabIndex = 15;
            this.label_u.Text = "Mã xác nhận";
            this.label_u.Click += new System.EventHandler(this.Typing_Click);
            // 
            // code
            // 
            this.code.BackColor = System.Drawing.Color.White;
            this.code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.code.Font = new System.Drawing.Font("Roboto", 10F);
            this.code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.code.Location = new System.Drawing.Point(5, 9);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(330, 21);
            this.code.TabIndex = 0;
            this.code.TabStop = false;
            this.code.Click += new System.EventHandler(this.Typing_Click);
            this.code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.BackColor = System.Drawing.Color.Transparent;
            this.error.Cursor = System.Windows.Forms.Cursors.Default;
            this.error.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(67)))), ((int)(((byte)(48)))));
            this.error.Location = new System.Drawing.Point(25, 205);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(95, 17);
            this.error.TabIndex = 28;
            this.error.Text = "Đăng ký tại đây";
            this.error.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 34);
            this.label2.TabIndex = 27;
            this.label2.Text = "Chúng tôi đã gửi mã xác nhận qua email xxxxx@gmail.com, \r\nhãy điền mã xác nhận để" +
    " tiến hành khôi phục mật khẩu.";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(207)))), ((int)(((byte)(130)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(25, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(350, 30);
            this.button1.TabIndex = 26;
            this.button1.TabStop = false;
            this.button1.Text = "Gửi mã xác nhận";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.label1.Location = new System.Drawing.Point(25, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Mã xác nhận:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel1.Location = new System.Drawing.Point(23, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 1);
            this.panel1.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(18, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 42);
            this.label5.TabIndex = 22;
            this.label5.Text = "Quên mật khẩu";
            // 
            // resend
            // 
            this.resend.AutoSize = true;
            this.resend.BackColor = System.Drawing.Color.Transparent;
            this.resend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resend.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(67)))), ((int)(((byte)(48)))));
            this.resend.Location = new System.Drawing.Point(22, 302);
            this.resend.Name = "resend";
            this.resend.Size = new System.Drawing.Size(119, 17);
            this.resend.TabIndex = 29;
            this.resend.Text = "Gửi lại mã xác nhận";
            this.resend.Click += new System.EventHandler(this.resend_Click);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.time.Location = new System.Drawing.Point(155, 303);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(39, 17);
            this.time.TabIndex = 30;
            this.time.Text = "03:00";
            this.time.Visible = false;
            // 
            // ConfirmCodeFPUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.time);
            this.Controls.Add(this.resend);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.error);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Name = "ConfirmCodeFPUC";
            this.Size = new System.Drawing.Size(400, 350);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharp.Winform.UI.Panel panel3;
        private System.Windows.Forms.Label label_u;
        private CSharp.Winform.UI.TextBox code;
        private CSharp.Winform.UI.Label error;
        private CSharp.Winform.UI.Label label2;
        private System.Windows.Forms.Button button1;
        private CSharp.Winform.UI.Label label1;
        private CSharp.Winform.UI.Panel panel1;
        private System.Windows.Forms.Label label5;
        private CSharp.Winform.UI.Label resend;
        private CSharp.Winform.UI.Label time;
    }
}
