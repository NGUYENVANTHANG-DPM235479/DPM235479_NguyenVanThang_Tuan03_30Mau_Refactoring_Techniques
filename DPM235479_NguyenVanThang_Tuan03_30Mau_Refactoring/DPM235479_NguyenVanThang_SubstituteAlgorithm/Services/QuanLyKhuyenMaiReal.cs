using DPM235479_NguyenVanThang_SubstituteAlgorithm.Models;
using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_SubstituteAlgorithm.Services
{
    public class QuanLyKhuyenMaiReal
    {
        // THỰC TẾ: Tìm mức chiết khấu áp dụng cho các đại lý dựa trên Hạng Đại Lý
        // Thuật toán phức tạp cũ sử dụng vòng lặp và if lồng nhau được thay bằng LINQ và Dictionary
        
        public void HienThiChinhSachDaiLy(string hangDaiLy)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                 CHÍNH SÁCH CHIẾT KHẤU ĐẠI LÝ LÚA GẠO                ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Đang xét hạng: {hangDaiLy}");
            
            // SUBSTITUTE ALGORITHM: Sử dụng Dictionary thay vì switch-case/if-else dài
            var chinhSachChietKhau = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Kim Cương", 0.15 }, // 15%
                { "Vàng", 0.10 },      // 10%
                { "Bạc", 0.07 },       // 7%
                { "Đồng", 0.03 }       // 3%
            };

            double phanTram = 0;
            if (chinhSachChietKhau.ContainsKey(hangDaiLy))
            {
                phanTram = chinhSachChietKhau[hangDaiLy];
                Console.WriteLine($"-> Đại lý hạng {hangDaiLy} được hưởng chiết khấu: {phanTram * 100}% trên tổng hóa đơn.");
            }
            else
            {
                Console.WriteLine("-> Hạng đại lý không hợp lệ hoặc chưa có chính sách áp dụng.");
            }
            Console.WriteLine("=======================================================================");
        }
    }
}
