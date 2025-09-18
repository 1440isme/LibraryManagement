namespace QuanLyThuVien.UI
{
    partial class frmGuiMail
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
            this.txtMaThanhVien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenThanhVien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongNgayQuaHan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongSoSach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDanhSachSach = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongPhat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuiMail = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // txtMaThanhVien
            // 
            this.txtMaThanhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaThanhVien.Location = new System.Drawing.Point(164, 38);
            this.txtMaThanhVien.Name = "txtMaThanhVien";
            this.txtMaThanhVien.ReadOnly = true;
            this.txtMaThanhVien.Size = new System.Drawing.Size(148, 23);
            this.txtMaThanhVien.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 57;
            this.label1.Text = "Mã thành viên";
            // 
            // txtTenThanhVien
            // 
            this.txtTenThanhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenThanhVien.Location = new System.Drawing.Point(456, 38);
            this.txtTenThanhVien.Name = "txtTenThanhVien";
            this.txtTenThanhVien.ReadOnly = true;
            this.txtTenThanhVien.Size = new System.Drawing.Size(148, 23);
            this.txtTenThanhVien.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(331, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 59;
            this.label2.Text = "Tên thành viên";
            // 
            // txtTongNgayQuaHan
            // 
            this.txtTongNgayQuaHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongNgayQuaHan.Location = new System.Drawing.Point(456, 97);
            this.txtTongNgayQuaHan.Name = "txtTongNgayQuaHan";
            this.txtTongNgayQuaHan.ReadOnly = true;
            this.txtTongNgayQuaHan.Size = new System.Drawing.Size(148, 23);
            this.txtTongNgayQuaHan.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(331, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 63;
            this.label3.Text = "Tổng ngày quá hạn";
            // 
            // txtTongSoSach
            // 
            this.txtTongSoSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSoSach.Location = new System.Drawing.Point(164, 97);
            this.txtTongSoSach.Name = "txtTongSoSach";
            this.txtTongSoSach.ReadOnly = true;
            this.txtTongSoSach.Size = new System.Drawing.Size(148, 23);
            this.txtTongSoSach.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 61;
            this.label4.Text = "Tổng số sách";
            // 
            // txtDanhSachSach
            // 
            this.txtDanhSachSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanhSachSach.Location = new System.Drawing.Point(164, 162);
            this.txtDanhSachSach.Multiline = true;
            this.txtDanhSachSach.Name = "txtDanhSachSach";
            this.txtDanhSachSach.ReadOnly = true;
            this.txtDanhSachSach.Size = new System.Drawing.Size(148, 67);
            this.txtDanhSachSach.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(47, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 67;
            this.label5.Text = "Danh sách sách";
            // 
            // txtTongPhat
            // 
            this.txtTongPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhat.Location = new System.Drawing.Point(456, 165);
            this.txtTongPhat.Name = "txtTongPhat";
            this.txtTongPhat.ReadOnly = true;
            this.txtTongPhat.Size = new System.Drawing.Size(148, 23);
            this.txtTongPhat.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(331, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 65;
            this.label6.Text = "Tổng phạt";
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.ImageOptions.SvgImage = global::QuanLyThuVien.UI.Properties.Resources.del;
            this.btnHuy.Location = new System.Drawing.Point(369, 258);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 70;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnGuiMail
            // 
            this.btnGuiMail.Appearance.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuiMail.Appearance.Options.UseFont = true;
            this.btnGuiMail.ImageOptions.SvgImage = global::QuanLyThuVien.UI.Properties.Resources.glyph_mail;
            this.btnGuiMail.Location = new System.Drawing.Point(220, 258);
            this.btnGuiMail.Name = "btnGuiMail";
            this.btnGuiMail.Size = new System.Drawing.Size(100, 40);
            this.btnGuiMail.TabIndex = 69;
            this.btnGuiMail.Text = "Gửi mail";
            this.btnGuiMail.Click += new System.EventHandler(this.btnGuiMail_Click);
            // 
            // frmGuiMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 352);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnGuiMail);
            this.Controls.Add(this.txtDanhSachSach);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTongPhat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTongNgayQuaHan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTongSoSach);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenThanhVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaThanhVien);
            this.Controls.Add(this.label1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGuiMail";
            this.Text = "frmGuiMail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaThanhVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenThanhVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongNgayQuaHan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongSoSach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDanhSachSach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongPhat;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnGuiMail;
    }
}