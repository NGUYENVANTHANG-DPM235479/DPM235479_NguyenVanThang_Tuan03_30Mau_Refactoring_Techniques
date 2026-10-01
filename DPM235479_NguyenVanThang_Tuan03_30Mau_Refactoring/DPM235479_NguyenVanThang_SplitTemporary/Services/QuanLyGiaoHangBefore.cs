using System;

namespace DPM235479_NguyenVanThang_SplitTemporary.Services
{
    public class QuanLyGiaoHangBefore
    {
        // TRƯỚC KHI SPLIT TEMPORARY VARIABLE
        // Biến 'temp' được dùng đi dùng lại cho nhiều mục đích khác nhau:
        // Lần 1: Dùng làm Chu vi đáy
        // Lần 2: Dùng làm Diện tích
        public void InThongTinKienHang(double dai, double rong)
        {
            double temp = 2 * (dai + rong);
            Console.WriteLine("Chu vi đáy kiện hàng: " + temp);

            temp = dai * rong;
            Console.WriteLine("Diện tích đáy kiện hàng: " + temp);
        }
    }
}
