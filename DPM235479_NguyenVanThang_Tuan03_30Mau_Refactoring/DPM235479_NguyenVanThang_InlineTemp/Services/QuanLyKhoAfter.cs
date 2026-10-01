using System;

namespace DPM235479_NguyenVanThang_InlineTemp.Services
{
    public class QuanLyKhoAfter
    {
        // SAU KHI INLINE TEMP
        // Bỏ các biến tạm không cần thiết, trả về trực tiếp kết quả của biểu thức
        public bool KiemTraCanNhapThem(int soLuongTon)
        {
            return soLuongTon < 50;
        }

        public double TinhGiaTriTonKho(int soLuong, double donGia)
        {
            return soLuong * donGia;
        }
    }
}
