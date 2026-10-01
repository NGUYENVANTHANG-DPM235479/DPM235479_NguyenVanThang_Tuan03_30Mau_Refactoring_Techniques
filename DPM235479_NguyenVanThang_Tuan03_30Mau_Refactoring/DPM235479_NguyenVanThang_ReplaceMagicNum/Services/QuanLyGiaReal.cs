using System;

namespace DPM235479_NguyenVanThang_ReplaceMagicNum.Services
{
    // THỰC TẾ:
    // Tính toán giới hạn tồn kho Thuốc Trừ Sâu An Giang.
    // Quy định nhà nước: Tồn kho hóa chất độc hại tối đa 5000 lít, tồn kho cảnh báo ở mức 4000 lít.
    // Thay vì rải số 5000 và 4000 khắp code, ta dùng Hằng số.

    public class QuanLyKhoNongDuocReal
    {
        // Symbolic Constants
        public const int GIOI_HAN_TON_KHO_TOI_DA = 5000;
        public const int MUC_CANH_BAO_TON_KHO = 4000;

        public string TenKho { get; set; }
        public int TonKhoHienTai { get; set; } // Tính bằng lít

        public QuanLyKhoNongDuocReal(string ten)
        {
            TenKho = ten;
            TonKhoHienTai = 0;
        }

        public void NhapKho(int soLuong)
        {
            if (TonKhoHienTai + soLuong > GIOI_HAN_TON_KHO_TOI_DA)
            {
                Console.WriteLine($"=> [LỖI] Nhập {soLuong} lít sẽ vượt quá ngưỡng {GIOI_HAN_TON_KHO_TOI_DA} lít cho phép của Nhà nước!");
                return;
            }

            TonKhoHienTai += soLuong;
            Console.WriteLine($"Đã nhập {soLuong} lít. Tồn kho: {TonKhoHienTai} lít.");

            if (TonKhoHienTai >= MUC_CANH_BAO_TON_KHO)
            {
                Console.WriteLine($"=> [CẢNH BÁO MÀU CAM] Kho đã chạm mức {MUC_CANH_BAO_TON_KHO} lít, sắp đầy!");
            }
        }
    }

    public class QuanLyGiaReal
    {
        public void KiemTraKho()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                KIỂM TRA TỒN KHO HÓA CHẤT ĐỘC HẠI                    ");
            Console.WriteLine("=======================================================================");
            
            QuanLyKhoNongDuocReal kho = new QuanLyKhoNongDuocReal("Kho thuốc diệt cỏ - Khu A");
            
            kho.NhapKho(3000);
            kho.NhapKho(1500); // Đạt 4500 -> Báo động cam
            
            Console.WriteLine("-----------------------------------------------------------------------");
            
            kho.NhapKho(1000); // Vượt 5000 -> Lỗi

            Console.WriteLine("=======================================================================");
        }
    }
}
