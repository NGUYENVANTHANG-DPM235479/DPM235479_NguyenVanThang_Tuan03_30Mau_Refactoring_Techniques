using DPM235479_NguyenVanThang_ReplaceTemp.Models;
using System;

namespace DPM235479_NguyenVanThang_ReplaceTemp.Services
{
    public class QuanLyGiaReal
    {
        private DonHangSi _donHang;

        public QuanLyGiaReal(DonHangSi donHang)
        {
            _donHang = donHang;
        }

        // THỰC TẾ: Tách các biến tạm tính toán thành các Query Method (hàm truy vấn)
        // để logic rõ ràng hơn và dễ bảo trì, dễ viết Test sau này.

        public void InThongTinThanhToan()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                       THANH TOÁN ĐƠN HÀNG SỈ                        ");
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"Mã đơn: {_donHang.MaDonHang} | Đại lý: {_donHang.TenDaiLy}");
            
            // Sử dụng trực tiếp Query method thay vì dùng biến tạm
            Console.WriteLine($"Tổng tiền hàng trước chiết khấu: {TinhGiaGoc():N0} VNĐ");
            Console.WriteLine($"Tỉ lệ chiết khấu: {TinhTiLeChietKhau() * 100}%");
            Console.WriteLine($"Số tiền chiết khấu: {TinhGiaGoc() * TinhTiLeChietKhau():N0} VNĐ");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"TỔNG PHẢI THANH TOÁN: {TinhTongThanhToan():N0} VNĐ");
            Console.WriteLine("=======================================================================");
        }

        // Query Method 1: Tính giá gốc (Base Price)
        private double TinhGiaGoc()
        {
            return _donHang.SoLuongChai * _donHang.DonGia;
        }

        // Query Method 2: Tính tỉ lệ chiết khấu (Discount Factor)
        private double TinhTiLeChietKhau()
        {
            if (TinhGiaGoc() >= 100000000) return 0.15; // > 100tr giảm 15%
            if (TinhGiaGoc() >= 50000000) return 0.10;  // > 50tr giảm 10%
            return 0.05;                               // Mặc định giảm 5%
        }

        // Query Method 3: Tính tổng cuối cùng
        private double TinhTongThanhToan()
        {
            return TinhGiaGoc() - (TinhGiaGoc() * TinhTiLeChietKhau());
        }
    }
}
