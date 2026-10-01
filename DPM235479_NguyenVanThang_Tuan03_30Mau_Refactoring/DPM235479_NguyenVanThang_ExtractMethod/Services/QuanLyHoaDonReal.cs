using DPM235479_NguyenVanThang_ExtractMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_ExtractMethod.Services
{
    // 3. ÁP DỤNG THỰC TẾ VÀO ĐỒ ÁN BẢO TRÌ PHẦN MỀM CÔNG TY NÔNG DƯỢC AN GIANG
    // Áp dụng Extract Method để giải quyết bài toán hóa đơn gồm chiết khấu, vận chuyển, dịch vụ phụ & MS Access[cite: 9]
    public class QuanLyHoaDonReal
    {
        public void XulyLapVaInHoaDon(HoaDon hoaDon)
        {
            InTieuDeHoaDon(hoaDon);

            double tongTienHang = InDanhSachMatHangVatTu(hoaDon);
            double tienChietKhau = TinhTienChietKhau(tongTienHang, hoaDon.TyLeChietKhau);
            double tongThanhToan = TinhTongThanhToan(tongTienHang, tienChietKhau, hoaDon.ChiPhiVanChuyen, hoaDon.ChiPhiDichVuPhu);

            InTongHopChiPhiThanhToan(tongTienHang, tienChietKhau, hoaDon.ChiPhiVanChuyen, hoaDon.ChiPhiDichVuPhu, tongThanhToan);
            LuuHoaDonVaoAccessCSDL(hoaDon.MaHoaDon, tongThanhToan);
        }

        // =========================================================================
        // CÁC PHƯƠNG THỨC ĐƯỢC TÁCH BẰNG MẪU EXTRACT METHOD
        // =========================================================================

        private void InTieuDeHoaDon(HoaDon hoaDon)
        {
            Console.WriteLine("==================================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                              ");
            Console.WriteLine("                        HÓA ĐƠN BÁN HÀNG NÔNG DƯỢC                                ");
            Console.WriteLine("==================================================================================");
            Console.WriteLine($"Mã HĐ: {hoaDon.MaHoaDon} | Ngày lập: {hoaDon.NgayLap:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Khách hàng: {hoaDon.TenKhachHang} | NV Lập hóa đơn: {hoaDon.MaNhanVien}");
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        private double InDanhSachMatHangVatTu(HoaDon hoaDon)
        {
            double tongTienHang = 0;
            Console.WriteLine($"{"Tên Sản Phẩm",-22} | {"Số Lô",-10} | {"Hạn Sử Dụng",-12} | {"SL",-3} | {"Thành Tiền",-12}");
            Console.WriteLine("----------------------------------------------------------------------------------");

            foreach (var item in hoaDon.DanhSachChiTiet)
            {
                double thanhTien = item.TinhThanhTien();
                tongTienHang += thanhTien;
                Console.WriteLine($"{item.TenSanPham,-22} | {item.SoLo,-10} | {item.NgayHetHan:dd/MM/yyyy}   | {item.SoLuong,3} | {thanhTien,12:N0}");
            }
            return tongTienHang;
        }

        private double TinhTienChietKhau(double tongTienHang, double tyLeChietKhau)
        {
            return tongTienHang * tyLeChietKhau;
        }

        private double TinhTongThanhToan(double tongTienHang, double tienChietKhau, double chiPhiVanChuyen, double chiPhiDichVuPhu)
        {
            return tongTienHang - tienChietKhau + chiPhiVanChuyen + chiPhiDichVuPhu;
        }

        private void InTongHopChiPhiThanhToan(double tongTien, double chietKhau, double vanChuyen, double dichVuPhu, double tongThanhToan)
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"Tổng tiền hàng:                     {tongTien,20:N0} VNĐ");
            Console.WriteLine($"Chiết khấu / Giảm giá:             -{chietKhau,20:N0} VNĐ");
            Console.WriteLine($"Phí vận chuyển phụ:                +{vanChuyen,20:N0} VNĐ");
            Console.WriteLine($"Chi phí dịch vụ phát sinh:          +{dichVuPhu,20:N0} VNĐ");
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"TỔNG CỘNG THÀNH TOÁN:               {tongThanhToan,20:N0} VNĐ");
            Console.WriteLine("==================================================================================");
        }

        private void LuuHoaDonVaoAccessCSDL(string maHoaDon, double tongThanhToan)
        {
            // Giả lập kết nối và lưu vào CSDL MS Access (.mdb / .accdb) của Công ty Nông Dược An Giang[cite: 9]
            Console.WriteLine($"[MS Access CSDL] Luu thanh cong Hoa don {maHoaDon} voi Tong tien = {tongThanhToan:N0} VNĐ.");
        }
    }
}
