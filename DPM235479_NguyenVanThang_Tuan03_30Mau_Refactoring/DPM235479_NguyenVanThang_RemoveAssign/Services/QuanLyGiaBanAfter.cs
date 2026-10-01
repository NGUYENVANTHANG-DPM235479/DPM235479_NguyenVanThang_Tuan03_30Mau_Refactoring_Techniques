using System;

namespace DPM235479_NguyenVanThang_RemoveAssign.Services
{
    public class QuanLyGiaBanAfter
    {
        // SAU KHI REMOVE ASSIGNMENTS TO PARAMETERS
        // Khởi tạo một biến tạm 'ketQua' để lưu trữ giá trị của tham số, 
        // sau đó thực hiện các thao tác trên biến tạm này.
        // Tham số 'giaBanDau' được giữ nguyên giá trị nguyên thủy.
        public double TinhGiaChietKhauBanDau(double giaBanDau, int soLuong)
        {
            double giaSauChietKhau = giaBanDau;
            
            if (soLuong > 100)
            {
                giaSauChietKhau -= 5000;
            }
            if (soLuong > 500)
            {
                giaSauChietKhau -= 10000;
            }
            
            return giaSauChietKhau;
        }
    }
}
