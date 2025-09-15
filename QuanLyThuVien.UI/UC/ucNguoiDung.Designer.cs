namespace QuanLyThuVien.UI.UC
{
    partial class ucNguoiDung
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
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnBoQua = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PasswordHash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RoleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CreatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkHoatDong = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.btnXoa,
            this.btnLuu,
            this.btnBoQua});
            this.barManager1.MaxItemId = 6;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(401, 75);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnBoQua, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 1;
            this.btnSua.ImageOptions.SvgImage = global::QuanLyThuVien.UI.Properties.Resources.trackingchanges_allmarkup2;
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xoá";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.SvgImage = global::QuanLyThuVien.UI.Properties.Resources.snapdeletelist2;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.SvgImage = global::QuanLyThuVien.UI.Properties.Resources.save;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Caption = "Bỏ qua";
            this.btnBoQua.Id = 4;
            this.btnBoQua.ImageOptions.SvgImage = global::QuanLyThuVien.UI.Properties.Resources.forward;
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBoQua_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1200, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 720);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1200, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(1200, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 680);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.gcUser);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1200, 680);
            this.splitContainerControl1.SplitterPosition = 504;
            this.splitContainerControl1.TabIndex = 13;
            // 
            // gcUser
            // 
            this.gcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUser.Location = new System.Drawing.Point(0, 0);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(1200, 504);
            this.gcUser.TabIndex = 4;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UserId,
            this.UserName,
            this.FullName,
            this.PasswordHash,
            this.Email,
            this.RoleId,
            this.IsActive,
            this.CreatedAt,
            this.RoleName});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsBehavior.Editable = false;
            this.gvUser.RowHeight = 25;
            this.gvUser.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvUser_RowCellStyle);
            this.gvUser.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvUser_CustomUnboundColumnData);
            this.gvUser.Click += new System.EventHandler(this.gvUser_Click);
            // 
            // UserId
            // 
            this.UserId.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.UserId.AppearanceHeader.Options.UseFont = true;
            this.UserId.Caption = "MÃ ";
            this.UserId.FieldName = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.Visible = true;
            this.UserId.VisibleIndex = 0;
            // 
            // UserName
            // 
            this.UserName.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.UserName.AppearanceHeader.Options.UseFont = true;
            this.UserName.Caption = "TÊN ĐĂNG NHẬP";
            this.UserName.FieldName = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 1;
            // 
            // FullName
            // 
            this.FullName.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.FullName.AppearanceHeader.Options.UseFont = true;
            this.FullName.Caption = "HỌ TÊN";
            this.FullName.FieldName = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 2;
            // 
            // PasswordHash
            // 
            this.PasswordHash.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.PasswordHash.AppearanceHeader.Options.UseFont = true;
            this.PasswordHash.Caption = "MẬT KHẨU";
            this.PasswordHash.FieldName = "PasswordHash";
            this.PasswordHash.Name = "PasswordHash";
            this.PasswordHash.Visible = true;
            this.PasswordHash.VisibleIndex = 3;
            // 
            // Email
            // 
            this.Email.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.Email.AppearanceHeader.Options.UseFont = true;
            this.Email.Caption = "EMAIL";
            this.Email.FieldName = "Email";
            this.Email.Name = "Email";
            this.Email.Visible = true;
            this.Email.VisibleIndex = 4;
            // 
            // RoleId
            // 
            this.RoleId.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.RoleId.AppearanceHeader.Options.UseFont = true;
            this.RoleId.Caption = "VAI TRÒ";
            this.RoleId.FieldName = "RoleId";
            this.RoleId.Name = "RoleId";
            // 
            // IsActive
            // 
            this.IsActive.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.IsActive.AppearanceHeader.Options.UseFont = true;
            this.IsActive.Caption = "HOẠT ĐỘNG";
            this.IsActive.FieldName = "IsActive";
            this.IsActive.Name = "IsActive";
            this.IsActive.Visible = true;
            this.IsActive.VisibleIndex = 5;
            // 
            // CreatedAt
            // 
            this.CreatedAt.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.CreatedAt.AppearanceHeader.Options.UseFont = true;
            this.CreatedAt.Caption = "NGÀY TẠO";
            this.CreatedAt.FieldName = "CreatedAt";
            this.CreatedAt.Name = "CreatedAt";
            this.CreatedAt.Visible = true;
            this.CreatedAt.VisibleIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkHoatDong);
            this.panelControl1.Controls.Add(this.txtUsername);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.txtPassword);
            this.panelControl1.Controls.Add(this.cboRole);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.txtEmail);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txtFullname);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1200, 166);
            this.panelControl1.TabIndex = 9;
            // 
            // chkHoatDong
            // 
            this.chkHoatDong.AutoSize = true;
            this.chkHoatDong.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkHoatDong.Location = new System.Drawing.Point(938, 85);
            this.chkHoatDong.Name = "chkHoatDong";
            this.chkHoatDong.Size = new System.Drawing.Size(86, 20);
            this.chkHoatDong.TabIndex = 72;
            this.chkHoatDong.Text = "Hoạt động";
            this.chkHoatDong.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(152, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(231, 23);
            this.txtUsername.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(49, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 70;
            this.label7.Text = "Tên đăng nhập";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(897, 30);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(231, 23);
            this.txtPassword.TabIndex = 68;
            // 
            // cboRole
            // 
            this.cboRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] {
            "SinhVien",
            "GiangVien"});
            this.cboRole.Location = new System.Drawing.Point(546, 83);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(231, 24);
            this.cboRole.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(445, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 52;
            this.label5.Text = "Vai trò";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(825, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "Mật khẩu";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(152, 84);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(231, 23);
            this.txtEmail.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 46;
            this.label2.Text = "Email";
            // 
            // txtFullname
            // 
            this.txtFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullname.Location = new System.Drawing.Point(546, 30);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(231, 23);
            this.txtFullname.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(445, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Họ tên";
            // 
            // RoleName
            // 
            this.RoleName.AppearanceHeader.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.RoleName.AppearanceHeader.Options.UseFont = true;
            this.RoleName.Caption = "VAI TRÒ";
            this.RoleName.FieldName = "RoleName";
            this.RoleName.Name = "RoleName";
            this.RoleName.UnboundDataType = typeof(string);
            this.RoleName.Visible = true;
            this.RoleName.VisibleIndex = 7;
            // 
            // ucNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucNguoiDung";
            this.Size = new System.Drawing.Size(1200, 720);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnBoQua;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn UserId;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn PasswordHash;
        private DevExpress.XtraGrid.Columns.GridColumn Email;
        private DevExpress.XtraGrid.Columns.GridColumn RoleId;
        private DevExpress.XtraGrid.Columns.GridColumn IsActive;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHoatDong;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.Columns.GridColumn CreatedAt;
        private DevExpress.XtraGrid.Columns.GridColumn RoleName;
    }
}
