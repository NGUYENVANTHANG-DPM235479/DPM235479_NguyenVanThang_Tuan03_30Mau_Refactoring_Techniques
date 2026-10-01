using DPM235479_NguyenVanThang_ChangeValueToRef.Models;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeValueToRef.Services
{
    // SAU KHI CHANGE VALUE TO REFERENCE
    // Thay vì liên tục dùng từ khóa 'new' để tạo Khách Hàng,
    // ta xây dựng một cái Kho lưu trữ (Registry / Dictionary) để quản lý duy nhất 1 object Khách Hàng.
    // Mọi Hóa Đơn sẽ TRỎ CHUNG về (Reference) một Object đó.
    // Chỉ cần đổi số điện thoại 1 lần là 1000 cái Hóa Đơn cập nhật theo tự động.

    public class KhachHangAfter
    {
        public string TenDaiLy { get; private set; } // Chỉ cho phép đọc
        public string SoDienThoai { get; set; }      // Cho phép sửa đổi

        // Ẩn constructor đi để cấm việc tạo bằng từ khóa 'new' lung tung
        internal KhachHangAfter(string ten)
        {
            TenDaiLy = ten;
        }
    }

    // TẠO RA MỘT KHO LƯU TRỮ (REGISTRY / FACTORY)
    public class KhachHangRegistry
    {
        private static Dictionary<string, KhachHangAfter> _danhSach = new Dictionary<string, KhachHangAfter>();

        // Đây là hàm Factory để lấy ra Khách Hàng (Dùng Reference, không dùng Value)
        public static KhachHangAfter LayKhachHang(string ten)
        {
            if (!_danhSach.ContainsKey(ten))
            {
                // Nếu chưa có thì mới tạo 1 cái duy nhất
                _danhSach[ten] = new KhachHangAfter(ten);
            }
            // Trả về vùng nhớ (Reference)
            return _danhSach[ten]; 
        }
    }

    public class HoaDonAfter
    {
        public string MaHoaDon { get; set; }
        public KhachHangAfter KhachHang { get; set; } // Giờ là Reference Object
        public List<MatHang> MatHangMua { get; set; }

        public HoaDonAfter(string ma, string tenKhach)
        {
            MaHoaDon = ma;
            // Dùng Registry để lấy đúng 1 bản duy nhất (Reference)
            KhachHang = KhachHangRegistry.LayKhachHang(tenKhach); 
            MatHangMua = new List<MatHang>();
        }
    }
}
