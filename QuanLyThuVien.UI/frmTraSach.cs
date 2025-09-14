using DevExpress.XtraEditors;
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
    public partial class frmTraSach : DevExpress.XtraEditors.XtraForm
    {
        public string TinhTrangSach { get; private set; }
        public string GhiChu { get; private set; }

        public frmTraSach()
        {
            InitializeComponent();
            
            cboTinhTrangSach.SelectedIndex = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboTinhTrangSach.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn tình trạng sách!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedValue = cboTinhTrangSach.SelectedItem.ToString();
                switch (selectedValue)
                {
                    case "Bình thường":
                        TinhTrangSach = "BinhThuong";
                        break;
                    case "Hư hỏng":
                        TinhTrangSach = "HuHong";
                        break;
                    case "Mất":
                        TinhTrangSach = "Mat";
                        break;
                    default:
                        TinhTrangSach = "BinhThuong";
                        break;
                }

                GhiChu = txtGhiChu.Text.Trim();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}