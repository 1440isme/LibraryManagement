namespace QuanLyThuVien.UI.UC
{
    partial class ucBaoCaoThongKe
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcThanhVien = new DevExpress.XtraGrid.GridControl();
            this.gvThanhVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaThanhVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenThanhVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoaiThanhVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayDangKy = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcThanhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThanhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gcThanhVien);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControl1.SplitterPosition = 125;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // gcThanhVien
            // 
            this.gcThanhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcThanhVien.Location = new System.Drawing.Point(0, 0);
            this.gcThanhVien.MainView = this.gvThanhVien;
            this.gcThanhVien.Name = "gcThanhVien";
            this.gcThanhVien.Size = new System.Drawing.Size(1200, 585);
            this.gcThanhVien.TabIndex = 5;
            this.gcThanhVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvThanhVien});
            // 
            // gvThanhVien
            // 
            this.gvThanhVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaThanhVien,
            this.TenThanhVien,
            this.Email,
            this.SoDienThoai,
            this.DiaChi,
            this.LoaiThanhVien,
            this.NgayDangKy});
            this.gvThanhVien.GridControl = this.gcThanhVien;
            this.gvThanhVien.Name = "gvThanhVien";
            this.gvThanhVien.OptionsBehavior.Editable = false;
            this.gvThanhVien.RowHeight = 25;
            // 
            // MaThanhVien
            // 
            this.MaThanhVien.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.MaThanhVien.AppearanceHeader.Options.UseFont = true;
            this.MaThanhVien.Caption = "MÃ";
            this.MaThanhVien.FieldName = "MaThanhVien";
            this.MaThanhVien.Name = "MaThanhVien";
            this.MaThanhVien.Visible = true;
            this.MaThanhVien.VisibleIndex = 0;
            this.MaThanhVien.Width = 103;
            // 
            // TenThanhVien
            // 
            this.TenThanhVien.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.TenThanhVien.AppearanceHeader.Options.UseFont = true;
            this.TenThanhVien.Caption = "TÊN THÀNH VIÊN";
            this.TenThanhVien.FieldName = "TenThanhVien";
            this.TenThanhVien.Name = "TenThanhVien";
            this.TenThanhVien.Visible = true;
            this.TenThanhVien.VisibleIndex = 1;
            this.TenThanhVien.Width = 177;
            // 
            // Email
            // 
            this.Email.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.Email.AppearanceHeader.Options.UseFont = true;
            this.Email.Caption = "EMAIL";
            this.Email.FieldName = "Email";
            this.Email.Name = "Email";
            this.Email.Visible = true;
            this.Email.VisibleIndex = 2;
            this.Email.Width = 177;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.SoDienThoai.AppearanceHeader.Options.UseFont = true;
            this.SoDienThoai.Caption = "SDT";
            this.SoDienThoai.FieldName = "SoDienThoai";
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.Visible = true;
            this.SoDienThoai.VisibleIndex = 3;
            this.SoDienThoai.Width = 177;
            // 
            // DiaChi
            // 
            this.DiaChi.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.DiaChi.AppearanceHeader.Options.UseFont = true;
            this.DiaChi.Caption = "ĐỊA CHỈ";
            this.DiaChi.FieldName = "DiaChi";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Visible = true;
            this.DiaChi.VisibleIndex = 4;
            this.DiaChi.Width = 177;
            // 
            // LoaiThanhVien
            // 
            this.LoaiThanhVien.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.LoaiThanhVien.AppearanceHeader.Options.UseFont = true;
            this.LoaiThanhVien.Caption = "LOẠI";
            this.LoaiThanhVien.FieldName = "LoaiThanhVien";
            this.LoaiThanhVien.Name = "LoaiThanhVien";
            this.LoaiThanhVien.Visible = true;
            this.LoaiThanhVien.VisibleIndex = 5;
            this.LoaiThanhVien.Width = 177;
            // 
            // NgayDangKy
            // 
            this.NgayDangKy.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.NgayDangKy.AppearanceHeader.Options.UseFont = true;
            this.NgayDangKy.Caption = "NGÀY ĐĂNG KÝ";
            this.NgayDangKy.FieldName = "NgayDangKy";
            this.NgayDangKy.Name = "NgayDangKy";
            this.NgayDangKy.Visible = true;
            this.NgayDangKy.VisibleIndex = 6;
            this.NgayDangKy.Width = 187;
            // 
            // ucBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ucBaoCaoThongKe";
            this.Size = new System.Drawing.Size(1200, 720);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcThanhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThanhVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcThanhVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gvThanhVien;
        private DevExpress.XtraGrid.Columns.GridColumn MaThanhVien;
        private DevExpress.XtraGrid.Columns.GridColumn TenThanhVien;
        private DevExpress.XtraGrid.Columns.GridColumn Email;
        private DevExpress.XtraGrid.Columns.GridColumn SoDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn LoaiThanhVien;
        private DevExpress.XtraGrid.Columns.GridColumn NgayDangKy;
    }
}
