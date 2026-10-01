using System;

namespace DPM235479_NguyenVanThang_ReplaceTypeClass.Services
{
    // THỰC TẾ:
    // Quản lý Phân hạng Đại Lý Phân Bón: Cấp 1, Cấp 2, Bán Lẻ.
    // Việc này liên quan tới chính sách chiết khấu. 
    // Rất không khôn ngoan nếu dùng int 1, 2, 3 làm Type Code.

    public class HangDaiLyClass
    {
        public string TenHang { get; private set; }
        public double ChietKhau { get; private set; }

        private HangDaiLyClass(string ten, double chietKhau)
        {
            TenHang = ten;
            ChietKhau = chietKhau;
        }

        public static readonly HangDaiLyClass Cap1 = new HangDaiLyClass("Đại Lý Cấp 1", 0.15); // 15%
        public static readonly HangDaiLyClass Cap2 = new HangDaiLyClass("Đại Lý Cấp 2", 0.08); // 8%
        public static readonly HangDaiLyClass BanLe = new HangDaiLyClass("Đại Lý Bán Lẻ", 0.02); // 2%
    }

    public class DoiTacReal
    {
        public string TenDoiTac { get; set; }
        // Type Safe
        public HangDaiLyClass HangCap { get; set; }

        public DoiTacReal(string ten, HangDaiLyClass hang)
        {
            TenDoiTac = ten;
            HangCap = hang;
        }

        public double TinhTien(double tienGoc)
        {
            return tienGoc - (tienGoc * HangCap.ChietKhau);
        }
    }

    public class QuanLyNhomMauReal
    {
        public void XulyDaiLy()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                 TÍNH TOÁN CHIẾT KHẤU ĐẠI LÝ (TYPE CLASS)            ");
            Console.WriteLine("=======================================================================");
            
            // Truyền Type an toàn, không sợ truyền số tào lao
            DoiTacReal dl1 = new DoiTacReal("Cửa Hàng Vật Tư Nông Nghiệp A", HangDaiLyClass.Cap1);
            DoiTacReal dl2 = new DoiTacReal("Tạp Hóa B", HangDaiLyClass.BanLe);

            double giaTriDonHang = 1000000; // 1 triệu

            Console.WriteLine($"Đơn hàng 1.000.000 VNĐ cho [{dl1.TenDoiTac}] ({dl1.HangCap.TenHang}):");
            Console.WriteLine($"=> Phải thanh toán: {dl1.TinhTien(giaTriDonHang):N0} VNĐ");
            
            Console.WriteLine("-----------------------------------------------------------------------");
            
            Console.WriteLine($"Đơn hàng 1.000.000 VNĐ cho [{dl2.TenDoiTac}] ({dl2.HangCap.TenHang}):");
            Console.WriteLine($"=> Phải thanh toán: {dl2.TinhTien(giaTriDonHang):N0} VNĐ");
            
            Console.WriteLine("=======================================================================");
        }
    }
}
