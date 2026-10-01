using DPM235479_NguyenVanThang_IntroForeignMethod.Models;
using System;

namespace DPM235479_NguyenVanThang_IntroForeignMethod.Services
{
    // TRƯỚC KHI INTRODUCE FOREIGN METHOD
    // Ta sử dụng struct DateTime có sẵn của thư viện .NET (một lớp tiện ích).
    // Giả sử ta muốn tính "Ngày Hết Hạn Phân Bón" (hạn sử dụng là 2 năm tính từ ngày sản xuất).
    // Thư viện DateTime không hề có sẵn hàm TinhNgayHetHanPhanBon().
    // Lập trình viên phải tự viết công thức tính toán trực tiếp mỗi khi dùng, gây lặp code và rườm rà.

    public class QuanLyThoiHanBefore
    {
        public void KiemTraHanSuDung(ChungTuNhapKho chungTu)
        {
            // Tính hạn sử dụng 2 năm, nhưng phải viết thủ công logic cộng dồn năm, tháng, ngày
            // (Đoạn code này có thể lặp lại ở 10 chỗ khác nhau trong hệ thống)
            DateTime ngaySanXuat = chungTu.NgaySanXuat;
            DateTime ngayHetHan = new DateTime(ngaySanXuat.Year + 2, ngaySanXuat.Month, ngaySanXuat.Day);
            
            Console.WriteLine($"Lô phân bón này sẽ hết hạn vào: {ngayHetHan.ToString("dd/MM/yyyy")}");
        }
    }
}
