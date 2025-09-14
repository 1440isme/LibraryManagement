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
using System.Diagnostics;

namespace QuanLyThuVien.UI
{
    public partial class frmTraSach : DevExpress.XtraEditors.XtraForm
    {
        private sealed class ComboItem
        {
            public string Text { get; }
            public string Value { get; }
            public ComboItem(string text, string value)
            {
                Text = text;
                Value = value;
            }
            public override string ToString() => Text; 
        }

        public string TinhTrangSach { get; private set; }
        public string GhiChu { get; private set; }

        public frmTraSach()
        {
            InitializeComponent();

            
            cboTinhTrangSach.Items.Clear();
            cboTinhTrangSach.Items.Add(new ComboItem("Bình thường", "BinhThuong"));
            cboTinhTrangSach.Items.Add(new ComboItem("Hư hỏng", "HuHong"));
            cboTinhTrangSach.Items.Add(new ComboItem("Mất", "Mat"));
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

                if (cboTinhTrangSach.SelectedItem is ComboItem item)
                {
                    TinhTrangSach = item.Value; // "BinhThuong" | "HuHong" | "Mat"
                    Debug.WriteLine($"[frmTraSach] UI selected '{item.Text}' -> TinhTrangSach='{TinhTrangSach}'");
                }
                else
                {
                    TinhTrangSach = "BinhThuong";
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