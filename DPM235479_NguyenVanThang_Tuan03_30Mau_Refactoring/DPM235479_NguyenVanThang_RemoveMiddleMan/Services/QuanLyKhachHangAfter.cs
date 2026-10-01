using DPM235479_NguyenVanThang_RemoveMiddleMan.Models;
using System;

namespace DPM235479_NguyenVanThang_RemoveMiddleMan.Services
{
    // SAU KHI REMOVE MIDDLE MAN
    // Xóa sạch các hàm Trung Gian trong lớp KhachHangAfter.
    // Thay vào đó, tạo một Property công khai (hoặc Getter) để Client có thể
    // trực tiếp lấy đối tượng ChinhSachGiaoHang và làm việc với nó.

    public class KhachHangAfter
    {
        public string TenKhachHang { get; set; }
        public ChinhSachGiaoHang ChinhSachVanChuyen { get; set; } // Cho phép Client truy cập trực tiếp

        public KhachHangAfter(string ten, ChinhSachGiaoHang chinhSach)
        {
            TenKhachHang = ten;
            ChinhSachVanChuyen = chinhSach;
        }
    }

    public class QuanLyKhachHangAfter
    {
        public void HienThiThongTinGiaoHang(KhachHangAfter kh)
        {
            // Client lấy trực tiếp đối tượng chính sách và sử dụng
            // Không cần Khách Hàng phải viết hàm trung gian rườm rà nữa
            ChinhSachGiaoHang chinhSach = kh.ChinhSachVanChuyen;
            
            Console.WriteLine($"Khách hàng: {kh.TenKhachHang}");
            Console.WriteLine($"Giao bởi: {chinhSach.TenDonViGiaoHang}");
            Console.WriteLine($"Phí: {chinhSach.PhiVanChuyen}");
            Console.WriteLine($"Thời gian: {chinhSach.ThoiGianDuKienNgay} ngày");
        }
    }
}
