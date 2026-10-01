using DPM235479_NguyenVanThang_RemoveAssign.Models;
using System;

namespace DPM235479_NguyenVanThang_RemoveAssign.Services
{
    public class QuanLyGiaBanReal
    {
        // THỰC TẾ: Tính toán giá bán cuối cùng của sản phẩm nông dược An Giang
        // Dựa trên các yếu tố thị trường, lưu kho, độ độc hại mà không làm mất giá gốc.
        
        public void TinhGiaBanThiTruong(SanPhamNongDuoc sanPham, double giaBanThamKhao)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                    ĐIỀU CHỈNH GIÁ BÁN THỊ TRƯỜNG                    ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Sản phẩm: {sanPham.TenThuoc}");
            Console.WriteLine($"Giá tham khảo ban đầu đưa vào: {giaBanThamKhao:N0} VNĐ");
            
            // REMOVE ASSIGNMENTS TO PARAMETERS:
            // Không gán: giaBanThamKhao = giaBanThamKhao + ...
            // Mà gán qua biến 'giaDieuChinh'
            double giaDieuChinh = giaBanThamKhao;
            
            // Nếu hàng lưu kho lâu (trên 180 ngày) -> Giảm giá xả hàng
            if (sanPham.ThoiGianLuuKhoNgay > 180)
            {
                giaDieuChinh -= (giaDieuChinh * 0.15); // Giảm 15%
            }
            
            // Nếu là hàng khan hiếm trên thị trường -> Tăng giá
            if (sanPham.DangKhanHiem)
            {
                giaDieuChinh += (giaDieuChinh * 0.20); // Tăng 20%
            }
            
            // Nếu là hàng độc hại cao -> Phụ thu phí xử lý môi trường
            if (sanPham.LaHangDocHaiCao)
            {
                giaDieuChinh += 50000; 
            }
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"Mã SP: {sanPham.MaSanPham}");
            Console.WriteLine($"Giá Gốc (Giá nhập): {sanPham.GiaGoc:N0} VNĐ");
            Console.WriteLine($"Giá Tham Khảo Ban Đầu: {giaBanThamKhao:N0} VNĐ"); // Giữ được giá trị gốc để in ra báo cáo
            Console.WriteLine($"GIÁ BÁN ĐIỀU CHỈNH CHÍNH THỨC: {giaDieuChinh:N0} VNĐ");
            Console.WriteLine("=======================================================================");
        }
    }
}
