using System;

namespace DPM235479_NguyenVanThang_ExtractClass.Services
{
    // SAU KHI EXTRACT CLASS
    // Tách các trường dữ liệu và phương thức liên quan đến chiếc xe 
    // sang một lớp mới là XeTaiVanChuyen.
    // Lớp NhanVienVanChuyenAfter bây giờ trở nên gọn gàng và đúng nghĩa hơn.

    public class XeTaiVanChuyen
    {
        public string BienSoXe { get; set; }
        public double TrongTaiTon { get; set; }
        public DateTime HanDangKiem { get; set; }

        public string LayThongTinXe()
        {
            return $"{BienSoXe} ({TrongTaiTon} tấn)";
        }
    }

    public class NhanVienVanChuyenAfter
    {
        // Thông tin tài xế
        public string TenNhanVien { get; set; }
        public string HangBangLai { get; set; }
        public string SoDienThoai { get; set; }

        // Liên kết tới lớp vừa được Extract ra
        public XeTaiVanChuyen XeChuyenCho { get; set; }

        public string LayThongTinGiaoHang()
        {
            return $"Tài xế: {TenNhanVien} - Lái xe: {XeChuyenCho.LayThongTinXe()}";
        }
    }
}
