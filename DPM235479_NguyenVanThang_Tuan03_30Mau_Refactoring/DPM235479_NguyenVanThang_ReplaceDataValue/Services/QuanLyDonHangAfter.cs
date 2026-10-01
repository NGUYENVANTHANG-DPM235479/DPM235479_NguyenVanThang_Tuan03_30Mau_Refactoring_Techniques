using DPM235479_NguyenVanThang_ReplaceDataValue.Models;
using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ReplaceDataValue.Services
{
    // SAU KHI REPLACE DATA VALUE WITH OBJECT
    // Biến kiểu string 'TenDaiLy' được NÂNG CẤP thành hẳn một Object 'KhachHangDaiLy'.
    // Nhờ đó, Khách hàng bây giờ có thể tự chứa thêm Mã Khách, Hạng Khách... 
    // mà không làm phá vỡ cấu trúc của Đơn Hàng.

    public class KhachHangDaiLy
    {
        public string TenDaiLy { get; set; }
        public string MaKhachHang { get; set; } // Thuộc tính bổ sung thêm rất dễ dàng

        public KhachHangDaiLy(string tenDaiLy, string maKhach)
        {
            TenDaiLy = tenDaiLy;
            MaKhachHang = maKhach;
        }
    }

    public class DonHangAfter
    {
        // Thay thế string bằng Object
        public KhachHangDaiLy DaiLy { get; set; }
        public List<ThongTinPhanBon> DanhSachPhanBon { get; set; }

        public DonHangAfter(KhachHangDaiLy daiLy)
        {
            DaiLy = daiLy;
            DanhSachPhanBon = new List<ThongTinPhanBon>();
        }

        public int DemSoDonHangCuaKhach(List<DonHangAfter> cacDonHang, KhachHangDaiLy khachCanTim)
        {
            int count = 0;
            foreach (var dh in cacDonHang)
            {
                // So sánh bằng Mã Khách Hàng chuyên nghiệp và chính xác hơn nhiều
                if (dh.DaiLy.MaKhachHang == khachCanTim.MaKhachHang)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
