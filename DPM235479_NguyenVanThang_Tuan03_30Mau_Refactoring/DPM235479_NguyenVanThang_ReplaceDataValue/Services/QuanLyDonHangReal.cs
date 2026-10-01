using DPM235479_NguyenVanThang_ReplaceDataValue.Models;
using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ReplaceDataValue.Services
{
    // THỰC TẾ:
    // Thống kê doanh thu theo Đối Tác. Nếu Đối Tác chỉ là kiểu string,
    // ta không thể tính "Chiết Khấu" theo từng loại đối tác (VIP, Thường).
    // Bắt buộc phải Replace Data Value with Object (thành lớp DoiTacPhanPhoi).

    public class DoiTacPhanPhoi
    {
        public string TenDoiTac { get; set; }
        public double PhanTramChietKhau { get; set; }

        public DoiTacPhanPhoi(string ten, double chietKhau)
        {
            TenDoiTac = ten;
            PhanTramChietKhau = chietKhau;
        }
    }

    public class HoaDonXuatKhoReal
    {
        public string MaHoaDon { get; set; }
        
        // Data Value (string) đã được thay bằng Object (DoiTacPhanPhoi)
        public DoiTacPhanPhoi KhachHang { get; set; }
        public double TongTien { get; set; }

        public HoaDonXuatKhoReal(string maHoaDon, DoiTacPhanPhoi khachHang, double tongTien)
        {
            MaHoaDon = maHoaDon;
            KhachHang = khachHang;
            TongTien = tongTien;
        }
        
        public double TinhTienThucThu()
        {
            // Nhờ Khách Hàng là Object, ta lấy được Chiết Khấu của riêng khách đó!
            return TongTien - (TongTien * KhachHang.PhanTramChietKhau);
        }
    }

    public class QuanLyDonHangReal
    {
        public void InPhieuThanhToan(HoaDonXuatKhoReal hoaDon)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                      BIÊN LAI THU TIỀN ĐẠI LÝ                       ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Mã phiếu: {hoaDon.MaHoaDon}");
            // Object phát huy tác dụng
            Console.WriteLine($"Khách hàng đại lý: {hoaDon.KhachHang.TenDoiTac}");
            Console.WriteLine($"Mức chiết khấu được hưởng: {hoaDon.KhachHang.PhanTramChietKhau * 100}%");
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"Giá trị đơn hàng: {hoaDon.TongTien:N0} VNĐ");
            Console.WriteLine($"SỐ TIỀN THỰC THU: {hoaDon.TinhTienThucThu():N0} VNĐ");
            Console.WriteLine("=======================================================================");
        }
    }
}
