using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ExtractVariab.Services
{
    public class QuanLyBanHangAfter
    {
        // SAU KHI EXTRACT VARIABLE
        // Đưa các thành phần của biểu thức vào các biến được đặt tên rõ ràng
        public double TinhThanhTienHoaDon(int soLuong, double donGia, bool isKhachThanThiet, double khoangCach)
        {
            double tongTienHang = soLuong * donGia;
            double tienChietKhau = isKhachThanThiet ? tongTienHang * 0.1 : 0;
            double phiVanChuyen = khoangCach > 50 ? khoangCach * 5000 : 0;
            
            double doanhThuSauChietKhau = tongTienHang - tienChietKhau;
            double thueVAT = doanhThuSauChietKhau * 0.08;
            
            return doanhThuSauChietKhau + phiVanChuyen + thueVAT;
        }
        
        public bool KiemTraHoaDonGiaoXaVaLon(int soLuong, double donGia, double khoangCach)
        {
            bool laDonHangLon = (soLuong * donGia) > 10000000;
            bool laGiaoHangXa = khoangCach > 100;
            
            if (laDonHangLon && laGiaoHangXa)
            {
                return true;
            }
            return false;
        }
    }
}
