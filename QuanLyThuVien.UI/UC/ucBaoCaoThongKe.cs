using Microsoft.IdentityModel.Protocols;
using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace QuanLyThuVien.UI.UC
{
    public partial class ucBaoCaoThongKe : UserControl, IActivatable
    {
        private bool _isDataLoaded = false;
        private bool _isInitialized = false;

        public bool IsDataLoaded => _isDataLoaded;

        public ucBaoCaoThongKe()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            if (!_isInitialized)
            {
                InitializeControls();
                _isInitialized = true;
            }

            if (!_isDataLoaded)
            {
                LoadData();
            }
            else
            {
                RefreshData();
            }
        }

        public void OnDeactivated()
        {
           
        }

        private void InitializeControls()
        {
            initializeComboBoxes();
            lblXemTheo.Visible = false;
            cboType.Visible = false;

            dtTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtDenNgay.Value = dtTuNgay.Value.AddMonths(1).AddDays(-1);
        }

        private void LoadData()
        {
            try
            {
                loadBaoCao();
                _isDataLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshData()
        {
            try
            {
                loadBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            
        }

        private void initializeComboBoxes()
        {
            cboLoaiBaoCao.DataSource = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string,string>("TopSachMuon", "Top sách được mượn"),
                new KeyValuePair<string, string>("TongTienPhat", "Tổng tiền phạt"),
                new KeyValuePair<string,string>("TinhTrangSach", "Thống kê tình trạng sách"),
                new KeyValuePair<string,string>("SachQuaHan", "Thống kê sách mượn quá hạn"),
                new KeyValuePair<string, string>("SachMuonByType", "Thống kê sách mượn theo loại thành viên")
            };
            cboLoaiBaoCao.DisplayMember = "Value";
            cboLoaiBaoCao.ValueMember = "Key";
        }

        private void cboLoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiBaoCao.SelectedValue?.ToString() == "TongTienPhat")
            {
                lblXemTheo.Visible = true;
                cboType.Visible = true;
                
                cboType.DataSource = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("PhatTheoTuan","Tổng tiền phạt theo tuần"),
                    new KeyValuePair<string,string>("PhatTheoThang", "Tổng tiền phạt theo tháng"),
                    new KeyValuePair<string,string>("PhatTheoQuy", "Tổng tiền phạt theo quý"),
                    new KeyValuePair<string, string>("PhatTheoNam", "Tổng tiền phạt theo năm"),
                };
                cboType.DisplayMember = "Value";
                cboType.ValueMember = "Key";
                
                return;
            }
            else if (cboLoaiBaoCao.SelectedValue?.ToString() == "SachMuonByType")
            {
                lblXemTheo.Visible = true;
                cboType.Visible = true;
                cboType.DataSource = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("SinhVien", "Sinh viên"),
                    new KeyValuePair<string, string>("GiangVien", "Giảng viên"),
                };
                cboType.DisplayMember = "Value";
                cboType.ValueMember = "Key";
                return;
            }
            else
            {
                lblXemTheo.Visible = false;
                cboType.Visible = false;
                loadBaoCao();
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.Visible && cboType.SelectedValue != null)
            {
                loadBaoCao();
            }
        }

        private void loadBaoCao()
        {
            try
            {
                if (cboLoaiBaoCao.SelectedValue == null)
                    return;

                ResetControls();

                var service = new BaoCaoService();
                DataTable dt = null;
                string selectedType = cboLoaiBaoCao.SelectedValue.ToString();
                
                switch (selectedType)
                {
                    case "TopSachMuon":
                        dt = service.GetTopSachMuon(dtTuNgay.Value, dtDenNgay.Value);
                        break;

                    case "TongTienPhat":
                        if (cboType.SelectedValue == null)
                            return;
                            
                        string phatType = cboType.SelectedValue.ToString();
                        
                        switch (phatType)
                        {
                            case "PhatTheoTuan":
                                dt = service.GetTongTienPhatTheoTuan(DateTime.Now.Year);
                                break;
                            case "PhatTheoThang":
                                dt = service.GetTongTienPhatTheoThang(DateTime.Now.Year);
                                break;
                            case "PhatTheoQuy":
                                dt = service.GetTongTienPhatTheoQuy(DateTime.Now.Year);
                                break;
                            case "PhatTheoNam":
                                dt = service.GetTongTienPhatTheoNam();
                                break;
                        }
                        break;
                        
                    case "TinhTrangSach":
                        dt = service.GetThongKeTinhTrangSach();
                        break;
                    case "SachQuaHan":
                        dt = service.GetSachQuaHan();
                        break;
                    case "SachMuonByType":
                        if (cboType.SelectedValue == null)
                            return;
                        string memberType = cboType.SelectedValue.ToString();
                        switch (memberType)
                        {
                            case "SinhVien":
                                dt = service.GetMuonSachByType("SinhVien");
                                break;
                            case "GiangVien":
                                dt = service.GetMuonSachByType("GiangVien");
                                break;
                        }
                        break;
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    gcBang.DataSource = dt;
                    gvBang.BestFitColumns();
                    gcBang.RefreshDataSource();
                    gvBang.RefreshData();
                    
                    CreateChart(dt, selectedType);
                }
                else
                {
                    var emptyTable = new DataTable();
                    emptyTable.Columns.Add("Thông báo", typeof(string));
                    emptyTable.Rows.Add("Không có dữ liệu để hiển thị");
                    gcBang.DataSource = emptyTable;
                    
                    chartControl.Series.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateChart(DataTable data, string reportType)
        {
            try
            {
                chartControl.Series.Clear();
                
                switch (reportType)
                {
                    case "TopSachMuon":
                        CreateTopBooksChart(data);
                        break;
                    case "TongTienPhat":
                        CreateFineChart(data);
                        break;
                    case "TinhTrangSach":
                        CreateBookStatusChart(data);
                        break;
                    case "SachQuaHan":
                        CreateOverdueBooksChart(data);
                        break;
                    case "SachMuonByType":
                        CreateBorrowingStatsByMemberTypeChart(data);
                        break;
                }
                
                chartControl.RefreshData();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating chart: {ex.Message}");
            }
        }

        private void CreateTopBooksChart(DataTable data)
        {
            if (data.Rows.Count == 0) return;

            var series = new Series("Top sách được mượn", ViewType.Bar);
            series.ArgumentScaleType = ScaleType.Qualitative;
            
            foreach (DataRow row in data.Rows)
            {
                string tenSach = row[0].ToString(); 
                int soLuotMuon = Convert.ToInt32(row[1]); 
                
                series.Points.Add(new SeriesPoint(tenSach, soLuotMuon));
            }
            
            chartControl.Series.Add(series);
            
            chartControl.Titles.Clear();
            chartControl.Titles.Add(new ChartTitle { Text = "TOP SÁCH ĐƯỢC MƯỢN NHIỀU NHẤT" });
            
            var diagram = (XYDiagram)chartControl.Diagram;
            diagram.AxisX.Title.Text = "Tên sách";
            diagram.AxisY.Title.Text = "Số lượt mượn";
            
            series.View.Color = Color.FromArgb(79, 129, 189);
        }

        private void CreateFineChart(DataTable data)
        {
            if (data.Rows.Count == 0) return;

            string phatType = cboType.SelectedValue?.ToString() ?? "";
            
            var series = new Series("Tiền phạt", ViewType.Line);
            series.ArgumentScaleType = ScaleType.Qualitative;
            
            string chartTitle = "";
            string xAxisTitle = "";
            
            switch (phatType)
            {
                case "PhatTheoTuan":
                    chartTitle = "TIỀN PHẠT THEO TUẦN";
                    xAxisTitle = "Tuần";
                    break;
                case "PhatTheoThang":
                    chartTitle = "TIỀN PHẠT THEO THÁNG";
                    xAxisTitle = "Tháng";
                    break;
                case "PhatTheoQuy":
                    chartTitle = "TIỀN PHẠT THEO QUÝ";
                    xAxisTitle = "Quý";
                    break;
                case "PhatTheoNam":
                    chartTitle = "TIỀN PHẠT THEO NĂM";
                    xAxisTitle = "Năm";
                    break;
            }
            
            foreach (DataRow row in data.Rows)
            {
                string period = row[0].ToString(); 
                decimal tienPhat = Convert.ToDecimal(row[1]); 
                
                series.Points.Add(new SeriesPoint(period, tienPhat));
            }
            
            chartControl.Series.Add(series);
            
            chartControl.Titles.Clear();
            chartControl.Titles.Add(new ChartTitle { Text = chartTitle });
            
            var diagram = (XYDiagram)chartControl.Diagram;
            diagram.AxisX.Title.Text = xAxisTitle;
            diagram.AxisY.Title.Text = "Tiền phạt (VNĐ)";
            
            var lineView = (LineSeriesView)series.View;
            lineView.Color = Color.FromArgb(192, 80, 77);
            lineView.LineMarkerOptions.Kind = MarkerKind.Circle;
            lineView.LineMarkerOptions.Size = 8;
        }

        private void CreateBookStatusChart(DataTable data)
        {
            if (data.Rows.Count == 0) return;

            var series = new Series("Tình trạng sách", ViewType.Pie);
            
            foreach (DataRow row in data.Rows)
            {
                string tinhTrang = row[0].ToString(); 
                int soLuong = Convert.ToInt32(row[1]); 
                
                series.Points.Add(new SeriesPoint(tinhTrang, soLuong));
            }
            
            chartControl.Series.Add(series);
            
            chartControl.Titles.Clear();
            chartControl.Titles.Add(new ChartTitle { Text = "THỐNG KÊ TÌNH TRẠNG SÁCH" });
            
            var pieView = (PieSeriesView)series.View;
            pieView.ExplodedDistancePercentage = 10;
            
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{A}: {V} ({VP:P1})";
            
            chartControl.PaletteName = "Bright";
        }

        private void CreateOverdueBooksChart(DataTable data)
        {
            if (data.Rows.Count == 0) return;

            var overdueGroups = new Dictionary<string, int>();
            
            foreach (DataRow row in data.Rows)
            {
                DateTime ngayTraDuKien = Convert.ToDateTime(row["NgayTraDuKien"]);
                int soNgayQuaHan = (DateTime.Now - ngayTraDuKien).Days;
                
                string nhom = GetOverdueGroup(soNgayQuaHan);
                
                if (overdueGroups.ContainsKey(nhom))
                    overdueGroups[nhom]++;
                else
                    overdueGroups[nhom] = 1;
            }

            var series = new Series("Sách quá hạn", ViewType.Bar);
            series.ArgumentScaleType = ScaleType.Qualitative;
            
            var sortedGroups = overdueGroups.OrderBy(kvp => GetGroupOrder(kvp.Key));
            
            foreach (var group in sortedGroups)
            {
                series.Points.Add(new SeriesPoint(group.Key, group.Value));
            }
            
            chartControl.Series.Add(series);
            
            chartControl.Titles.Clear();
            chartControl.Titles.Add(new ChartTitle { Text = "THỐNG KÊ SÁCH MƯỢN QUÁ HẠN THEO NHÓM NGÀY" });
            
            var diagram = (XYDiagram)chartControl.Diagram;
            diagram.AxisX.Title.Text = "Khoảng ngày quá hạn";
            diagram.AxisY.Title.Text = "Số lượng sách";
            
            var barView = (BarSeriesView)series.View;
            series.View.Color = Color.FromArgb(220, 53, 69); 
            
            var totalSeries = new Series("Tổng số sách quá hạn", ViewType.Line);
            totalSeries.ArgumentScaleType = ScaleType.Qualitative;
            
            int runningTotal = 0;
            foreach (var group in sortedGroups)
            {
                runningTotal += group.Value;
                totalSeries.Points.Add(new SeriesPoint(group.Key, runningTotal));
            }
            
            chartControl.Series.Add(totalSeries);
            
            var lineView = (LineSeriesView)totalSeries.View;
            lineView.Color = Color.FromArgb(255, 193, 7); 
            lineView.LineMarkerOptions.Kind = MarkerKind.Circle;
            lineView.LineMarkerOptions.Size = 6;
            
            chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
            chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.Bottom;
        }

        private string GetOverdueGroup(int soNgayQuaHan)
        {
            if (soNgayQuaHan <= 7)
                return "1-7 ngày";
            else if (soNgayQuaHan <= 14)
                return "8-14 ngày";
            else if (soNgayQuaHan <= 30)
                return "15-30 ngày";
            else if (soNgayQuaHan <= 60)
                return "31-60 ngày";
            else
                return "Trên 60 ngày";
        }

        private int GetGroupOrder(string group)
        {
            switch (group)
            {
                case "1-7 ngày": return 1;
                case "8-14 ngày": return 2;
                case "15-30 ngày": return 3;
                case "31-60 ngày": return 4;
                case "Trên 60 ngày": return 5;
                default: return 99;
            }
        }

        private void CreateBorrowingStatsByMemberTypeChart(DataTable data)
        {
            if (data.Rows.Count == 0) return;

            var memberType = cboType.SelectedValue?.ToString() ?? "";
            string chartTitle = $"DASHBOARD THỐNG KÊ - {(memberType == "SinhVien" ? "SINH VIÊN" : "GIẢNG VIÊN")}";
            
            foreach (DataRow row in data.Rows)
            {
                int soThanhVien = Convert.ToInt32(row["SoThanhVien"]);
                int tongSachMuon = Convert.ToInt32(row["TongSachMuon"]);
                decimal tyLeQuaHan = Convert.ToDecimal(row["TyLeQuaHan"]);
                decimal tongPhat = Convert.ToDecimal(row["TongPhat"]);
                
                var series = new Series("Thống kê mượn sách", ViewType.Bar);
                series.ArgumentScaleType = ScaleType.Qualitative;
                
                series.Points.Add(new SeriesPoint("Số thành viên", soThanhVien));
                series.Points.Add(new SeriesPoint($"Sách mượn/TV\n({(soThanhVien > 0 ? (double)tongSachMuon/soThanhVien : 0):F1})", 
                    soThanhVien > 0 ? (double)tongSachMuon/soThanhVien : 0));
                series.Points.Add(new SeriesPoint($"Tỷ lệ quá hạn\n({tyLeQuaHan:F1}%)", tyLeQuaHan));
                series.Points.Add(new SeriesPoint($"Tiền phạt/TV\n({(soThanhVien > 0 ? tongPhat/soThanhVien/1000 : 0):F0}k)", 
                    soThanhVien > 0 ? (double)(tongPhat/soThanhVien)/1000 : 0));
                
                chartControl.Series.Add(series);
                
                var barView = (BarSeriesView)series.View;
                series.View.Color = Color.FromArgb(54, 162, 235);
                
                series.Points[0].Color = Color.FromArgb(75, 192, 192);  // Xanh lá - thành viên
                series.Points[1].Color = Color.FromArgb(54, 162, 235);  // Xanh dương - sách/thành viên  
                series.Points[2].Color = Color.FromArgb(255, 206, 86);  // Vàng - tỷ lệ quá hạn
                series.Points[3].Color = Color.FromArgb(255, 99, 132);  // Đỏ - tiền phạt
                
                break;
            }
            
            chartControl.Titles.Clear();
            chartControl.Titles.Add(new ChartTitle { Text = chartTitle });
            
            if (!(chartControl.Diagram is XYDiagram))
            {
                chartControl.Diagram = new XYDiagram();
            }
            
            var diagram = (XYDiagram)chartControl.Diagram;
            diagram.AxisX.Title.Text = "Chỉ số";
            diagram.AxisY.Title.Text = "Giá trị";
            
            diagram.AxisX.Label.Angle = -15;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = true;
            
            chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
        }

        private void ResetControls()
        {
            try
            {
                gcBang.DataSource = null;
                gvBang.Columns.Clear();
                gcBang.RefreshDataSource();
                gvBang.RefreshData();
                
                chartControl.Series.Clear();
                chartControl.Titles.Clear();
                chartControl.RefreshData();
                
                System.Windows.Forms.Application.DoEvents();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error resetting controls: {ex.Message}");
            }
        }
    }
}
