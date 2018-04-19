namespace QuanLyKho
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnHH = new System.Windows.Forms.Button();
            this.btnNCC = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXuatHang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ KHO";
            // 
            // btnHH
            // 
            this.btnHH.Location = new System.Drawing.Point(225, 107);
            this.btnHH.Name = "btnHH";
            this.btnHH.Size = new System.Drawing.Size(228, 41);
            this.btnHH.TabIndex = 1;
            this.btnHH.Text = "Các Loại Hàng Hoá";
            this.btnHH.UseVisualStyleBackColor = true;
            this.btnHH.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNCC
            // 
            this.btnNCC.Location = new System.Drawing.Point(225, 174);
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(228, 41);
            this.btnNCC.TabIndex = 2;
            this.btnNCC.Text = "Nhà Cung Cấp";
            this.btnNCC.UseVisualStyleBackColor = true;
            this.btnNCC.Click += new System.EventHandler(this.btnNCC_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Location = new System.Drawing.Point(225, 239);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(228, 41);
            this.btnNhapHang.TabIndex = 3;
            this.btnNhapHang.Text = "Danh Sách Nhập Hàng";
            this.btnNhapHang.UseVisualStyleBackColor = true;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(225, 309);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(228, 41);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống Kê Hàng Hoá";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(225, 374);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(228, 41);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm Kiếm Hàng Hóa";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXuatHang
            // 
            this.btnXuatHang.Location = new System.Drawing.Point(225, 445);
            this.btnXuatHang.Name = "btnXuatHang";
            this.btnXuatHang.Size = new System.Drawing.Size(228, 41);
            this.btnXuatHang.TabIndex = 6;
            this.btnXuatHang.Text = "Danh Sách Xuất Hàng";
            this.btnXuatHang.UseVisualStyleBackColor = true;
            this.btnXuatHang.Click += new System.EventHandler(this.btnXuatHang_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 539);
            this.Controls.Add(this.btnXuatHang);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnNhapHang);
            this.Controls.Add(this.btnNCC);
            this.Controls.Add(this.btnHH);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHH;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXuatHang;
    }
}

