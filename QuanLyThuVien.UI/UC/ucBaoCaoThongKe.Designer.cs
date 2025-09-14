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
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabBaoCaoThongKe = new DevExpress.XtraTab.XtraTabControl();
            this.pageBieuDo = new DevExpress.XtraTab.XtraTabPage();
            this.pageBang = new DevExpress.XtraTab.XtraTabPage();
            this.gcBang = new DevExpress.XtraGrid.GridControl();
            this.gvBang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblXemTheo = new System.Windows.Forms.Label();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartControl = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabBaoCaoThongKe)).BeginInit();
            this.tabBaoCaoThongKe.SuspendLayout();
            this.pageBieuDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).BeginInit();
            this.splitContainerControl2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).BeginInit();
            this.splitContainerControl2.Panel2.SuspendLayout();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.btnXem);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboType);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblXemTheo);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtDenNgay);
            this.splitContainerControl1.Panel1.Controls.Add(this.label1);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtTuNgay);
            this.splitContainerControl1.Panel1.Controls.Add(this.label6);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboLoaiBaoCao);
            this.splitContainerControl1.Panel1.Controls.Add(this.label5);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.tabBaoCaoThongKe);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1200, 720);
            this.splitContainerControl1.SplitterPosition = 125;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // cboLoaiBaoCao
            // 
            this.cboLoaiBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiBaoCao.FormattingEnabled = true;
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(155, 34);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(208, 24);
            this.cboLoaiBaoCao.TabIndex = 55;
            this.cboLoaiBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboLoaiBaoCao_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 54;
            this.label5.Text = "Loại báo cáo";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(523, 35);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(231, 23);
            this.dtTuNgay.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(441, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 68;
            this.label6.Text = "Từ ngày";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(880, 35);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(231, 23);
            this.dtDenNgay.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(798, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 70;
            this.label1.Text = "Đến ngày";
            // 
            // tabBaoCaoThongKe
            // 
            this.tabBaoCaoThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBaoCaoThongKe.Location = new System.Drawing.Point(0, 0);
            this.tabBaoCaoThongKe.Name = "tabBaoCaoThongKe";
            this.tabBaoCaoThongKe.SelectedTabPage = this.pageBieuDo;
            this.tabBaoCaoThongKe.Size = new System.Drawing.Size(1200, 585);
            this.tabBaoCaoThongKe.TabIndex = 0;
            this.tabBaoCaoThongKe.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageBieuDo,
            this.pageBang});
            // 
            // pageBieuDo
            // 
            this.pageBieuDo.Appearance.Header.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.pageBieuDo.Appearance.Header.Options.UseFont = true;
            this.pageBieuDo.Controls.Add(this.splitContainerControl2);
            this.pageBieuDo.Name = "pageBieuDo";
            this.pageBieuDo.Size = new System.Drawing.Size(1198, 557);
            this.pageBieuDo.Text = "BIỂU ĐỒ";
            // 
            // pageBang
            // 
            this.pageBang.Appearance.Header.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold);
            this.pageBang.Appearance.Header.Options.UseFont = true;
            this.pageBang.Name = "pageBang";
            this.pageBang.Size = new System.Drawing.Size(1198, 557);
            this.pageBang.Text = "BẢNG";
            // 
            // gcBang
            // 
            this.gcBang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBang.Location = new System.Drawing.Point(0, 0);
            this.gcBang.MainView = this.gvBang;
            this.gcBang.Name = "gcBang";
            this.gcBang.Size = new System.Drawing.Size(619, 557);
            this.gcBang.TabIndex = 0;
            this.gcBang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBang});
            // 
            // gvBang
            // 
            this.gvBang.GridControl = this.gcBang;
            this.gvBang.Name = "gvBang";
            // 
            // cboType
            // 
            this.cboType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(155, 85);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(208, 24);
            this.cboType.TabIndex = 73;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // lblXemTheo
            // 
            this.lblXemTheo.AutoSize = true;
            this.lblXemTheo.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXemTheo.Location = new System.Drawing.Point(54, 89);
            this.lblXemTheo.Name = "lblXemTheo";
            this.lblXemTheo.Size = new System.Drawing.Size(62, 16);
            this.lblXemTheo.TabIndex = 72;
            this.lblXemTheo.Text = "Xem theo";
            // 
            // btnXem
            // 
            this.btnXem.Appearance.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold);
            this.btnXem.Appearance.Options.UseFont = true;
            this.btnXem.Location = new System.Drawing.Point(741, 84);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(102, 27);
            this.btnXem.TabIndex = 74;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            // 
            // splitContainerControl2.Panel1
            // 
            this.splitContainerControl2.Panel1.Controls.Add(this.chartControl);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            // 
            // splitContainerControl2.Panel2
            // 
            this.splitContainerControl2.Panel2.Controls.Add(this.gcBang);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1198, 557);
            this.splitContainerControl2.SplitterPosition = 569;
            this.splitContainerControl2.TabIndex = 0;
            // 
            // chartControl
            // 
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl.Size = new System.Drawing.Size(569, 557);
            this.chartControl.TabIndex = 0;
            // 
            // ucBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ucBaoCaoThongKe";
            this.Size = new System.Drawing.Size(1200, 720);
            this.Load += new System.EventHandler(this.ucBaoCaoThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabBaoCaoThongKe)).EndInit();
            this.tabBaoCaoThongKe.ResumeLayout(false);
            this.pageBieuDo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel1)).EndInit();
            this.splitContainerControl2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2.Panel2)).EndInit();
            this.splitContainerControl2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.ComboBox cboLoaiBaoCao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraTab.XtraTabControl tabBaoCaoThongKe;
        private DevExpress.XtraTab.XtraTabPage pageBieuDo;
        private DevExpress.XtraTab.XtraTabPage pageBang;
        private DevExpress.XtraGrid.GridControl gcBang;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBang;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblXemTheo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraCharts.ChartControl chartControl;
    }
}
