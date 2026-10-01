using System;

namespace DPM235479_NguyenVanThang_RemoveAssign.Services
{
    public class QuanLyGiaBanBefore
    {
        // TRƯỚC KHI REMOVE ASSIGNMENTS TO PARAMETERS
        // Tham số 'giaBanDau' bị gán lại (thay đổi giá trị) trực tiếp trong hàm.
        // Điều này làm mất giá trị gốc truyền vào và gây khó hiểu cho người đọc code,
        // đặc biệt khi hàm dài và phức tạp.
        public double TinhGiaChietKhauBanDau(double giaBanDau, int soLuong)
        {
            if (soLuong > 100)
            {
                giaBanDau -= 5000; // Thay đổi trực tiếp tham số
            }
            if (soLuong > 500)
            {
                giaBanDau -= 10000;
            }
            
            return giaBanDau;
        }
    }
}
