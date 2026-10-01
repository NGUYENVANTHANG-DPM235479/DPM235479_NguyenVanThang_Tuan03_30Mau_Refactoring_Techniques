using DPM235479_NguyenVanThang_MoveMethod.Models;
using System;

namespace DPM235479_NguyenVanThang_MoveMethod.Services
{
    public class KhachHangBefore
    {
        public string TenKhachHang { get; set; }
        
        // TRƯỚC KHI MOVE METHOD
        // Hàm tính tiền này được đặt ở lớp KhachHang, nhưng nó lại sử dụng
        // 100% dữ liệu từ lớp ThongTinNongDuoc (đơn giá, số lượng, chiết khấu).
        // Hàm này có độ "gắn kết" (coupling) với ThongTinNongDuoc mạnh hơn nhiều so với KhachHang.
        public double TinhTienHoaDon(ThongTinNongDuoc thuoc)
        {
            double tienGoc = thuoc.DonGia * thuoc.SoLuong;
            return tienGoc - (tienGoc * thuoc.HeSoChietKhau);
        }
    }
}
