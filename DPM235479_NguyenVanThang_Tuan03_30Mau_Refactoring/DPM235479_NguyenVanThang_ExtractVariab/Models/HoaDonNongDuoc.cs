using System;

namespace DPM235479_NguyenVanThang_ExtractVariab.Models
{
    public class HoaDonNongDuoc
    {
        public string MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenNhanVien { get; set; }
        public double DonGiaPhanBon { get; set; }
        public int SoLuong { get; set; }
        public bool KhachHangNongDanThanThiet { get; set; }
        public double KhoangCachGiaoHangKm { get; set; }
        public string LoaiSanPhan { get; set; }
    }
}
