using DevExpress.XtraEditors;
using QuanLyThuVien.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.UI
{
    public partial class frmThanhToanPhat : DevExpress.XtraEditors.XtraForm
    {
        private readonly int _maPhat;
        private readonly ThanhToanPhatService _thanhToanPhatService;

        public string SelectedMethod { get; private set; }
        string note = "";
        public bool IsConfirmed { get; private set; }

        public frmThanhToanPhat(int maPhat, string defaultMethod = "Tiền mặt")
        {
            InitializeComponent();
            _maPhat = maPhat;
            _thanhToanPhatService = new ThanhToanPhatService();
            
            cboPTTToan.SelectedItem = defaultMethod;
            if (cboPTTToan.SelectedIndex == -1)
            {
                cboPTTToan.SelectedIndex = 0; 
            }
        }

        private void frmThanhToanPhat_Load(object sender, EventArgs e)
        {
                      
            
            IsConfirmed = false;
            SelectedMethod = cboPTTToan.SelectedItem?.ToString() ?? "Tiền mặt";
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPTTToan.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //var confirmResult = MessageBox.Show(
                //    $"Bạn có chắc chắn muốn thanh toán phạt mã {_maPhat}?\n" +
                //    $"Phương thức: {cboPTTToan.SelectedItem}",
                //    "Xác nhận thanh toán", 
                //    MessageBoxButtons.YesNo, 
                //    MessageBoxIcon.Question);

                //if (confirmResult != DialogResult.Yes)
                //    return;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;

                note = txtGhiChu.Text.Trim();
                SelectedMethod = cboPTTToan.SelectedItem.ToString();

                await Task.Run(() => _thanhToanPhatService.ExecuteThanhToanPhatProc(_maPhat, note, SelectedMethod));

                IsConfirmed = true;
                this.DialogResult = DialogResult.OK;

                MessageBox.Show("Thanh toán thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                btnXacNhan.Enabled = true;
                btnHuy.Enabled = true;
                btnXacNhan.Text = "Xác nhận";

                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            IsConfirmed = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}