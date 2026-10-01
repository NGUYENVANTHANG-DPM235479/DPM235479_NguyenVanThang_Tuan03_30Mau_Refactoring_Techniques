using DPM235479_NguyenVanThang_InlineTemp.Models;
using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_InlineTemp.Services
{
    public class QuanLyKhoReal
    {
        public void KiemTraUuTienXuatKho(List<LoHangNongDuoc> danhSachLoHang)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                 BÁO CÁO ƯU TIÊN XUẤT KHO NÔNG DƯỢC                  ");
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"{"Mã Lô",-10} | {"Tên Thuốc",-15} | {"Số lượng",-10} | {"Ghi Chú",-20}");
            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (var lo in danhSachLoHang)
            {
                // ÁP DỤNG INLINE TEMP TRONG THỰC TẾ
                // Thay vì lưu biến tạm:
                // bool sapHetHan = lo.SapHetHan();
                // if (sapHetHan) ... 
                // Ta gọi trực tiếp hàm (Inline)
                
                string ghiChu = "Bình thường";
                
                if (lo.SapHetHan())
                {
                    ghiChu = "Sắp hết hạn -> Ưu tiên xuất kho (FIFO)";
                }
                
                // Inline temp cho biểu thức kiểm tra tồn kho
                if (lo.SoLuongTon <= 0)
                {
                    ghiChu = "Đã hết hàng";
                }

                Console.WriteLine($"{lo.MaLo,-10} | {lo.TenThuoc,-15} | {lo.SoLuongTon,-10} | {ghiChu,-20}");
            }
            Console.WriteLine("=======================================================================");
        }
    }
}
