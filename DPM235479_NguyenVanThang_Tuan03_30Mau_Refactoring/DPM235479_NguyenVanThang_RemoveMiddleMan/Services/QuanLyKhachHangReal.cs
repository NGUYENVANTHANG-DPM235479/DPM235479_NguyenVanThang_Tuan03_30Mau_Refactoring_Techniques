using System;

namespace DPM235479_NguyenVanThang_RemoveMiddleMan.Services
{
    // THỰC TẾ:
    // Hệ thống tạo Đơn Hàng Phân Bón của Nông Dược An Giang.
    // Lớp DonHang không cần phải viết hàm LayHoTenNguoiNhan(), LayDiaChiNguoiNhan(), LaySDTNguoiNhan()
    // mà chỉ cần trả về luôn đối tượng ThongTinLienHeNhanHang.

    public class ThongTinLienHeNhanHang
    {
        public string HoTenNguoiNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string SoDienThoai { get; set; }
    }

    public class DonHangPhanBonReal
    {
        public string MaDonHang { get; set; }
        
        // Cung cấp trực tiếp Đối tượng thay vì làm Middle Man
        public ThongTinLienHeNhanHang LienHe { get; set; } 

        public DonHangPhanBonReal(string maDon, ThongTinLienHeNhanHang lienHe)
        {
            MaDonHang = maDon;
            LienHe = lienHe;
        }
    }

    public class QuanLyKhachHangReal
    {
        public void InPhieuGiaoHang(DonHangPhanBonReal donHang)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                        PHIẾU GIAO HÀNG TẬN NƠI                      ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Mã phiếu xuất kho: {donHang.MaDonHang}");
            
            // Client gọi trực tiếp vào cấu trúc bên trong (Remove Middle Man)
            // Lớp DonHangPhanBonReal rất sạch sẽ, không phải chứa 3 hàm Getter dư thừa
            ThongTinLienHeNhanHang thongTin = donHang.LienHe;
            
            Console.WriteLine("------------------------- THÔNG TIN NGƯỜI NHẬN ------------------------");
            Console.WriteLine($"- Họ tên: {thongTin.HoTenNguoiNhan}");
            Console.WriteLine($"- SĐT liên lạc: {thongTin.SoDienThoai}");
            Console.WriteLine($"- Địa chỉ giao: {thongTin.DiaChiNhan}");
            
            Console.WriteLine("=======================================================================");
        }
    }
}
