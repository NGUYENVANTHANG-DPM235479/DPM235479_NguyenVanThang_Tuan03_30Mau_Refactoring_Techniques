using System;

namespace DPM235479_NguyenVanThang_SplitTemporary.Services
{
    public class QuanLyGiaoHangAfter
    {
        // SAU KHI SPLIT TEMPORARY VARIABLE
        // Thay vì dùng chung biến 'temp', ta tách ra thành các biến riêng biệt có tên rõ ràng.
        // Điều này giúp code dễ đọc hơn và tránh lỗi logic ngầm.
        public void InThongTinKienHang(double dai, double rong)
        {
            double chuVi = 2 * (dai + rong);
            Console.WriteLine("Chu vi đáy kiện hàng: " + chuVi);

            double dienTich = dai * rong;
            Console.WriteLine("Diện tích đáy kiện hàng: " + dienTich);
        }
    }
}
