using DPM235479_NguyenVanThang_HideDelegate.Models;
using System;

namespace DPM235479_NguyenVanThang_HideDelegate.Services
{
    // TRƯỚC KHI HIDE DELEGATE
    // Lớp NhanVien phơi bày (expose) cấu trúc bên trong của nó là lớp ChiNhanh cho bên ngoài.
    // Khi Client muốn tìm Tên Người Quản Lý của một nhân viên, họ phải gọi chuỗi: nhanVien.PhongBan.NguoiQuanLy
    // Điều này vi phạm nguyên tắc Demeter (Chỉ nên nói chuyện với bạn bè trực tiếp).

    public class ChiNhanhBefore
    {
        public QuanLyChiNhanh NguoiQuanLy { get; set; }
        public string DiaChi { get; set; }
    }

    public class NhanVienBefore
    {
        public string TenNhanVien { get; set; }
        public ChiNhanhBefore PhongBan { get; set; } // Phơi bày Delegate
    }

    public class QuanLyNhanSuBefore
    {
        public void HienThiThongTinNguoiQuanLy(NhanVienBefore nv)
        {
            // Client phải tự mò mẫm xuyên qua ChiNhanh (PhongBan) mới lấy được Quản Lý
            // Nếu sau này cấu trúc thay đổi, code Client ở đây sẽ bị gãy.
            QuanLyChiNhanh sếp = nv.PhongBan.NguoiQuanLy;
            Console.WriteLine($"Sếp của {nv.TenNhanVien} là: {sếp.TenQuanLy}");
        }
    }
}
