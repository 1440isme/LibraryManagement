using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.UI
{
    public static class SqlErrorTranslator
    {
        public static string ToFriendlyMessage(Exception ex)
        {
            try
            {
                if (ex is DbUpdateException dbEx && dbEx.InnerException is SqlException sqlEx)
                {
                    switch (sqlEx.Number)
                    {
                        case 2627: // Unique
                        case 2601:
                            return "Dữ liệu đã tồn tại (ví dụ ISBN hoặc Email trùng).";

                        case 547: // FK hoặc CHECK
                            if (sqlEx.Message.Contains("CHECK constraint"))
                            {
                                if (sqlEx.Message.Contains("CHK_NgayTraDuKien"))
                                    return "Ngày trả dự kiến phải sau ngày mượn.";
                                if (sqlEx.Message.Contains("CHK_NgayTraThucTe"))
                                    return "Ngày trả thực tế không hợp lệ.";
                                if (sqlEx.Message.Contains("CHK_ThanhVien_Loai"))
                                    return "Loại thành viên không hợp lệ. Chỉ chấp nhận: Sinh viên, Giảng viên, Khách.";
                                if (sqlEx.Message.Contains("CHK_BanSao_TinhTrang"))
                                    return "Tình trạng bản sao không hợp lệ.";
                                if (sqlEx.Message.Contains("CHK_NamSinh"))
                                    return "Năm sinh không hợp lệ.";
                                if (sqlEx.Message.Contains("CHK_NamXuatBan"))
                                    return "Năm xuất bản không hợp lệ.";

                                return "Dữ liệu không hợp lệ (vi phạm quy tắc hệ thống).";
                            }
                            else
                            {
                                return "Không thể xóa vì còn dữ liệu liên quan.";
                            }

                        case 50000: // RAISERROR/THROW
                            return sqlEx.Message;

                        default:
                            return $"Có lỗi hệ thống (Mã lỗi SQL: {sqlEx.Number}): {sqlEx.Message}";
                    }
                }
                return "Đã xảy ra lỗi không xác định. Vui lòng thử lại.";
            }
            catch (Exception innerEx)
            {
                return $"Lỗi khi xử lý ngoại lệ: {innerEx.Message}";
            }
        }

    }
}

