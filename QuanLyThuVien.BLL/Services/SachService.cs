using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.BLL.Services
{
    public class SachService
    {
        private readonly IGenericRepository<Sach> _repository;
        private readonly string _connectionString;

        public SachService(IGenericRepository<Sach> repository)
        {
            _repository = repository;
            _connectionString = ConnectionStringProvider.GetConnectionString();
        }

        public IEnumerable<Sach> GetAllBooks()
        {
            using (var newContext = ContextFactory.CreateContext())
            {
                return newContext.Sach
                    .Include(s => s.MaTacGiaNavigation)
                    .Include(s => s.MaTheLoaiNavigation)
                    .Include(s => s.MaNhaXuatBanNavigation)
                    .ToList();
            }
        }
        
        public void DeleteBook(int maSach)
        {
            if (maSach <= 0)
                throw new ArgumentException("Mã sách không hợp lệ.", nameof(maSach));

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("[dbo].[XoaSach]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 60;

                        command.Parameters.Add("@MaSach", SqlDbType.Int).Value = maSach;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, "xóa sách");
                throw;
            }
        }
        
        public void AddBook(string tenSach, string isbn, int maTacGia, int maNhaXuatBan, int maTheLoai, 
                           int namXuatBan, decimal gia, int soLuong, bool trangThai = true)
        {
            if (string.IsNullOrWhiteSpace(tenSach))
                throw new ArgumentException("Tên sách không được để trống.", nameof(tenSach));
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN không được để trống.", nameof(isbn));
            if (maTacGia <= 0)
                throw new ArgumentException("Mã tác giả không hợp lệ.", nameof(maTacGia));
            if (maNhaXuatBan <= 0)
                throw new ArgumentException("Mã nhà xuất bản không hợp lệ.", nameof(maNhaXuatBan));
            if (maTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.", nameof(maTheLoai));

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("[dbo].[ThemSach]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 60;

                        command.Parameters.Add("@TenSach", SqlDbType.NVarChar, 200).Value = tenSach;
                        command.Parameters.Add("@ISBN", SqlDbType.NVarChar, 13).Value = isbn;
                        command.Parameters.Add("@MaTacGia", SqlDbType.Int).Value = maTacGia;
                        command.Parameters.Add("@MaNhaXuatBan", SqlDbType.Int).Value = maNhaXuatBan;
                        command.Parameters.Add("@MaTheLoai", SqlDbType.Int).Value = maTheLoai;
                        command.Parameters.Add("@NamXuatBan", SqlDbType.Int).Value = namXuatBan;
                        command.Parameters.Add("@Gia", SqlDbType.Decimal).Value = gia;
                        command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;
                        command.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThai;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, "thêm sách");
                throw;
            }
        }
        
        public void UpdateBook(int maSach, string tenSach, string isbn, int maTacGia, int maNhaXuatBan, int maTheLoai, 
                              int namXuatBan, decimal gia, int soLuong, bool trangThai)
        {
            if (maSach <= 0)
                throw new ArgumentException("Mã sách không hợp lệ.", nameof(maSach));
            if (string.IsNullOrWhiteSpace(tenSach))
                throw new ArgumentException("Tên sách không được để trống.", nameof(tenSach));
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN không được để trống.", nameof(isbn));
            if (maTacGia <= 0)
                throw new ArgumentException("Mã tác giả không hợp lệ.", nameof(maTacGia));
            if (maNhaXuatBan <= 0)
                throw new ArgumentException("Mã nhà xuất bản không hợp lệ.", nameof(maNhaXuatBan));
            if (maTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.", nameof(maTheLoai));

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("[dbo].[SuaSach]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 60;

                        command.Parameters.Add("@MaSach", SqlDbType.Int).Value = maSach;
                        command.Parameters.Add("@TenSach", SqlDbType.NVarChar, 200).Value = tenSach;
                        command.Parameters.Add("@ISBN", SqlDbType.NVarChar, 13).Value = isbn;
                        command.Parameters.Add("@MaTacGia", SqlDbType.Int).Value = maTacGia;
                        command.Parameters.Add("@MaNhaXuatBan", SqlDbType.Int).Value = maNhaXuatBan;
                        command.Parameters.Add("@MaTheLoai", SqlDbType.Int).Value = maTheLoai;
                        command.Parameters.Add("@NamXuatBan", SqlDbType.Int).Value = namXuatBan;
                        command.Parameters.Add("@Gia", SqlDbType.Decimal).Value = gia;
                        command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;
                        command.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThai;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, "cập nhật sách");
                throw;
            }
        }

        private void HandleSqlException(SqlException ex, string operation)
        {
            string userMessage = "Đã xảy ra lỗi khi " + operation + ".";
            
            if (ex.Message.Contains("CHK_Gia"))
            {
                userMessage = "❌ Lỗi: Giá sách phải lớn hơn 0!";
                MessageBox.Show(userMessage, "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (ex.Message.Contains("CHK_NamXuatBan"))
            {
                int currentYear = DateTime.Now.Year;
                userMessage = $"❌ Lỗi: Năm xuất bản phải từ năm 1900 đến {currentYear}!";
                MessageBox.Show(userMessage, "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (ex.Message.Contains("CHK_SoLuong"))
            {
                userMessage = "❌ Lỗi: Số lượng sách phải lớn hơn hoặc bằng 0!";
                MessageBox.Show(userMessage, "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ex.Message.Contains("FK_") || ex.Message.Contains("FOREIGN KEY"))
            {
                if (ex.Message.Contains("TacGia"))
                {
                    userMessage = "❌ Lỗi: Tác giả được chọn không tồn tại trong hệ thống!";
                }
                else if (ex.Message.Contains("NhaXuatBan"))
                {
                    userMessage = "❌ Lỗi: Nhà xuất bản được chọn không tồn tại trong hệ thống!";
                }
                else if (ex.Message.Contains("TheLoai"))
                {
                    userMessage = "❌ Lỗi: Thể loại được chọn không tồn tại trong hệ thống!";
                }
                else
                {
                    userMessage = "❌ Lỗi: Không thể xóa sách này vì đang được sử dụng trong hệ thống!\n\n" +
                             "Sách này có thể đang được mượn hoặc có liên quan đến các giao dịch khác.";
                }
                MessageBox.Show(userMessage, "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ex.Message.Contains("PRIMARY KEY") || ex.Message.Contains("duplicate"))
            {
                if (ex.Message.Contains("ISBN"))
                {
                    userMessage = "❌ Lỗi: ISBN này đã tồn tại trong hệ thống!";
                }
                else
                {
                    userMessage = "❌ Lỗi: Dữ liệu bị trùng lặp!";
                }
                MessageBox.Show(userMessage, "Lỗi trùng lặp dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ex.Message.Contains("DELETE") && ex.Message.Contains("REFERENCE"))
            {
                userMessage = "❌ Lỗi: Không thể xóa sách này vì đang được sử dụng trong hệ thống!\n\n" +
                             "Sách này có thể đang được mượn hoặc có liên quan đến các giao dịch khác.";
                MessageBox.Show(userMessage, "Lỗi xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            userMessage = $"❌ Lỗi hệ thống khi {operation}:\n\n{ex.Message}";
            MessageBox.Show(userMessage, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
