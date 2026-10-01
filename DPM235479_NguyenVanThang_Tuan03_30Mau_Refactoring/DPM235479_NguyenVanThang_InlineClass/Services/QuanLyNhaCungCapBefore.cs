using System;

namespace DPM235479_NguyenVanThang_InlineClass.Services
{
    // TRƯỚC KHI INLINE CLASS
    // Lớp LienHeNhaCungCap quá nhỏ, chỉ chứa đúng 1-2 trường dữ liệu không đáng kể (Email, SDT).
    // Việc tách nó ra thành 1 class riêng biệt là vô nghĩa và làm phức tạp hóa hệ thống (Over-engineering).
    // => Cần phải gộp lại vào class chính (NhaCungCapBefore).

    public class LienHeNhaCungCap
    {
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
    }

    public class NhaCungCapBefore
    {
        public string TenNhaCungCap { get; set; }
        public string MaSoThue { get; set; }
        
        // Gọi đến 1 class khác chỉ để lấy SĐT và Email
        public LienHeNhaCungCap ThongTinLienHe { get; set; }

        public string LayThongTin()
        {
            return $"Tên NCC: {TenNhaCungCap} - LH: {ThongTinLienHe.SoDienThoai}";
        }
    }
}
