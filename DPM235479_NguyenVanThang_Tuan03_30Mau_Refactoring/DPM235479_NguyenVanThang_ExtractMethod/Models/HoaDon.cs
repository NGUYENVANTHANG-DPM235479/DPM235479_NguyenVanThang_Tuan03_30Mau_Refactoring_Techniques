using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_ExtractMethod.Models
{
    public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNhanVien { get; set; }          // Nhân viên bán hàng đăng nhập[cite: 10]
        public double TyLeChietKhau { get; set; }      // Tỷ lệ giảm giá/chiết khấu[cite: 9]
        public double ChiPhiVanChuyen { get; set; }    // Chi phí vận chuyển[cite: 9]
        public double ChiPhiDichVuPhu { get; set; }    // Dịch vụ phụ phát sinh[cite: 9]
        public List<ChiTietHoaDon> DanhSachChiTiet { get; set; } = new List<ChiTietHoaDon>();

        public HoaDon(string maHD, string tenKH, DateTime ngayLap, string maNV, double chietKhau, double vanChuyen, double dichVuPhu)
        {
            MaHoaDon = maHD;
            TenKhachHang = tenKH;
            NgayLap = ngayLap;
            MaNhanVien = maNV;
            TyLeChietKhau = chietKhau;
            ChiPhiVanChuyen = vanChuyen;
            ChiPhiDichVuPhu = dichVuPhu;
        }
    }
}
