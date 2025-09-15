namespace QuanLyThuVien.UI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.mainContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.btnDanhMuc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnTrangChu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnSach = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnThanhVien = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnMuonTra = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnPhat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnDatTruoc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnTKBC = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnHeThong = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnNV = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnSetup = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnLog = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.lblTieuDe = new DevExpress.XtraBars.BarStaticItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(303, 31);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(4);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(1395, 868);
            this.mainContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.Item.Default.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.accordionControl1.Appearance.Item.Default.Options.UseFont = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnDanhMuc,
            this.btnHeThong});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(4);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControl1.Size = new System.Drawing.Size(303, 868);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnTrangChu,
            this.mnSach,
            this.mnThanhVien,
            this.mnMuonTra,
            this.mnPhat,
            this.mnDatTruoc,
            this.mnTKBC});
            this.btnDanhMuc.Expanded = true;
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Text = "DANH MỤC";
            // 
            // mnTrangChu
            // 
            this.mnTrangChu.Name = "mnTrangChu";
            this.mnTrangChu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnTrangChu.Text = "Trang chủ";
            this.mnTrangChu.Click += new System.EventHandler(this.mnTrangChu_Click);
            // 
            // mnSach
            // 
            this.mnSach.Name = "mnSach";
            this.mnSach.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnSach.Text = "Quản lý Sách";
            this.mnSach.Click += new System.EventHandler(this.mnSach_Click);
            // 
            // mnThanhVien
            // 
            this.mnThanhVien.Name = "mnThanhVien";
            this.mnThanhVien.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnThanhVien.Text = "Quản lý Thành viên";
            this.mnThanhVien.Click += new System.EventHandler(this.mnThanhVien_Click);
            // 
            // mnMuonTra
            // 
            this.mnMuonTra.Name = "mnMuonTra";
            this.mnMuonTra.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnMuonTra.Text = "Quản lý Mượn/Trả";
            this.mnMuonTra.Click += new System.EventHandler(this.mnMuonTra_Click);
            // 
            // mnPhat
            // 
            this.mnPhat.Name = "mnPhat";
            this.mnPhat.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnPhat.Text = "Quản lý Phạt - Lịch sử thanh toán";
            this.mnPhat.Click += new System.EventHandler(this.mnPhat_Click);
            // 
            // mnDatTruoc
            // 
            this.mnDatTruoc.Name = "mnDatTruoc";
            this.mnDatTruoc.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnDatTruoc.Text = "Quản lý danh sách đặt trước";
            // 
            // mnTKBC
            // 
            this.mnTKBC.Name = "mnTKBC";
            this.mnTKBC.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnTKBC.Text = "Thống kê - Báo cáo";
            this.mnTKBC.Click += new System.EventHandler(this.mnTKBC_Click);
            // 
            // btnHeThong
            // 
            this.btnHeThong.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnNV,
            this.mnSetup,
            this.mnLog});
            this.btnHeThong.Expanded = true;
            this.btnHeThong.Name = "btnHeThong";
            this.btnHeThong.Text = "HỆ THỐNG";
            // 
            // mnNV
            // 
            this.mnNV.Name = "mnNV";
            this.mnNV.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnNV.Text = "Quản lý Nhân viên";
            // 
            // mnSetup
            // 
            this.mnSetup.Name = "mnSetup";
            this.mnSetup.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnSetup.Text = "Cấu hình hệ thống";
            // 
            // mnLog
            // 
            this.mnLog.Name = "mnLog";
            this.mnLog.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnLog.Text = "Log System";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblTieuDe});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(4);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1698, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lblTieuDe);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Caption = "Trương Công Bình";
            this.lblTieuDe.Id = 0;
            this.lblTieuDe.ItemAppearance.Normal.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ItemAppearance.Normal.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTieuDe.ItemAppearance.Normal.Options.UseFont = true;
            this.lblTieuDe.ItemAppearance.Normal.Options.UseForeColor = true;
            this.lblTieuDe.MaxWidth = 50;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblTieuDe});
            this.fluentFormDefaultManager1.MaxItemId = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1698, 899);
            this.ControlContainer = this.mainContainer;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mainContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnDanhMuc;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnTrangChu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnHeThong;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnSach;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnThanhVien;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnMuonTra;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnTKBC;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnSetup;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnNV;
        private DevExpress.XtraBars.BarStaticItem lblTieuDe;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnDatTruoc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnLog;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnPhat;
    }
}