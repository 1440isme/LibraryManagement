namespace QuanLyThuVien.UI.UI
{
    partial class ucSach
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
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gcSach = new DevExpress.XtraGrid.GridControl();
            this.gvSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaSach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenSach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenTacGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaTacGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNhaXuatBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNhaXuatBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenTheLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaTheLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NamXuatBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Gia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.txtNamXB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNXB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTacGia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.MinHeight = 40;
            this.bar1.Text = "Tools";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = global::QuanLyThuVien.UI.Properties.Resources.addparagraphtotableofcontents3;
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 1;
            this.btnSua.ImageOptions.SvgImage = global::QuanLyThuVien.UI.Properties.Resources.trackingchanges_allmarkup2;
            this.btnSua.Name = "btnSua";
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xoá";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.SvgImage = global::QuanLyThuVien.UI.Properties.Resources.snapdeletelist2;
            this.btnXoa.Name = "btnXoa";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1280, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 720);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1280, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 680);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1280, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 680);
            // 
            // gcSach
            // 
            this.gcSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSach.Location = new System.Drawing.Point(0, 0);
            this.gcSach.MainView = this.gvSach;
            this.gcSach.MenuManager = this.barManager1;
            this.gcSach.Name = "gcSach";
            this.gcSach.Size = new System.Drawing.Size(1280, 496);
            this.gcSach.TabIndex = 4;
            this.gcSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSach});
            // 
            // gvSach
            // 
            this.gvSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaSach,
            this.TenSach,
            this.ISBN,
            this.TenTacGia,
            this.MaTacGia,
            this.TenNhaXuatBan,
            this.MaNhaXuatBan,
            this.TenTheLoai,
            this.MaTheLoai,
            this.NamXuatBan,
            this.Gia,
            this.SoLuong,
            this.TrangThai});
            this.gvSach.GridControl = this.gcSach;
            this.gvSach.Name = "gvSach";
            this.gvSach.OptionsBehavior.Editable = false;
            // 
            // MaSach
            // 
            this.MaSach.Caption = "Mã Sách";
            this.MaSach.FieldName = "MaSach";
            this.MaSach.Name = "MaSach";
            // 
            // TenSach
            // 
            this.TenSach.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TenSach.AppearanceHeader.Options.UseFont = true;
            this.TenSach.Caption = "TÊN SÁCH";
            this.TenSach.FieldName = "TenSach";
            this.TenSach.Name = "TenSach";
            this.TenSach.Visible = true;
            this.TenSach.VisibleIndex = 0;
            this.TenSach.Width = 196;
            // 
            // ISBN
            // 
            this.ISBN.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.ISBN.AppearanceHeader.Options.UseFont = true;
            this.ISBN.Caption = "ISBN";
            this.ISBN.FieldName = "ISBN";
            this.ISBN.Name = "ISBN";
            this.ISBN.Visible = true;
            this.ISBN.VisibleIndex = 1;
            this.ISBN.Width = 100;
            // 
            // TenTacGia
            // 
            this.TenTacGia.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TenTacGia.AppearanceHeader.Options.UseFont = true;
            this.TenTacGia.Caption = "TÁC GIẢ";
            this.TenTacGia.FieldName = "TenTacGia";
            this.TenTacGia.Name = "TenTacGia";
            this.TenTacGia.UnboundDataType = typeof(string);
            this.TenTacGia.Visible = true;
            this.TenTacGia.VisibleIndex = 2;
            this.TenTacGia.Width = 201;
            // 
            // MaTacGia
            // 
            this.MaTacGia.Caption = "Mã Tác Giả";
            this.MaTacGia.FieldName = "MaTacGia";
            this.MaTacGia.Name = "MaTacGia";
            // 
            // TenNhaXuatBan
            // 
            this.TenNhaXuatBan.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TenNhaXuatBan.AppearanceHeader.Options.UseFont = true;
            this.TenNhaXuatBan.Caption = "NXB";
            this.TenNhaXuatBan.FieldName = "TenNhaXuatBan";
            this.TenNhaXuatBan.Name = "TenNhaXuatBan";
            this.TenNhaXuatBan.UnboundDataType = typeof(string);
            this.TenNhaXuatBan.Visible = true;
            this.TenNhaXuatBan.VisibleIndex = 5;
            this.TenNhaXuatBan.Width = 123;
            // 
            // MaNhaXuatBan
            // 
            this.MaNhaXuatBan.Caption = "Mã NXB";
            this.MaNhaXuatBan.FieldName = "MaNhaXuatBan";
            this.MaNhaXuatBan.Name = "MaNhaXuatBan";
            // 
            // TenTheLoai
            // 
            this.TenTheLoai.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TenTheLoai.AppearanceHeader.Options.UseFont = true;
            this.TenTheLoai.Caption = "THỂ LOẠI";
            this.TenTheLoai.FieldName = "TenTheLoai";
            this.TenTheLoai.Name = "TenTheLoai";
            this.TenTheLoai.UnboundDataType = typeof(string);
            this.TenTheLoai.Visible = true;
            this.TenTheLoai.VisibleIndex = 7;
            this.TenTheLoai.Width = 144;
            // 
            // MaTheLoai
            // 
            this.MaTheLoai.Caption = "Mã Thể loại";
            this.MaTheLoai.FieldName = "MaTheLoai";
            this.MaTheLoai.Name = "MaTheLoai";
            // 
            // NamXuatBan
            // 
            this.NamXuatBan.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.NamXuatBan.AppearanceHeader.Options.UseFont = true;
            this.NamXuatBan.Caption = "NĂM XUẤT BẢN";
            this.NamXuatBan.FieldName = "NamXuatBan";
            this.NamXuatBan.Name = "NamXuatBan";
            this.NamXuatBan.Visible = true;
            this.NamXuatBan.VisibleIndex = 3;
            this.NamXuatBan.Width = 127;
            // 
            // Gia
            // 
            this.Gia.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Gia.AppearanceHeader.Options.UseFont = true;
            this.Gia.Caption = "GIÁ";
            this.Gia.FieldName = "Gia";
            this.Gia.Name = "Gia";
            this.Gia.Visible = true;
            this.Gia.VisibleIndex = 4;
            this.Gia.Width = 122;
            // 
            // SoLuong
            // 
            this.SoLuong.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SoLuong.AppearanceHeader.Options.UseFont = true;
            this.SoLuong.Caption = "SỐ LƯỢNG";
            this.SoLuong.FieldName = "SoLuong";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Visible = true;
            this.SoLuong.VisibleIndex = 6;
            this.SoLuong.Width = 95;
            // 
            // TrangThai
            // 
            this.TrangThai.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TrangThai.AppearanceHeader.Options.UseFont = true;
            this.TrangThai.Caption = "TRẠNG THÁI";
            this.TrangThai.FieldName = "TrangThai";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Visible = true;
            this.TrangThai.VisibleIndex = 8;
            this.TrangThai.Width = 147;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkTrangThai);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.numSoLuong);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.numGia);
            this.panelControl1.Controls.Add(this.txtNamXB);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.cboTheLoai);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.cboNXB);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.cboTacGia);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.txtISBN);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txtTenSach);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1280, 174);
            this.panelControl1.TabIndex = 9;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrangThai.Location = new System.Drawing.Point(1014, 126);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(92, 21);
            this.chkTrangThai.TabIndex = 60;
            this.chkTrangThai.Text = "Trạng thái";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(949, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 59;
            this.label8.Text = "Số lượng";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoLuong.Location = new System.Drawing.Point(1036, 75);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(174, 23);
            this.numSoLuong.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(949, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 57;
            this.label7.Text = "Giá";
            // 
            // numGia
            // 
            this.numGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGia.Location = new System.Drawing.Point(1036, 30);
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(174, 23);
            this.numGia.TabIndex = 56;
            // 
            // txtNamXB
            // 
            this.txtNamXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamXB.Location = new System.Drawing.Point(606, 125);
            this.txtNamXB.Name = "txtNamXB";
            this.txtNamXB.Size = new System.Drawing.Size(231, 23);
            this.txtNamXB.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(493, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 54;
            this.label6.Text = "Năm xuất bản";
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(606, 83);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(231, 24);
            this.cboTheLoai.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(493, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 52;
            this.label5.Text = "Thể loại";
            // 
            // cboNXB
            // 
            this.cboNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNXB.FormattingEnabled = true;
            this.cboNXB.Location = new System.Drawing.Point(606, 38);
            this.cboNXB.Name = "cboNXB";
            this.cboNXB.Size = new System.Drawing.Size(231, 24);
            this.cboNXB.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(493, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 50;
            this.label4.Text = "NXB";
            // 
            // cboTacGia
            // 
            this.cboTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTacGia.FormattingEnabled = true;
            this.cboTacGia.Location = new System.Drawing.Point(152, 124);
            this.cboTacGia.Name = "cboTacGia";
            this.cboTacGia.Size = new System.Drawing.Size(231, 24);
            this.cboTacGia.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "Tác giả";
            // 
            // txtISBN
            // 
            this.txtISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtISBN.Location = new System.Drawing.Point(152, 76);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(231, 23);
            this.txtISBN.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "ISBN";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSach.Location = new System.Drawing.Point(152, 30);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(231, 23);
            this.txtTenSach.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "Tên sách";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 40);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gcSach);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1280, 680);
            this.splitContainerControl1.SplitterPosition = 496;
            this.splitContainerControl1.TabIndex = 10;
            // 
            // ucSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucSach";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.ucSach_Load);
            this.Resize += new System.EventHandler(this.ucSach_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraGrid.GridControl gcSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSach;
        private DevExpress.XtraGrid.Columns.GridColumn MaSach;
        private DevExpress.XtraGrid.Columns.GridColumn TenSach;
        private DevExpress.XtraGrid.Columns.GridColumn ISBN;
        private DevExpress.XtraGrid.Columns.GridColumn MaTacGia;
        private DevExpress.XtraGrid.Columns.GridColumn MaNhaXuatBan;
        private DevExpress.XtraGrid.Columns.GridColumn MaTheLoai;
        private DevExpress.XtraGrid.Columns.GridColumn NamXuatBan;
        private DevExpress.XtraGrid.Columns.GridColumn Gia;
        private DevExpress.XtraGrid.Columns.GridColumn SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.TextBox txtNamXB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNXB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTacGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Columns.GridColumn TenTacGia;
        private DevExpress.XtraGrid.Columns.GridColumn TenNhaXuatBan;
        private DevExpress.XtraGrid.Columns.GridColumn TenTheLoai;
    }
}
