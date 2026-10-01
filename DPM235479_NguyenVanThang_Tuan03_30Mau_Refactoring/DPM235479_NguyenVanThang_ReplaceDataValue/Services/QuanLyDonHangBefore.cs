using DPM235479_NguyenVanThang_ReplaceDataValue.Models;
using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ReplaceDataValue.Services
{
    // TRƯỚC KHI REPLACE DATA VALUE WITH OBJECT
    // Lớp DonHang lưu thông tin Khách Hàng (Tên Đại Lý) chỉ bằng một biến chuỗi (string) đơn giản.
    // Lúc đầu thì chỉ cần Tên là đủ, nhưng sau này dự án phình to, ta cần lưu thêm: 
    // Mã đại lý, Cấp độ đại lý (VIP/Thường), Hạn mức nợ...
    // Việc chỉ dùng biến kiểu string cho "Khách hàng" không còn đáp ứng được nữa.

    public class DonHangBefore
    {
        // Vấn đề nằm ở đây: Khách hàng chỉ là một giá trị chuỗi (Data Value)
        public string TenDaiLy { get; set; }
        public List<ThongTinPhanBon> DanhSachPhanBon { get; set; }

        public DonHangBefore(string tenDaiLy)
        {
            TenDaiLy = tenDaiLy;
            DanhSachPhanBon = new List<ThongTinPhanBon>();
        }

        public int DemSoKhachHangTrungTen(List<DonHangBefore> cacDonHang, string tenCanTim)
        {
            int count = 0;
            foreach (var dh in cacDonHang)
            {
                // So sánh chuỗi thủ công, rất dễ sai sót nếu viết hoa viết thường
                if (dh.TenDaiLy == tenCanTim)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
