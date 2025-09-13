namespace QuanLyThuVien.UI.UC.Pages
{
    partial class ucPageDanhSach
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
            this.gcDanhSachMuon = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSachMuon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaPhieuMuon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenThanhVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaThanhVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayMuon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayTraDuKien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaHan = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachMuon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDanhSachMuon
            // 
            this.gcDanhSachMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSachMuon.Location = new System.Drawing.Point(0, 0);
            this.gcDanhSachMuon.MainView = this.gvDanhSachMuon;
            this.gcDanhSachMuon.Name = "gcDanhSachMuon";
            this.gcDanhSachMuon.Size = new System.Drawing.Size(1200, 680);
            this.gcDanhSachMuon.TabIndex = 5;
            this.gcDanhSachMuon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSachMuon});
            // 
            // gvDanhSachMuon
            // 
            this.gvDanhSachMuon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaPhieuMuon,
            this.TenThanhVien,
            this.MaThanhVien,
            this.NgayMuon,
            this.NgayTraDuKien,
            this.TrangThai,
            this.GhiChu,
            this.Tra,
            this.GiaHan});
            this.gvDanhSachMuon.GridControl = this.gcDanhSachMuon;
            this.gvDanhSachMuon.Name = "gvDanhSachMuon";
            this.gvDanhSachMuon.OptionsBehavior.Editable = false;
            this.gvDanhSachMuon.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSachMuon.RowHeight = 25;
            this.gvDanhSachMuon.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvDanhSachMuon_CustomUnboundColumnData);
            // 
            // MaPhieuMuon
            // 
            this.MaPhieuMuon.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.MaPhieuMuon.AppearanceHeader.Options.UseFont = true;
            this.MaPhieuMuon.Caption = "MÃ PHIẾU";
            this.MaPhieuMuon.FieldName = "MaPhieuMuon";
            this.MaPhieuMuon.Name = "MaPhieuMuon";
            this.MaPhieuMuon.Visible = true;
            this.MaPhieuMuon.VisibleIndex = 0;
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
            this.TenThanhVien.Width = 200;
            // 
            // MaThanhVien
            // 
            this.MaThanhVien.Caption = "gridColumn1";
            this.MaThanhVien.FieldName = "MaThanhVien";
            this.MaThanhVien.Name = "MaThanhVien";
            // 
            // NgayMuon
            // 
            this.NgayMuon.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.NgayMuon.AppearanceHeader.Options.UseFont = true;
            this.NgayMuon.Caption = "NGÀY MƯỢN";
            this.NgayMuon.FieldName = "NgayMuon";
            this.NgayMuon.Name = "NgayMuon";
            this.NgayMuon.Visible = true;
            this.NgayMuon.VisibleIndex = 2;
            this.NgayMuon.Width = 100;
            // 
            // NgayTraDuKien
            // 
            this.NgayTraDuKien.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.NgayTraDuKien.AppearanceHeader.Options.UseFont = true;
            this.NgayTraDuKien.Caption = "NGÀY TRẢ DỰ KIẾN";
            this.NgayTraDuKien.FieldName = "NgayTraDuKien";
            this.NgayTraDuKien.Name = "NgayTraDuKien";
            this.NgayTraDuKien.Visible = true;
            this.NgayTraDuKien.VisibleIndex = 3;
            this.NgayTraDuKien.Width = 100;
            // 
            // TrangThai
            // 
            this.TrangThai.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.TrangThai.AppearanceHeader.Options.UseFont = true;
            this.TrangThai.Caption = "TRẠNG THÁI";
            this.TrangThai.FieldName = "TrangThai";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Visible = true;
            this.TrangThai.VisibleIndex = 4;
            this.TrangThai.Width = 100;
            // 
            // GhiChu
            // 
            this.GhiChu.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.GhiChu.AppearanceHeader.Options.UseFont = true;
            this.GhiChu.Caption = "GHI CHÚ";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 5;
            this.GhiChu.Width = 150;
            // 
            // Tra
            // 
            this.Tra.Name = "Tra";
            this.Tra.Visible = true;
            this.Tra.VisibleIndex = 6;
            this.Tra.Width = 100;
            // 
            // GiaHan
            // 
            this.GiaHan.Name = "GiaHan";
            this.GiaHan.Visible = true;
            this.GiaHan.VisibleIndex = 7;
            this.GiaHan.Width = 100;
            // 
            // ucPageDanhSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcDanhSachMuon);
            this.Name = "ucPageDanhSach";
            this.Size = new System.Drawing.Size(1200, 680);
            this.Load += new System.EventHandler(this.ucPageDanhSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachMuon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachMuon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDanhSachMuon;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSachMuon;
        private DevExpress.XtraGrid.Columns.GridColumn MaPhieuMuon;
        private DevExpress.XtraGrid.Columns.GridColumn TenThanhVien;
        private DevExpress.XtraGrid.Columns.GridColumn MaThanhVien;
        private DevExpress.XtraGrid.Columns.GridColumn NgayMuon;
        private DevExpress.XtraGrid.Columns.GridColumn NgayTraDuKien;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn Tra;
        private DevExpress.XtraGrid.Columns.GridColumn GiaHan;
    }
}
