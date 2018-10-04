namespace ProjectQUANLYSINHVIEN
{
    partial class fDangky
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTendangnhap = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbMatkhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDangky = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 133);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng ký tài khoản quản lý";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbTendangnhap);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 37);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đăng nhập :";
            // 
            // txbTendangnhap
            // 
            this.txbTendangnhap.Location = new System.Drawing.Point(121, 8);
            this.txbTendangnhap.Name = "txbTendangnhap";
            this.txbTendangnhap.Size = new System.Drawing.Size(233, 20);
            this.txbTendangnhap.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbMatkhau);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(3, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 37);
            this.panel3.TabIndex = 2;
            // 
            // txbMatkhau
            // 
            this.txbMatkhau.Location = new System.Drawing.Point(121, 8);
            this.txbMatkhau.Name = "txbMatkhau";
            this.txbMatkhau.Size = new System.Drawing.Size(233, 20);
            this.txbMatkhau.TabIndex = 1;
            this.txbMatkhau.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu  :";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnHuy);
            this.panel4.Controls.Add(this.btnDangky);
            this.panel4.Location = new System.Drawing.Point(3, 89);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(379, 34);
            this.panel4.TabIndex = 3;
            // 
            // btnDangky
            // 
            this.btnDangky.Location = new System.Drawing.Point(198, 3);
            this.btnDangky.Name = "btnDangky";
            this.btnDangky.Size = new System.Drawing.Size(75, 23);
            this.btnDangky.TabIndex = 0;
            this.btnDangky.Text = "Đăng ký";
            this.btnDangky.UseVisualStyleBackColor = true;
            this.btnDangky.Click += new System.EventHandler(this.btnDangky_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(279, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // fDangky
            // 
            this.AcceptButton = this.btnDangky;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(409, 167);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "fDangky";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký ";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDangky;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbMatkhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbTendangnhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}