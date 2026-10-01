using DPM235479_NguyenVanThang_MoveMethod.Models;
using System;

namespace DPM235479_NguyenVanThang_MoveMethod.Services
{
    // Lớp ThongTinNongDuoc ở đây (giả lập để code chạy độc lập)
    public class SanPhamNongDuocAfter
    {
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double HeSoChietKhau { get; set; }

        // SAU KHI MOVE METHOD
        // Chuyển phương thức TinhTienHoaDon sang lớp SanPhamNongDuocAfter
        // vì nó sử dụng nhiều dữ liệu của lớp này nhất.
        public double TinhTienHoaDon()
        {
            double tienGoc = DonGia * SoLuong;
            return tienGoc - (tienGoc * HeSoChietKhau);
        }
    }

    public class KhachHangAfter
    {
        public string TenKhachHang { get; set; }
        
        // Bây giờ lớp KhachHang chỉ việc gọi phương thức từ đối tượng Sản Phẩm (Delegate).
        public double LayTongTien(SanPhamNongDuocAfter thuoc)
        {
            return thuoc.TinhTienHoaDon();
        }
    }
}
