using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DPM235479_NguyenVanThang_EncapsulateCol.Services
{
    // THỰC TẾ:
    // Quản lý Phiếu Xuất Kho cho xe tải chở Phân Bón.
    // Xe tải chỉ được phép chở TỐI ĐA 5 TẤN (5000 kg).
    // Nếu để lộ List<PhieuXuat> ra ngoài, người ta có thể Add 100 cái phiếu vô làm quá tải xe.
    // Phải Encapsulate Collection để chặn ở hàm ThemPhieu().

    public class PhieuXuatKho
    {
        public string MaPhieu { get; set; }
        public double KhoiLuongKg { get; set; }

        public PhieuXuatKho(string ma, double kg)
        {
            MaPhieu = ma;
            KhoiLuongKg = kg;
        }
    }

    public class ChuyenXeTaiReal
    {
        public string BienSoXe { get; set; }
        private const double TAI_TRONG_TOI_DA = 5000; // kg
        
        // PRIVATE LIST
        private List<PhieuXuatKho> _danhSachPhieu;
        private double _tongKhoiLuongHienTai = 0;

        public ChuyenXeTaiReal(string bienSo)
        {
            BienSoXe = bienSo;
            _danhSachPhieu = new List<PhieuXuatKho>();
        }

        // ENCAPSULATE COLLECTION
        public ReadOnlyCollection<PhieuXuatKho> DanhSachPhieu => _danhSachPhieu.AsReadOnly();

        public void ThemPhieuXuat(PhieuXuatKho phieu)
        {
            if (_tongKhoiLuongHienTai + phieu.KhoiLuongKg > TAI_TRONG_TOI_DA)
            {
                Console.WriteLine($"=> [CẢNH BÁO QUÁ TẢI] Xe {BienSoXe} từ chối nhận phiếu {phieu.MaPhieu}. Tổng trọng lượng sẽ vượt 5 Tấn!");
                return;
            }

            _danhSachPhieu.Add(phieu);
            _tongKhoiLuongHienTai += phieu.KhoiLuongKg;
            Console.WriteLine($"[ĐÃ NHẬN] Xe {BienSoXe} nhận phiếu {phieu.MaPhieu} ({phieu.KhoiLuongKg} kg). Tổng tải: {_tongKhoiLuongHienTai}/{TAI_TRONG_TOI_DA} kg.");
        }
    }

    public class QuanLyGioHangReal
    {
        public void ChatHangLenXe()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                    QUẢN LÝ CHUYẾN XE (BẢO VỆ COLLECTION)            ");
            Console.WriteLine("=======================================================================");
            
            ChuyenXeTaiReal xeTai = new ChuyenXeTaiReal("67A-123.45");

            // Xe tải được bảo vệ, Client không thể xeTai.DanhSachPhieu.Add(...) được
            // Mà phải đi qua trạm kiểm duyệt của hàm ThemPhieuXuat
            
            xeTai.ThemPhieuXuat(new PhieuXuatKho("PX-01", 2000)); // Hợp lệ
            xeTai.ThemPhieuXuat(new PhieuXuatKho("PX-02", 2500)); // Hợp lệ, tổng = 4500
            
            Console.WriteLine("-----------------------------------------------------------------------");
            
            // Cố tình nhồi thêm phiếu 1000kg (Sẽ bị chặn do quá tải 5 tấn)
            xeTai.ThemPhieuXuat(new PhieuXuatKho("PX-03", 1000)); 
            
            Console.WriteLine("=======================================================================");
        }
    }
}
