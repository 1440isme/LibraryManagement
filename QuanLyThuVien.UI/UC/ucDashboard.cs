using DevExpress.DashboardWin;
using DevExpress.XtraCharts;
using Microsoft.IdentityModel.Protocols;
using QuanLyThuVien.BLL.Services;
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

namespace QuanLyThuVien.UI.UC
{
    public partial class ucDashboard : UserControl
    {
        private DashboardService service;

        public ucDashboard()
        {
            InitializeComponent();
            service = new DashboardService();
            
            tabLineChart.SelectedPageChanged += TabLineChart_SelectedPageChanged;
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            loadDashboard();
        }

        private void loadDashboard()
        {
            var ds = service.GetSummary();
            lblTongSach.Text = ds.Tables[0].Rows[0]["TongSoSach"].ToString();
            lblSachChuaMuon.Text = ds.Tables[1].Rows[0]["SachChuaMuon"].ToString();
            lblSachDangMuon.Text = ds.Tables[2].Rows[0]["SachDangMuon"].ToString();
            lblTongThanhVien.Text = ds.Tables[3].Rows[0]["TongThanhVien"].ToString();

            LoadTrendChart("DAY");
            gcQuaHan.DataSource = service.GetOverdue(DateTime.Now);
            loadPieChart();
        }

        private void TabLineChart_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string groupBy = "";
            switch (e.Page.Name)
            {
                case "pageNgay":
                    groupBy = "DAY";
                    break;
                case "pageTuan":
                    groupBy = "WEEK";
                    break;
                case "pageThang":
                    groupBy = "MONTH";
                    break;
            }
            
            if (!string.IsNullOrEmpty(groupBy))
            {
                LoadTrendChart(groupBy);
            }
        }

        private void LoadTrendChart(string groupBy)
        {
            try
            {
                DateTime fromDate, toDate;
                
                switch (groupBy)
                {
                    case "DAY":
                        fromDate = DateTime.Now.AddDays(-30);
                        toDate = DateTime.Now;
                        break;
                    case "WEEK":
                        fromDate = DateTime.Now.AddDays(-84); 
                        toDate = DateTime.Now;
                        break;
                    case "MONTH":
                        fromDate = DateTime.Now.AddMonths(-12);
                        toDate = DateTime.Now;
                        break;
                    default:
                        fromDate = DateTime.Now.AddDays(-30);
                        toDate = DateTime.Now;
                        break;
                }

                DataTable dt = service.GetTrends(fromDate, toDate, groupBy);
                
                ChartControl currentChart = null;
                switch (groupBy)
                {
                    case "DAY":
                        currentChart = chartLineNgay;
                        break;
                    case "WEEK":
                        currentChart = chartLineTuan;
                        break;
                    case "MONTH":
                        currentChart = chartLineThang;
                        break;
                }

                if (currentChart != null && dt.Rows.Count > 0)
                {
                    ConfigureLineChart(currentChart, dt, groupBy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureLineChart(ChartControl chart, DataTable data, string groupBy)
        {
            chart.Series.Clear();
            
            Series sachMoiSeries = new Series("Sách mới", ViewType.Line);
            Series sachMuonSeries = new Series("Sách mượn", ViewType.Line);
            Series thanhVienMoiSeries = new Series("Thành viên mới", ViewType.Line);

            sachMoiSeries.View.Color = Color.FromArgb(34, 197, 94); // Xanh lá
            sachMuonSeries.View.Color = Color.FromArgb(239, 68, 68); // Đỏ
            thanhVienMoiSeries.View.Color = Color.FromArgb(6, 182, 212); // Xanh dương

            ((LineSeriesView)sachMoiSeries.View).LineStyle.Thickness = 3;
            ((LineSeriesView)sachMuonSeries.View).LineStyle.Thickness = 3;
            ((LineSeriesView)thanhVienMoiSeries.View).LineStyle.Thickness = 3;

            var groupedData = data.AsEnumerable()
                .GroupBy(row => row.Field<object>("ThoiGian").ToString())
                .OrderBy(g => g.Key)
                .ToList();

            foreach (var timeGroup in groupedData)
            {
                string timeValue = timeGroup.Key;
                
                int sachMoi = timeGroup.Where(row => row.Field<string>("Loai") == "SachMoi")
                                     .Sum(row => Convert.ToInt32(row.Field<object>("SoLuong") ?? 0));
                
                int sachMuon = timeGroup.Where(row => row.Field<string>("Loai") == "SachMuon")
                                       .Sum(row => Convert.ToInt32(row.Field<object>("SoLuong") ?? 0));
                
                int thanhVienMoi = timeGroup.Where(row => row.Field<string>("Loai") == "ThanhVienMoi")
                                           .Sum(row => Convert.ToInt32(row.Field<object>("SoLuong") ?? 0));

                string displayTime = FormatTimeDisplay(timeValue, groupBy);
                
                sachMoiSeries.Points.Add(new SeriesPoint(displayTime, sachMoi));
                sachMuonSeries.Points.Add(new SeriesPoint(displayTime, sachMuon));
                thanhVienMoiSeries.Points.Add(new SeriesPoint(displayTime, thanhVienMoi));
            }

            chart.Series.Add(sachMoiSeries);
            chart.Series.Add(sachMuonSeries);
            chart.Series.Add(thanhVienMoiSeries);

            chart.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            
            chart.Titles.Clear();
            string title = groupBy == "DAY" ? "Thống kê theo ngày" :
                          groupBy == "WEEK" ? "Thống kê theo tuần" :
                          "Thống kê theo tháng";
            chart.Titles.Add(new ChartTitle { Text = title });

            if (chart.Diagram is XYDiagram diagram)
            {
                diagram.AxisX.Title.Text = groupBy == "DAY" ? "Ngày" :
                                          groupBy == "WEEK" ? "Tuần" : "Tháng";
                diagram.AxisY.Title.Text = "Số lượng";
               
                
                diagram.AxisX.GridLines.Visible = true;
                diagram.AxisY.GridLines.Visible = true;
            }

            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.Top;
        }

        private string FormatTimeDisplay(string timeValue, string groupBy)
        {
            switch (groupBy)
            {
                case "DAY":
                    if (DateTime.TryParse(timeValue, out DateTime date))
                        return date.ToString("dd/MM");
                    return timeValue;
                    
                case "WEEK":
                    return $"Tuần {timeValue}";
                    
                case "MONTH":
                    return $"Tháng {timeValue}";
                    
                default:
                    return timeValue;
            }
        }
        private void loadPieChart()
        {
            DataTable dt = service.GetBookStatus();
            CreateBookStatusChart(dt);
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

            chartPie.Series.Add(series);

            chartPie.Titles.Clear();
            chartPie.Titles.Add(new ChartTitle { Text = "Thống kê tình trạng sách" });

            var pieView = (PieSeriesView)series.View;
            pieView.ExplodedDistancePercentage = 10;

            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{A}: {V} ({VP:P1})";

        }
    }
}
