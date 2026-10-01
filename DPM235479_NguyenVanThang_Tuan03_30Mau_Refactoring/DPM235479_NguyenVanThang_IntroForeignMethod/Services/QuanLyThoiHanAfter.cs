using DPM235479_NguyenVanThang_IntroForeignMethod.Models;
using System;

namespace DPM235479_NguyenVanThang_IntroForeignMethod.Services
{
    // SAU KHI INTRODUCE FOREIGN METHOD
    // Vì không thể chọc vào thư viện gốc của Microsoft (DateTime) để thêm hàm,
    // ta tự giới thiệu (Introduce) một "phương thức ngoại lai" (Foreign Method) 
    // bên trong lớp của chính chúng ta. Phương thức này sẽ nhận đối tượng DateTime làm tham số.

    public class QuanLyThoiHanAfter
    {
        public void KiemTraHanSuDung(ChungTuNhapKho chungTu)
        {
            // Code bây giờ rất ngắn gọn và rõ nghĩa, không cần viết lại công thức nữa
            DateTime ngayHetHan = TinhNgayHetHanPhanBon(chungTu.NgaySanXuat);
            
            Console.WriteLine($"Lô phân bón này sẽ hết hạn vào: {ngayHetHan.ToString("dd/MM/yyyy")}");
        }

        // INTRODUCE FOREIGN METHOD: Ta viết thêm một hàm riêng để hỗ trợ cho DateTime
        // Hàm này đóng vai trò như một hàm tiện ích mở rộng
        private static DateTime TinhNgayHetHanPhanBon(DateTime ngaySX)
        {
            // Logic có thể dùng hàm có sẵn AddYears để xử lý chính xác hơn cả năm nhuận
            return ngaySX.AddYears(2);
        }
    }
}
