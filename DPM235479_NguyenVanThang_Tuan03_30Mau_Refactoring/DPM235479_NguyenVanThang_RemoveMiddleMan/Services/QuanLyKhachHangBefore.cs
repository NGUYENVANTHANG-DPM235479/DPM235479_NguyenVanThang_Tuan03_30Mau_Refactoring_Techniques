using DPM235479_NguyenVanThang_RemoveMiddleMan.Models;
using System;

namespace DPM235479_NguyenVanThang_RemoveMiddleMan.Services
{
    // TRƯỚC KHI REMOVE MIDDLE MAN
    // Lớp KhachHangBefore đóng vai trò như một "Middle Man" (kẻ trung gian) không cần thiết.
    // Mọi yêu cầu lấy thông tin phí vận chuyển, đơn vị vận chuyển đều được Client gọi qua KhachHang,
    // rồi KhachHang lại gọi qua ChinhSachGiaoHang.
    // Nếu lớp ChinhSachGiaoHang thêm 10 thuộc tính, lớp KhachHangBefore cũng phải viết thêm 10 hàm Getter.

    public class KhachHangBefore
    {
        public string TenKhachHang { get; set; }
        private ChinhSachGiaoHang _chinhSach;

        public KhachHangBefore(string ten, ChinhSachGiaoHang chinhSach)
        {
            TenKhachHang = ten;
            _chinhSach = chinhSach;
        }

        // Những hàm Trung Gian vô ích
        public string LayDonViGiaoHang()
        {
            return _chinhSach.TenDonViGiaoHang;
        }

        public double LayPhiGiaoHang()
        {
            return _chinhSach.PhiVanChuyen;
        }

        public int LayThoiGianDuKien()
        {
            return _chinhSach.ThoiGianDuKienNgay;
        }
    }

    public class QuanLyKhachHangBefore
    {
        public void HienThiThongTinGiaoHang(KhachHangBefore kh)
        {
            // Client gọi qua các hàm trung gian
            Console.WriteLine($"Khách hàng: {kh.TenKhachHang}");
            Console.WriteLine($"Giao bởi: {kh.LayDonViGiaoHang()}");
            Console.WriteLine($"Phí: {kh.LayPhiGiaoHang()}");
        }
    }
}
