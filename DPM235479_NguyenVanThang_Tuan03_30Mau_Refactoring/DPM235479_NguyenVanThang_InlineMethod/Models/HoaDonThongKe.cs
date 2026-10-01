using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_InlineMethod.Models
{
    public class HoaDonThongKe
    {
        public string MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNhanVien { get; set; }          // Nhân viên thực hiện giao dịch[cite: 9]
        public string TenNhanVien { get; set; }
        public double TongTienHang { get; set; }
        public double TienGiamGia { get; set; }         // Giảm giá / Khuyến mãi[cite: 9]
        public double ChiPhiVanChuyen { get; set; }     // Phí vận chuyển[cite: 9]
        public double ChiPhiDichVuPhu { get; set; }     // Dịch vụ phụ[cite: 9]

        public HoaDonThongKe(string maHD, DateTime ngayLap, string maNV, string tenNV, double tongHang, double giamGia, double vanChuyen, double dichVu)
        {
            MaHoaDon = maHD;
            NgayLap = ngayLap;
            MaNhanVien = maNV;
            TenNhanVien = tenNV;
            TongTienHang = tongHang;
            TienGiamGia = giamGia;
            ChiPhiVanChuyen = vanChuyen;
            ChiPhiDichVuPhu = dichVu;
        }

        public double TinhThucThu()
        {
            return TongTienHang - TienGiamGia + ChiPhiVanChuyen + ChiPhiDichVuPhu;
        }
    }
}
