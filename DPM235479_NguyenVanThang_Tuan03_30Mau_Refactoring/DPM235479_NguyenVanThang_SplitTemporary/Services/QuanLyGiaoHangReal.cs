using DPM235479_NguyenVanThang_SplitTemporary.Models;
using System;

namespace DPM235479_NguyenVanThang_SplitTemporary.Services
{
    public class QuanLyGiaoHangReal
    {
        // THỰC TẾ: Tính toán chi phí vận chuyển nông dược
        public void TinhChiPhiGiaoHang(ThongTinKienHang kienHang)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                 TÍNH TOÁN CHI PHÍ VẬN CHUYỂN LOGISTICS              ");
            Console.WriteLine("=======================================================================");
            
            // TRƯỚC KHI REFACTOR: Người lập trình có thể dùng 1 biến 'tinhToan' cho 2 việc
            // SAU KHI REFACTOR (Đã áp dụng Split Temporary Variable): 
            // Tách biệt 'theTich' và 'chiPhiVanChuyen'
            
            // 1. Tính thể tích kiện hàng (cần để báo cáo kho bãi)
            double theTichKienHang = kienHang.ChieuDai * kienHang.ChieuRong * kienHang.ChieuCao;
            Console.WriteLine($"Mã kiện hàng: {kienHang.MaKienHang}");
            Console.WriteLine($"Thể tích chiếm chỗ: {theTichKienHang} m3");
            
            // 2. Tính khối lượng quy đổi theo thể tích (Chuẩn vận chuyển: 1m3 = 300kg)
            double khoiLuongQuyDoi = theTichKienHang * 300;
            
            // Lấy khối lượng lớn nhất để tính phí
            double khoiLuongTinhPhi = Math.Max(kienHang.KhoiLuong, khoiLuongQuyDoi);
            Console.WriteLine($"Khối lượng tính phí thực tế: {khoiLuongTinhPhi} kg");
            
            // 3. Tính chi phí vận chuyển (Ví dụ 5000đ/kg/10km)
            double chiPhiVanChuyen = khoiLuongTinhPhi * 5000 * (kienHang.KhoangCachGiaoHangKm / 10);
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"TỔNG CƯỚC VẬN CHUYỂN: {chiPhiVanChuyen:N0} VNĐ");
            Console.WriteLine("=======================================================================");
        }
    }
}
