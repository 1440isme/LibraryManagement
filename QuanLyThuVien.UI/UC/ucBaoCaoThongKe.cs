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
using DevExpress.XtraCharts;

namespace QuanLyThuVien.UI.UC
{
    public partial class ucBaoCaoThongKe : UserControl
    {
        public ucBaoCaoThongKe()
        {
            InitializeComponent();
        }

        private void ucBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            initializeComboBoxes();
            lblXemTheo.Visible = false;
            cboType.Visible = false;
            
            loadBaoCao();
        }

        private void initializeComboBoxes()
        {
            cboLoaiBaoCao.DataSource = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string,string>("TopSachMuon", "Top sách được mượn"),
                new KeyValuePair<string, string>("TongTienPhat", "Tổng tiền phạt"),
                new KeyValuePair<string,string>("TinhTrangSach", "Thống kê tình trạng sách"),
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            loadBaoCao();
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
            diagram.AxisX.Label.Angle = -45;
            
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
