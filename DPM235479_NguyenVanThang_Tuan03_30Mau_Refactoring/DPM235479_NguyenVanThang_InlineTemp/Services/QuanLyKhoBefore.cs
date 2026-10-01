using System;

namespace DPM235479_NguyenVanThang_InlineTemp.Services
{
    public class QuanLyKhoBefore
    {
        // TRƯỚC KHI INLINE TEMP
        // Biến 'soLuongDuoiMucQuyDinh' chỉ được gán một lần bằng biểu thức đơn giản
        // và được sử dụng ngay sau đó, không có mục đích nào khác.
        public bool KiemTraCanNhapThem(int soLuongTon)
        {
            bool soLuongDuoiMucQuyDinh = soLuongTon < 50;
            return soLuongDuoiMucQuyDinh;
        }

        public double TinhGiaTriTonKho(int soLuong, double donGia)
        {
            double tongGiaTri = soLuong * donGia;
            return tongGiaTri;
        }
    }
}
