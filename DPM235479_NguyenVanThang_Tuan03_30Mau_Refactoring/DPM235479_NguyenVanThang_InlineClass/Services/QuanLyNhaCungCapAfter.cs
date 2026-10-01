using System;

namespace DPM235479_NguyenVanThang_InlineClass.Services
{
    // SAU KHI INLINE CLASS
    // Xóa sổ luôn lớp LienHeNhaCungCap.
    // Di chuyển (Inline) 2 thuộc tính SoDienThoai và Email trực tiếp vào lớp NhaCungCapAfter.
    // Code bây giờ đã đơn giản, trực quan và dễ xài hơn rất nhiều.

    public class NhaCungCapAfter
    {
        public string TenNhaCungCap { get; set; }
        public string MaSoThue { get; set; }
        
        // Các trường dữ liệu đã được INLINE (gộp) trực tiếp vào đây
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        public string LayThongTin()
        {
            return $"Tên NCC: {TenNhaCungCap} - LH: {SoDienThoai}";
        }
    }
}
