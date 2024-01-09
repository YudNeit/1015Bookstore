namespace _1015bookstore.window.Login
{
    partial class LoginUC
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
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new CSharp.Winform.UI.Panel();
            this.label1 = new CSharp.Winform.UI.Label();
            this.username = new CSharp.Winform.UI.TextBox();
            this.password = new CSharp.Winform.UI.TextBox();
            this.label2 = new CSharp.Winform.UI.Label();
            this.panel2 = new CSharp.Winform.UI.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.eye = new FontAwesome.Sharp.IconPictureBox();
            this.panel3 = new CSharp.Winform.UI.Panel();
            this.label_u = new System.Windows.Forms.Label();
            this.label3 = new CSharp.Winform.UI.Label();
            this.label4 = new CSharp.Winform.UI.Label();
            this.label6 = new CSharp.Winform.UI.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.error = new CSharp.Winform.UI.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 49);
            this.label5.TabIndex = 1;
            this.label5.Text = "Đăng nhập";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel1.Location = new System.Drawing.Point(25, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 1);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.label1.Location = new System.Drawing.Point(25, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.White;
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username.Font = new System.Drawing.Font("Roboto", 10F);
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.username.Location = new System.Drawing.Point(5, 9);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(330, 21);
            this.username.TabIndex = 0;
            this.username.TabStop = false;
            this.username.Click += new System.EventHandler(this.Typing_Click);
            this.username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.White;
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("Roboto", 10F);
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.password.Location = new System.Drawing.Point(5, 9);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(330, 21);
            this.password.TabIndex = 0;
            this.password.Click += new System.EventHandler(this.Typing_Click);
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.label2.Location = new System.Drawing.Point(25, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.eye);
            this.panel2.Controls.Add(this.password);
            this.panel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel2.Location = new System.Drawing.Point(25, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 40);
            this.panel2.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label7.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 22);
            this.label7.TabIndex = 16;
            this.label7.Text = "********";
            this.label7.Click += new System.EventHandler(this.Typing_Click);
            // 
            // eye
            // 
            this.eye.BackColor = System.Drawing.Color.White;
            this.eye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eye.ForeColor = System.Drawing.SystemColors.ControlText;
            this.eye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.eye.IconColor = System.Drawing.SystemColors.ControlText;
            this.eye.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.eye.Location = new System.Drawing.Point(313, 3);
            this.eye.Name = "eye";
            this.eye.Size = new System.Drawing.Size(32, 32);
            this.eye.TabIndex = 7;
            this.eye.TabStop = false;
            this.eye.Click += new System.EventHandler(this.eye_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label_u);
            this.panel3.Controls.Add(this.username);
            this.panel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel3.Location = new System.Drawing.Point(25, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 40);
            this.panel3.TabIndex = 9;
            // 
            // label_u
            // 
            this.label_u.AutoSize = true;
            this.label_u.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_u.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_u.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.label_u.Location = new System.Drawing.Point(3, 8);
            this.label_u.Name = "label_u";
            this.label_u.Size = new System.Drawing.Size(121, 22);
            this.label_u.TabIndex = 15;
            this.label_u.Text = "Tên đăng nhập";
            this.label_u.Click += new System.EventHandler(this.Typing_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.label3.Location = new System.Drawing.Point(25, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Quên mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(157)))), ((int)(((byte)(96)))));
            this.label4.Location = new System.Drawing.Point(138, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bạn chưa có tài khoản?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(67)))), ((int)(((byte)(48)))));
            this.label6.Location = new System.Drawing.Point(286, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Đăng ký tại đây";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(207)))), ((int)(((byte)(130)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(25, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(350, 30);
            this.button1.TabIndex = 13;
            this.button1.TabStop = false;
            this.button1.Text = "Đăng nhập";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.BackColor = System.Drawing.Color.Transparent;
            this.error.Cursor = System.Windows.Forms.Cursors.Default;
            this.error.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(67)))), ((int)(((byte)(48)))));
            this.error.Location = new System.Drawing.Point(23, 241);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(95, 17);
            this.error.TabIndex = 14;
            this.error.Text = "Đăng ký tại đây";
            this.error.Visible = false;
            // 
            // LoginUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.error);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Name = "LoginUC";
            this.Size = new System.Drawing.Size(400, 350);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private CSharp.Winform.UI.Panel panel1;
        private CSharp.Winform.UI.Label label1;
        private CSharp.Winform.UI.TextBox username;
        private CSharp.Winform.UI.TextBox password;
        private CSharp.Winform.UI.Label label2;
        private CSharp.Winform.UI.Panel panel2;
        private CSharp.Winform.UI.Panel panel3;
        private CSharp.Winform.UI.Label label3;
        private FontAwesome.Sharp.IconPictureBox eye;
        private CSharp.Winform.UI.Label label4;
        private CSharp.Winform.UI.Label label6;
        private System.Windows.Forms.Button button1;
        private CSharp.Winform.UI.Label error;
        private System.Windows.Forms.Label label_u;
        private System.Windows.Forms.Label label7;
    }
}
