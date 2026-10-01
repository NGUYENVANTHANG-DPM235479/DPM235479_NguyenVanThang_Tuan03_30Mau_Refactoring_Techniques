using DPM235479_NguyenVanThang_ExtractVariab.Models;
using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ExtractVariab.Services
{
    public class QuanLyBanHangReal
    {
        public void XuLyInHoaDonNongDuoc(List<HoaDonNongDuoc> danhSachHoaDon)
        {
            Console.WriteLine("=====================================================================================================");
            Console.WriteLine("                               CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                                    ");
            Console.WriteLine("                             DANH SÁCH HÓA ĐƠN XUẤT BÁN NÔNG DƯỢC                                    ");
            Console.WriteLine("=====================================================================================================");
            Console.WriteLine($"{"Mã HĐ",-8} | {"Ngày Lập",-10} | {"Sản Phẩm",-15} | {"Tiền Hàng",-12} | {"Chiết Khấu",-12} | {"Phí VC",-10} | {"Tổng Thanh Toán",-15}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");

            double tongDoanhThu = 0;

            foreach (var hd in danhSachHoaDon)
            {
                // ÁP DỤNG EXTRACT VARIABLE TRONG THỰC TẾ
                // Thay vì viết 1 dòng công thức dài và tính đi tính lại, ta tách ra các biến dễ hiểu theo nghiệp vụ
                
                double tienHangGoc = hd.SoLuong * hd.DonGiaPhanBon;
                
                bool duocGiamGia = hd.KhachHangNongDanThanThiet;
                double chietKhau = duocGiamGia ? tienHangGoc * 0.05 : 0; // Giảm 5% cho nông dân thân thiết
                
                bool mienPhiVanChuyen = tienHangGoc >= 5000000;
                double phiVanChuyen = mienPhiVanChuyen ? 0 : hd.KhoangCachGiaoHangKm * 3000;
                
                double thueVAT = (tienHangGoc - chietKhau) * 0.08; // VAT 8%
                
                double tongThanhToan = tienHangGoc - chietKhau + phiVanChuyen + thueVAT;
                
                tongDoanhThu += tongThanhToan;

                Console.WriteLine($"{hd.MaHoaDon,-8} | {hd.NgayLap:dd/MM/yyyy} | {hd.LoaiSanPhan,-15} | {tienHangGoc,12:N0} | {chietKhau,12:N0} | {phiVanChuyen,10:N0} | {tongThanhToan,15:N0}");
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"TỔNG CỘNG DOANH THU: {tongDoanhThu,80:N0} VNĐ");
            Console.WriteLine("=====================================================================================================");
        }
    }
}
