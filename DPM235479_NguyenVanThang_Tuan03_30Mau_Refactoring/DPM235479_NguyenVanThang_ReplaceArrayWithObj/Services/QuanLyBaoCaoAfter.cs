using System;

namespace DPM235479_NguyenVanThang_ReplaceArrayWithObj.Services
{
    // SAU KHI REPLACE ARRAY WITH OBJECT
    // Mảng (Array) tối nghĩa kia đã được biến thành hẳn một class 'ThongTinBanHang' (Object).
    // Giờ đây mỗi phần tử không còn là index [0], [1] nữa,
    // mà có tên đàng hoàng: TenNhanVien, SoLuongBan, ChiNhanh. Dữ liệu cũng được đúng kiểu (int, string).

    // TẠO OBJECT THAY THẾ CHO ARRAY
    public class ThongTinBanHang
    {
        public string TenNhanVien { get; set; }
        public int SoLuongBan { get; set; }     // Dùng đúng kiểu số nguyên
        public string ChiNhanh { get; set; }
    }

    public class QuanLyBaoCaoAfter
    {
        public void InThongKeBanHang()
        {
            // Thay vì dùng string[], ta dùng trực tiếp Object
            ThongTinBanHang baoCao = new ThongTinBanHang
            {
                TenNhanVien = "Nguyễn Văn A",
                SoLuongBan = 150,
                ChiNhanh = "Nông Dược VN"
            };

            // Code đọc dữ liệu giờ cực kỳ trong sáng và dễ hiểu
            Console.WriteLine($"Nhân viên {baoCao.TenNhanVien} ({baoCao.ChiNhanh}) đã bán {baoCao.SoLuongBan} sản phẩm.");
        }
    }
}
