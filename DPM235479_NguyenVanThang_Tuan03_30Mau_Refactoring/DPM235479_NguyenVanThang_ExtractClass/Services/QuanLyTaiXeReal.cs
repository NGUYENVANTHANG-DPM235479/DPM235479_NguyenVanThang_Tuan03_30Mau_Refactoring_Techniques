using System;

namespace DPM235479_NguyenVanThang_ExtractClass.Services
{
    // THỰC TẾ: Trong dự án Nông Dược An Giang, hệ thống Logistic cần tính phí vận tải.
    // Việc tách lớp (Extract Class) giúp quản lý riêng rẽ phí bảo trì xe tải 
    // và lương của tài xế một cách chuyên nghiệp.

    // Class được tách ra (Extracted Class)
    public class PhuongTienLogistic
    {
        public string BienSo { get; set; }
        public double MucTieuHaoNhienLieu { get; set; } // lít/100km
        
        public PhuongTienLogistic(string bienSo, double mucTieuHao)
        {
            BienSo = bienSo;
            MucTieuHaoNhienLieu = mucTieuHao;
        }

        public double TinhChiPhiXangXe(double quangDuongKm, double giaXangLit)
        {
            return (quangDuongKm / 100.0) * MucTieuHaoNhienLieu * giaXangLit;
        }
    }

    // Class chính (sau khi được dọn dẹp)
    public class TaiXeNongDuocReal
    {
        public string TenTaiXe { get; set; }
        public PhuongTienLogistic XeTai { get; set; } // Delegate tới class mới

        public TaiXeNongDuocReal(string tenTaiXe, PhuongTienLogistic xeTai)
        {
            TenTaiXe = tenTaiXe;
            XeTai = xeTai;
        }

        public void InLenhDieuDong(double quangDuongGiaoHang)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                         LỆNH ĐIỀU ĐỘNG XE TẢI                       ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Người lái: {TenTaiXe}");
            Console.WriteLine($"Phương tiện nhận phân công: {XeTai.BienSo}");
            Console.WriteLine($"Quãng đường cần giao: {quangDuongGiaoHang} km");
            
            // Tính phí bằng class phương tiện
            double giaDauDiezel = 20500; // VNĐ/lít
            double phiXangXe = XeTai.TinhChiPhiXangXe(quangDuongGiaoHang, giaDauDiezel);
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"DỰ TOÁN PHÍ NHIÊN LIỆU CHO CHUYẾN ĐI: {phiXangXe:N0} VNĐ");
            Console.WriteLine("=======================================================================");
        }
    }
}
