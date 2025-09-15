using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.UI.UC
{
    public partial class ucPhat : UserControl, IActivatable
    {
        private PhatService _phatService;
        private LichSuThanhToanService _lichSuThanhToanService;
        private bool _isDataLoaded = false;
        private bool _isInitialized = false;

        public bool IsDataLoaded => _isDataLoaded;

        public ucPhat()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            if (!_isInitialized)
            {
                InitializeServices();
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

        private void InitializeServices()
        {
            var dbContext = new QuanLyThuVienContext();
            var repo = new GenericRepository<Phat>(dbContext);
            var ctMuonRepo = new GenericRepository<ChiTietPhieuMuon>(dbContext);
            var thanhToanRepo = new GenericRepository<PaymentHistory>(dbContext);

            _phatService = new PhatService(repo, ctMuonRepo);
            _lichSuThanhToanService = new LichSuThanhToanService(thanhToanRepo);

            EventBus.Subscribe("PhatChanged", () =>
            {
                if (_isDataLoaded)
                {
                    LoadPhatData();
                }
            });
        }

        private void LoadData()
        {
            try
            {
                LoadPhatData();
                gcHistory.DataSource = _lichSuThanhToanService.GetAllPaymentHistories();
                _isDataLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshData()
        {
            try
            {
                LoadPhatData();
                gcHistory.DataSource = _lichSuThanhToanService.GetAllPaymentHistories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucPhat_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadPhatData()
        {
            try
            {
                var phatWithInfo = _phatService.GetAllPhatWithDetails().ToList();
                gcPhat.DataSource = phatWithInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu phạt: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvPhat_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var phat = e.Row as Phat;
                if (phat != null)
                {
                    switch (e.Column.FieldName)
                    {
                        case "Barcode":
                            e.Value = _phatService.GetBarcodeByMaMuonSach(phat.MaMuonSach);
                            break;
                        case "TenSach":
                            e.Value = _phatService.GetTenSachByMaMuonSach(phat.MaMuonSach);
                            break;
                        case "MaThanhVien":
                            e.Value = _phatService.GetMaThanhVienByMaMuonSach(phat.MaMuonSach);
                            break;
                        case "TenThanhVien":
                            e.Value = _phatService.GetTenThanhVienByMaMuonSach(phat.MaMuonSach);
                            break;
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                var rowHandle = gvPhat.FocusedRowHandle;
                if (rowHandle < 0)
                {
                    MessageBox.Show("Vui lòng chọn một mã phạt để thanh toán!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var maPhat = Convert.ToInt32(gvPhat.GetRowCellValue(rowHandle, "MaPhat"));
                var trangThai = gvPhat.GetRowCellValue(rowHandle, "TrangThai")?.ToString();

                if (trangThai == "Đã thanh toán")
                {
                    MessageBox.Show("Mã phạt này đã được thanh toán!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var tenSach = gvPhat.GetRowCellValue(rowHandle, "TenSach")?.ToString();
                var tenThanhVien = gvPhat.GetRowCellValue(rowHandle, "TenThanhVien")?.ToString();
                var soTien = gvPhat.GetRowCellValue(rowHandle, "SoTien");

                var confirmMessage = $"Bạn muốn thanh toán phạt:\n" +
                                   $"• Mã phạt: {maPhat}\n" +
                                   $"• Sách: {tenSach}\n" +
                                   $"• Thành viên: {tenThanhVien}\n" +
                                   $"• Số tiền: {soTien:N0} VNĐ\n\n" +
                                   $"Tiếp tục?";

                var result = MessageBox.Show(confirmMessage, "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using (var frmThanhToan = new frmThanhToanPhat(maPhat, "Tiền mặt"))
                {
                    frmThanhToan.StartPosition = FormStartPosition.CenterParent;
                    
                    var dialogResult = frmThanhToan.ShowDialog(this.ParentForm);

                    if (dialogResult == DialogResult.OK && frmThanhToan.IsConfirmed)
                    {
                        LoadPhatData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý thanh toán: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvHistory_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var lsu = e.Row as PaymentHistory;
                if (lsu != null)
                {
                    if (e.Column.FieldName == "TenThanhVien")
                        e.Value = lsu.MaThanhVienNavigation.TenThanhVien;
                }
            }
        }

        private void gvPhat_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "TrangThai")
            {
                string status = Convert.ToString(gvPhat.GetRowCellValue(e.RowHandle, "TrangThai"));
                if (status == "Đã thanh toán")
                    e.Appearance.BackColor = Color.LightGreen;
                else e.Appearance.BackColor = Color.MistyRose;
            }
        }
    }
}
