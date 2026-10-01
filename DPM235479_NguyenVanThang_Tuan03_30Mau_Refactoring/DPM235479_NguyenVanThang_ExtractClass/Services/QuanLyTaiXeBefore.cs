using System;

namespace DPM235479_NguyenVanThang_ExtractClass.Services
{
    // TRƯỚC KHI EXTRACT CLASS
    // Lớp NhanVienVanChuyenBefore ôm đồm quá nhiều trách nhiệm.
    // Nó vừa chứa thông tin của Tài xế (Tên, Bằng lái), 
    // lại vừa chứa thông tin của Chiếc xe tải (Biển số, Tải trọng, Hạn đăng kiểm).
    // => Vi phạm nguyên tắc Đơn trách nhiệm (Single Responsibility Principle).

    public class NhanVienVanChuyenBefore
    {
        // Thông tin tài xế
        public string TenNhanVien { get; set; }
        public string HangBangLai { get; set; }
        public string SoDienThoai { get; set; }

        // Thông tin phương tiện (Lẽ ra nên tách riêng)
        public string BienSoXe { get; set; }
        public double TrongTaiTon { get; set; }
        public DateTime HanDangKiem { get; set; }

        public string LayThongTinGiaoHang()
        {
            return $"Tài xế: {TenNhanVien} - Lái xe: {BienSoXe} ({TrongTaiTon} tấn)";
        }
    }
}
