using DPM235479_NguyenVanThang_ChangeBiToUni.Models;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeBiToUni.Services
{
    // TRƯỚC KHI CHANGE BIDIRECTIONAL TO UNIDIRECTIONAL
    // Lớp DonHang và KhachHang có liên kết 2 chiều (Bidirectional) với nhau.
    // Điều này tạo ra "sự phụ thuộc vòng" (Circular Dependency), gây khó khăn 
    // trong việc giải phóng bộ nhớ (Garbage Collection) và tái sử dụng code.
    // Thường thì Khách Hàng chỉ cần biết họ có Đơn Hàng nào, chứ Đơn Hàng không cần lưu trực tiếp Khách Hàng.

    public class DonHangBefore
    {
        public string MaDon { get; set; }
        
        // Đơn hàng trỏ ngược lại Khách Hàng (Tạo liên kết 2 chiều không cần thiết)
        public KhachHangBefore KhachHangSohuu { get; set; }

        public DonHangBefore(string ma)
        {
            MaDon = ma;
        }
    }

    public class KhachHangBefore
    {
        public string TenKhachHang { get; set; }
        public List<DonHangBefore> DanhSachDon { get; set; }

        public KhachHangBefore(string ten)
        {
            TenKhachHang = ten;
            DanhSachDon = new List<DonHangBefore>();
        }

        public void MuaHang(DonHangBefore don)
        {
            DanhSachDon.Add(don);
            don.KhachHangSohuu = this; // Đơn Hàng tự chọc ngược lại Khách
        }
    }
}
