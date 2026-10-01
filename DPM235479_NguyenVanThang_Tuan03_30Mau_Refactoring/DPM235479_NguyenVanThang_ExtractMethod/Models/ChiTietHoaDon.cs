using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_ExtractMethod.Models
{
    // Hàng hóa bán ra theo lô và ngày hết hạn thuộc Công ty Nông dược An Giang[cite: 9]
    public class ChiTietHoaDon
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string SoLo { get; set; }            // Xuất theo lô hàng[cite: 9]
        public DateTime NgayHetHan { get; set; }     // Hạn sử dụng của lô[cite: 9]
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public ChiTietHoaDon(string maSP, string tenSP, string soLo, DateTime ngayHetHan, int soLuong, double donGia)
        {
            MaSanPham = maSP;
            TenSanPham = tenSP;
            SoLo = soLo;
            NgayHetHan = ngayHetHan;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        public double TinhThanhTien()
        {
            return SoLuong * DonGia;
        }
    }
}
