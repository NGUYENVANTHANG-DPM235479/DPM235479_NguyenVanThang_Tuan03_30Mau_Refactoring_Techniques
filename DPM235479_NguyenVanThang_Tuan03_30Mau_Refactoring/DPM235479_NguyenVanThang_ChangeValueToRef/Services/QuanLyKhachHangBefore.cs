using DPM235479_NguyenVanThang_ChangeValueToRef.Models;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeValueToRef.Services
{
    // TRƯỚC KHI CHANGE VALUE TO REFERENCE
    // Ta có class KhachHang là một "Value Object". 
    // Mỗi khi tạo Hóa Đơn (HoaDonBefore) cho đại lý "Nông Dược A", ta lại 'new' ra một KhachHang("Nông Dược A") mới.
    // Nếu Đại lý A đổi số điện thoại, ta phải đi lục tìm TẤT CẢ các hóa đơn của Đại lý A
    // để cập nhật số điện thoại cho từng object KhachHang bên trong nó. Cực kỳ rủi ro!

    public class KhachHangBefore
    {
        public string TenDaiLy { get; set; }
        public string SoDienThoai { get; set; }

        public KhachHangBefore(string ten, string sdt)
        {
            TenDaiLy = ten;
            SoDienThoai = sdt;
        }
    }

    public class HoaDonBefore
    {
        public string MaHoaDon { get; set; }
        public KhachHangBefore KhachHang { get; set; } // Khách hàng được tạo mới liên tục (Value)
        public List<MatHang> MatHangMua { get; set; }

        public HoaDonBefore(string ma, string tenKhach, string sdtKhach)
        {
            MaHoaDon = ma;
            // Mỗi hóa đơn tạo ra một bản sao (bản clone) của Khách hàng
            KhachHang = new KhachHangBefore(tenKhach, sdtKhach); 
            MatHangMua = new List<MatHang>();
        }
    }
}
