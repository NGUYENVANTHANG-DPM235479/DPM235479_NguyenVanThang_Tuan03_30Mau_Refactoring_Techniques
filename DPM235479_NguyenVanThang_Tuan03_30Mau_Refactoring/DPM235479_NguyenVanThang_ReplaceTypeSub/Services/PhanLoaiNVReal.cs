using System;

namespace DPM235479_NguyenVanThang_ReplaceTypeSub.Services
{
    // THỰC TẾ:
    // Công ty Nông Dược có các gói Dịch vụ phun thuốc: Phun Bằng Drone, Phun Máy Xịt, Phun Thủ Công.
    // Mỗi loại có cách tính giá khác nhau. 
    // Dùng Subclass để chia loại dịch vụ (Đa hình).

    public abstract class DichVuPhunThuoc
    {
        public string ChuRuong { get; set; }
        public double DienTichHa { get; set; } // Hecta

        protected DichVuPhunThuoc(string chuRuong, double dienTich)
        {
            ChuRuong = chuRuong;
            DienTichHa = dienTich;
        }

        public abstract double TinhPhiDichVu();
        public abstract string TenDichVu();
    }

    public class PhunBangDrone : DichVuPhunThuoc
    {
        public PhunBangDrone(string chu, double dt) : base(chu, dt) { }
        public override double TinhPhiDichVu() => DienTichHa * 500000; // 500k/ha
        public override string TenDichVu() => "Phun bằng Drone DJI";
    }

    public class PhunThuCong : DichVuPhunThuoc
    {
        public PhunThuCong(string chu, double dt) : base(chu, dt) { }
        public override double TinhPhiDichVu() => DienTichHa * 300000; // 300k/ha
        public override string TenDichVu() => "Phun máy đeo lưng";
    }

    public class PhanLoaiNVReal
    {
        public void ChayChuongTrinh()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                TÍNH PHÍ DỊCH VỤ (REPLACE TYPE CODE WITH SUBCLASS)   ");
            Console.WriteLine("=======================================================================");
            
            // Tính đa hình (Polymorphism)
            DichVuPhunThuoc dv1 = new PhunBangDrone("Chú Ba Đời", 10.5);
            DichVuPhunThuoc dv2 = new PhunThuCong("Anh Tám", 2.0);

            Console.WriteLine($"Khách: {dv1.ChuRuong}");
            Console.WriteLine($"Dịch vụ: {dv1.TenDichVu()} | Diện tích: {dv1.DienTichHa} Ha");
            Console.WriteLine($"=> Phí thu: {dv1.TinhPhiDichVu():N0} VNĐ");
            
            Console.WriteLine("-----------------------------------------------------------------------");
            
            Console.WriteLine($"Khách: {dv2.ChuRuong}");
            Console.WriteLine($"Dịch vụ: {dv2.TenDichVu()} | Diện tích: {dv2.DienTichHa} Ha");
            Console.WriteLine($"=> Phí thu: {dv2.TinhPhiDichVu():N0} VNĐ");
            
            Console.WriteLine("=======================================================================");
        }
    }
}
