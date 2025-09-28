namespace QuanLyThuVien.UI.UC
{
    partial class ucPhat
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabPhatLichSu = new DevExpress.XtraTab.XtraTabControl();
            this.pagePhat = new DevExpress.XtraTab.XtraTabPage();
            this.gcPhat = new DevExpress.XtraGrid.GridControl();
            this.gvPhat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaPhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaMuonSach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenSach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaThanhVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenThanhVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LyDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayPhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThanhToanButtonCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnThanhToan = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pageLichSu = new DevExpress.XtraTab.XtraTabPage();
            this.gcHistory = new DevExpress.XtraGrid.GridControl();
            this.gvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaPPhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaTVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenTVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTienn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayThanhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhuongThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPhatLichSu)).BeginInit();
            this.tabPhatLichSu.SuspendLayout();
            this.pagePhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThanhToan)).BeginInit();
            this.pageLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPhatLichSu
            // 
            this.tabPhatLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPhatLichSu.Location = new System.Drawing.Point(0, 0);
            this.tabPhatLichSu.Name = "tabPhatLichSu";
            this.tabPhatLichSu.SelectedTabPage = this.pagePhat;
            this.tabPhatLichSu.Size = new System.Drawing.Size(1200, 720);
            this.tabPhatLichSu.TabIndex = 64;
            this.tabPhatLichSu.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pagePhat,
            this.pageLichSu});
            // 
            // pagePhat
            // 
            this.pagePhat.Appearance.Header.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.pagePhat.Appearance.Header.Options.UseFont = true;
            this.pagePhat.Controls.Add(this.gcPhat);
            this.pagePhat.Name = "pagePhat";
            this.pagePhat.Size = new System.Drawing.Size(1198, 692);
            this.pagePhat.Text = "QUẢN LÝ PHẠT";
            // 
            // gcPhat
            // 
            this.gcPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPhat.Location = new System.Drawing.Point(0, 0);
            this.gcPhat.MainView = this.gvPhat;
            this.gcPhat.Name = "gcPhat";
            this.gcPhat.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnThanhToan});
            this.gcPhat.Size = new System.Drawing.Size(1198, 692);
            this.gcPhat.TabIndex = 0;
            this.gcPhat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPhat});
            // 
            // gvPhat
            // 
            this.gvPhat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaPhat,
            this.MaMuonSach,
            this.Barcode,
            this.TenSach,
            this.MaThanhVien,
            this.TenThanhVien,
            this.SoTien,
            this.LyDo,
            this.NgayPhat,
            this.TrangThai,
            this.ThanhToanButtonCol});
            this.gvPhat.GridControl = this.gcPhat;
            this.gvPhat.Name = "gvPhat";
            this.gvPhat.OptionsFind.HighlightFindResults = false;
            this.gvPhat.RowHeight = 30;
            this.gvPhat.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvPhat_RowCellStyle);
            this.gvPhat.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvPhat_CustomUnboundColumnData);
            // 
            // MaPhat
            // 
            this.MaPhat.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.MaPhat.AppearanceHeader.Options.UseFont = true;
            this.MaPhat.Caption = "MÃ PHẠT";
            this.MaPhat.FieldName = "MaPhat";
            this.MaPhat.Name = "MaPhat";
            this.MaPhat.OptionsColumn.AllowEdit = false;
            this.MaPhat.Visible = true;
            this.MaPhat.VisibleIndex = 0;
            // 
            // MaMuonSach
            // 
            this.MaMuonSach.FieldName = "MaMuonSach";
            this.MaMuonSach.Name = "MaMuonSach";
            // 
            // Barcode
            // 
            this.Barcode.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.Barcode.AppearanceHeader.Options.UseFont = true;
            this.Barcode.Caption = "BARCODE";
            this.Barcode.FieldName = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.OptionsColumn.AllowEdit = false;
            this.Barcode.UnboundDataType = typeof(string);
            this.Barcode.Visible = true;
            this.Barcode.VisibleIndex = 1;
            // 
            // TenSach
            // 
            this.TenSach.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.TenSach.AppearanceHeader.Options.UseFont = true;
            this.TenSach.Caption = "SÁCH";
            this.TenSach.FieldName = "TenSach";
            this.TenSach.Name = "TenSach";
            this.TenSach.OptionsColumn.AllowEdit = false;
            this.TenSach.UnboundDataType = typeof(string);
            this.TenSach.Visible = true;
            this.TenSach.VisibleIndex = 2;
            // 
            // MaThanhVien
            // 
            this.MaThanhVien.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.MaThanhVien.AppearanceHeader.Options.UseFont = true;
            this.MaThanhVien.Caption = "MÃ THÀNH VIÊN";
            this.MaThanhVien.FieldName = "MaThanhVien";
            this.MaThanhVien.Name = "MaThanhVien";
            this.MaThanhVien.OptionsColumn.AllowEdit = false;
            this.MaThanhVien.UnboundDataType = typeof(int);
            this.MaThanhVien.Visible = true;
            this.MaThanhVien.VisibleIndex = 3;
            // 
            // TenThanhVien
            // 
            this.TenThanhVien.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.TenThanhVien.AppearanceHeader.Options.UseFont = true;
            this.TenThanhVien.Caption = "TÊN THÀNH VIÊN";
            this.TenThanhVien.FieldName = "TenThanhVien";
            this.TenThanhVien.Name = "TenThanhVien";
            this.TenThanhVien.OptionsColumn.AllowEdit = false;
            this.TenThanhVien.UnboundDataType = typeof(string);
            this.TenThanhVien.Visible = true;
            this.TenThanhVien.VisibleIndex = 4;
            // 
            // SoTien
            // 
            this.SoTien.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.SoTien.AppearanceHeader.Options.UseFont = true;
            this.SoTien.Caption = "SỐ TIỀN";
            this.SoTien.FieldName = "SoTien";
            this.SoTien.Name = "SoTien";
            this.SoTien.OptionsColumn.AllowEdit = false;
            this.SoTien.Visible = true;
            this.SoTien.VisibleIndex = 5;
            // 
            // LyDo
            // 
            this.LyDo.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.LyDo.AppearanceHeader.Options.UseFont = true;
            this.LyDo.Caption = "LÝ DO";
            this.LyDo.FieldName = "LyDo";
            this.LyDo.Name = "LyDo";
            this.LyDo.OptionsColumn.AllowEdit = false;
            this.LyDo.Visible = true;
            this.LyDo.VisibleIndex = 6;
            // 
            // NgayPhat
            // 
            this.NgayPhat.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.NgayPhat.AppearanceHeader.Options.UseFont = true;
            this.NgayPhat.Caption = "NGÀY PHẠT";
            this.NgayPhat.FieldName = "NgayPhat";
            this.NgayPhat.Name = "NgayPhat";
            this.NgayPhat.Visible = true;
            this.NgayPhat.VisibleIndex = 7;
            // 
            // TrangThai
            // 
            this.TrangThai.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.TrangThai.AppearanceHeader.Options.UseFont = true;
            this.TrangThai.Caption = "TRẠNG THÁI";
            this.TrangThai.FieldName = "TrangThai";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.OptionsColumn.AllowEdit = false;
            this.TrangThai.Visible = true;
            this.TrangThai.VisibleIndex = 8;
            // 
            // ThanhToanButtonCol
            // 
            this.ThanhToanButtonCol.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ThanhToanButtonCol.AppearanceCell.Options.UseBackColor = true;
            this.ThanhToanButtonCol.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.ThanhToanButtonCol.AppearanceHeader.Options.UseFont = true;
            this.ThanhToanButtonCol.Caption = "THANH TOÁN";
            this.ThanhToanButtonCol.ColumnEdit = this.btnThanhToan;
            this.ThanhToanButtonCol.Name = "ThanhToanButtonCol";
            this.ThanhToanButtonCol.Visible = true;
            this.ThanhToanButtonCol.VisibleIndex = 9;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.AutoHeight = false;
            this.btnThanhToan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Thanh toán", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // pageLichSu
            // 
            this.pageLichSu.Appearance.Header.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.pageLichSu.Appearance.Header.Options.UseFont = true;
            this.pageLichSu.Controls.Add(this.gcHistory);
            this.pageLichSu.Name = "pageLichSu";
            this.pageLichSu.Size = new System.Drawing.Size(1198, 692);
            this.pageLichSu.Text = "LỊCH SỬ THANH TOÁN";
            // 
            // gcHistory
            // 
            this.gcHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHistory.Location = new System.Drawing.Point(0, 0);
            this.gcHistory.MainView = this.gvHistory;
            this.gcHistory.Name = "gcHistory";
            this.gcHistory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gcHistory.Size = new System.Drawing.Size(1198, 692);
            this.gcHistory.TabIndex = 1;
            this.gcHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHistory});
            // 
            // gvHistory
            // 
            this.gvHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaPayment,
            this.MaPPhat,
            this.MaTVien,
            this.TenTVien,
            this.SoTienn,
            this.NgayThanhToan,
            this.PhuongThuc,
            this.Note});
            this.gvHistory.GridControl = this.gcHistory;
            this.gvHistory.Name = "gvHistory";
            this.gvHistory.OptionsBehavior.Editable = false;
            this.gvHistory.RowHeight = 30;
            this.gvHistory.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvHistory_CustomUnboundColumnData);
            // 
            // MaPayment
            // 
            this.MaPayment.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.MaPayment.AppearanceHeader.Options.UseFont = true;
            this.MaPayment.Caption = "MÃ LỊCH SỬ THANH TOÁN";
            this.MaPayment.FieldName = "MaPayment";
            this.MaPayment.Name = "MaPayment";
            this.MaPayment.Visible = true;
            this.MaPayment.VisibleIndex = 0;
            this.MaPayment.Width = 175;
            // 
            // MaPPhat
            // 
            this.MaPPhat.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.MaPPhat.AppearanceHeader.Options.UseFont = true;
            this.MaPPhat.Caption = "MÃ PHẠT";
            this.MaPPhat.FieldName = "MaPhat";
            this.MaPPhat.Name = "MaPPhat";
            this.MaPPhat.Visible = true;
            this.MaPPhat.VisibleIndex = 1;
            this.MaPPhat.Width = 104;
            // 
            // MaTVien
            // 
            this.MaTVien.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.MaTVien.AppearanceHeader.Options.UseFont = true;
            this.MaTVien.Caption = "MÃ THÀNH VIÊN";
            this.MaTVien.FieldName = "MaThanhVien";
            this.MaTVien.Name = "MaTVien";
            this.MaTVien.Visible = true;
            this.MaTVien.VisibleIndex = 2;
            this.MaTVien.Width = 133;
            // 
            // TenTVien
            // 
            this.TenTVien.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.TenTVien.AppearanceHeader.Options.UseFont = true;
            this.TenTVien.Caption = "TÊN THÀNH VIÊN";
            this.TenTVien.FieldName = "TenThanhVien";
            this.TenTVien.Name = "TenTVien";
            this.TenTVien.UnboundDataType = typeof(string);
            this.TenTVien.Visible = true;
            this.TenTVien.VisibleIndex = 3;
            this.TenTVien.Width = 175;
            // 
            // SoTienn
            // 
            this.SoTienn.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.SoTienn.AppearanceHeader.Options.UseFont = true;
            this.SoTienn.Caption = "SỐ TIỀN";
            this.SoTienn.FieldName = "Amount";
            this.SoTienn.Name = "SoTienn";
            this.SoTienn.Visible = true;
            this.SoTienn.VisibleIndex = 4;
            this.SoTienn.Width = 140;
            // 
            // NgayThanhToan
            // 
            this.NgayThanhToan.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.NgayThanhToan.AppearanceHeader.Options.UseFont = true;
            this.NgayThanhToan.Caption = "NGÀY THANH TOÁN";
            this.NgayThanhToan.FieldName = "PaymentDate";
            this.NgayThanhToan.Name = "NgayThanhToan";
            this.NgayThanhToan.Visible = true;
            this.NgayThanhToan.VisibleIndex = 5;
            this.NgayThanhToan.Width = 140;
            // 
            // PhuongThuc
            // 
            this.PhuongThuc.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.PhuongThuc.AppearanceHeader.Options.UseFont = true;
            this.PhuongThuc.Caption = "PHƯƠNG THỨC";
            this.PhuongThuc.FieldName = "Method";
            this.PhuongThuc.Name = "PhuongThuc";
            this.PhuongThuc.Visible = true;
            this.PhuongThuc.VisibleIndex = 6;
            this.PhuongThuc.Width = 140;
            // 
            // Note
            // 
            this.Note.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.Note.AppearanceHeader.Options.UseFont = true;
            this.Note.Caption = "GHI CHÚ";
            this.Note.FieldName = "Note";
            this.Note.Name = "Note";
            this.Note.Visible = true;
            this.Note.VisibleIndex = 7;
            this.Note.Width = 158;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Thanh toán", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // ucPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPhatLichSu);
            this.Name = "ucPhat";
            this.Size = new System.Drawing.Size(1200, 720);
            this.Load += new System.EventHandler(this.ucPhat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabPhatLichSu)).EndInit();
            this.tabPhatLichSu.ResumeLayout(false);
            this.pagePhat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThanhToan)).EndInit();
            this.pageLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabPhatLichSu;
        private DevExpress.XtraTab.XtraTabPage pagePhat;
        private DevExpress.XtraTab.XtraTabPage pageLichSu;
        private DevExpress.XtraGrid.GridControl gcPhat;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPhat;
        private DevExpress.XtraGrid.Columns.GridColumn MaPhat;
        private DevExpress.XtraGrid.Columns.GridColumn MaMuonSach;
        private DevExpress.XtraGrid.Columns.GridColumn Barcode;
        private DevExpress.XtraGrid.Columns.GridColumn TenSach;
        private DevExpress.XtraGrid.Columns.GridColumn MaThanhVien;
        private DevExpress.XtraGrid.Columns.GridColumn TenThanhVien;
        private DevExpress.XtraGrid.Columns.GridColumn SoTien;
        private DevExpress.XtraGrid.Columns.GridColumn LyDo;
        private DevExpress.XtraGrid.Columns.GridColumn NgayPhat;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn ThanhToanButtonCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnThanhToan;
        private DevExpress.XtraGrid.GridControl gcHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHistory;
        private DevExpress.XtraGrid.Columns.GridColumn MaPayment;
        private DevExpress.XtraGrid.Columns.GridColumn MaPPhat;
        private DevExpress.XtraGrid.Columns.GridColumn MaTVien;
        private DevExpress.XtraGrid.Columns.GridColumn TenTVien;
        private DevExpress.XtraGrid.Columns.GridColumn SoTienn;
        private DevExpress.XtraGrid.Columns.GridColumn NgayThanhToan;
        private DevExpress.XtraGrid.Columns.GridColumn PhuongThuc;
        private DevExpress.XtraGrid.Columns.GridColumn Note;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}
