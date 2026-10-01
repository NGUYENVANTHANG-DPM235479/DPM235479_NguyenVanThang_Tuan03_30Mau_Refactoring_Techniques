using DPM235479_NguyenVanThang_HideDelegate.Models;
using System;

namespace DPM235479_NguyenVanThang_HideDelegate.Services
{
    // SAU KHI HIDE DELEGATE
    // Thay vì bắt Client gọi nhanVien.PhongBan.NguoiQuanLy,
    // ta tạo 1 phương thức LayNguoiQuanLy() ngay bên trong lớp NhanVienAfter.
    // Việc này giúp Giấu đi Delegate (PhongBan) để Client không cần biết đến cấu trúc nội bộ.

    public class ChiNhanhAfter
    {
        public QuanLyChiNhanh NguoiQuanLy { get; set; }
        public string DiaChi { get; set; }
    }

    public class NhanVienAfter
    {
        public string TenNhanVien { get; set; }
        private ChiNhanhAfter _phongBan; // Private: Giấu hoàn toàn cấu trúc bên trong

        public NhanVienAfter(string ten, ChiNhanhAfter phongBan)
        {
            TenNhanVien = ten;
            _phongBan = phongBan;
        }

        // HIDE DELEGATE: Lớp NhanVien tự cung cấp hàm lấy quản lý
        public QuanLyChiNhanh LayNguoiQuanLy()
        {
            return _phongBan.NguoiQuanLy;
        }
    }

    public class QuanLyNhanSuAfter
    {
        public void HienThiThongTinNguoiQuanLy(NhanVienAfter nv)
        {
            // Client gọi trực tiếp hàm của NhanVien, không cần biết lớp ChiNhanh là gì!
            QuanLyChiNhanh sếp = nv.LayNguoiQuanLy();
            Console.WriteLine($"Sếp của {nv.TenNhanVien} là: {sếp.TenQuanLy}");
        }
    }
}
