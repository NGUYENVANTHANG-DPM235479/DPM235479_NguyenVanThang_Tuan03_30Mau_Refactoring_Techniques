using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ExtractVariab.Services
{
    public class QuanLyBanHangBefore
    {
        // TRƯỚC KHI EXTRACT VARIABLE
        // Biểu thức tính toán quá phức tạp và khó đọc
        public double TinhThanhTienHoaDon(int soLuong, double donGia, bool isKhachThanThiet, double khoangCach)
        {
            return (soLuong * donGia) - (isKhachThanThiet ? (soLuong * donGia) * 0.1 : 0) + (khoangCach > 50 ? khoangCach * 5000 : 0) + (((soLuong * donGia) - (isKhachThanThiet ? (soLuong * donGia) * 0.1 : 0)) * 0.08);
        }
        
        public bool KiemTraHoaDonGiaoXaVaLon(int soLuong, double donGia, double khoangCach)
        {
            if ((soLuong * donGia) > 10000000 && khoangCach > 100)
            {
                return true;
            }
            return false;
        }
    }
}
