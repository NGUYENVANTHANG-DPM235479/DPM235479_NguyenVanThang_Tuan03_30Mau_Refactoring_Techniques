using DPM235479_NguyenVanThang_EncapsulateCol.Models;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_EncapsulateCol.Services
{
    // TRƯỚC KHI ENCAPSULATE COLLECTION
    // Ta có một danh sách (Collection) public là DanhSachDonHang.
    // Lớp bên ngoài (Client) có thể lấy List này ra và tự do dùng hàm .Add(), .Remove(), .Clear()...
    // Điều này cực kỳ nguy hiểm, vì Class cha không hề kiểm soát được ai đang thêm bớt dữ liệu của mình.

    public class DaiLyBefore
    {
        public string TenDaiLy { get; set; }
        
        // Collection bị lộ ra ngoài một cách vô tội vạ
        public List<DonHang> DanhSachDonHang { get; set; }

        public DaiLyBefore(string ten)
        {
            TenDaiLy = ten;
            DanhSachDonHang = new List<DonHang>();
        }
    }

    public class QuanLyGioHangBefore
    {
        public void XyLyDonHang(DaiLyBefore daiLy)
        {
            // Client tự ý lôi Collection ra xài
            daiLy.DanhSachDonHang.Add(new DonHang("DH01", 500000));
            daiLy.DanhSachDonHang.Add(new DonHang("DH02", 700000));
            
            // Lỡ có một ông code lỗi, ông ấy viết dòng này là xóa sạch dữ liệu công ty:
            // daiLy.DanhSachDonHang.Clear(); 
        }
    }
}
