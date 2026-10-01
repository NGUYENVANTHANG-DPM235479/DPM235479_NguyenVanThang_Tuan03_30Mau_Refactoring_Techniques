using DPM235479_NguyenVanThang_ChangeBiToUni.Models;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeBiToUni.Services
{
    // SAU KHI CHANGE BIDIRECTIONAL TO UNIDIRECTIONAL
    // Xóa bỏ liên kết từ Đơn Hàng trỏ ngược về Khách Hàng.
    // Lớp Đơn Hàng giờ hoàn toàn ĐỘC LẬP (Independent), có thể tái sử dụng dễ dàng.
    // Liên kết chỉ còn 1 chiều: Khách Hàng -> Đơn Hàng.

    public class DonHangAfter
    {
        public string MaDon { get; set; }
        
        // ĐÃ XÓA BIẾN KhachHangSohuu. 
        // Lớp này giờ rất "nhẹ" và không phụ thuộc ai.

        public DonHangAfter(string ma)
        {
            MaDon = ma;
        }
    }

    public class KhachHangAfter
    {
        public string TenKhachHang { get; set; }
        // Liên kết 1 chiều duy nhất
        public List<DonHangAfter> DanhSachDon { get; set; } 

        public KhachHangAfter(string ten)
        {
            TenKhachHang = ten;
            DanhSachDon = new List<DonHangAfter>();
        }

        public void MuaHang(DonHangAfter don)
        {
            // Chỉ Khách hàng giữ Đơn Hàng, Đơn Hàng không thèm biết Khách là ai
            DanhSachDon.Add(don); 
        }
    }
}
