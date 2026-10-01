using DPM235479_NguyenVanThang_InlineMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_InlineMethod.Services
{
    public class QuanLyThongKeReal
    {
        public void XulyBaoCaoThongKeDoanhThu(List<HoaDonThongKe> danhSachHoaDon, BoLocThongKe boLoc)
        {
            InTieuDeBaoCao(boLoc);

            double tongDoanhThuGoc = 0;
            double tongGiamGiaKhuyenMai = 0;
            double tongPhiVanChuyen = 0;
            double tongThucThu = 0;
            int soLuongHoaDon = 0;

            Console.WriteLine($"{"Mã HĐ",-12} | {"Ngày Lập",-10} | {"Mã NV",-8} | {"Tiền Hàng",-12} | {"Giảm Giá",-12} | {"Thực Thu",-12}");
            Console.WriteLine("----------------------------------------------------------------------------------");

            foreach (var hd in danhSachHoaDon)
            {
                // INLINE METHOD: Thay vì tạo các hàm KiemTraNgay(), KiemTraNhanVien() 1 dòng,
                // ta inline trực tiếp điều kiện lọc vào câu lệnh IF
                bool matchesDate = hd.NgayLap >= boLoc.TuNgay && hd.NgayLap <= boLoc.DenNgay;
                bool matchesEmp = string.IsNullOrEmpty(boLoc.MaNhanVien) || hd.MaNhanVien == boLoc.MaNhanVien;

                if (matchesDate && matchesEmp)
                {
                    // INLINE METHOD: Inline trực tiếp phép tính thực thu
                    double thucThu = hd.TinhThucThu();

                    tongDoanhThuGoc += hd.TongTienHang;
                    tongGiamGiaKhuyenMai += hd.TienGiamGia;
                    tongPhiVanChuyen += hd.ChiPhiVanChuyen;
                    tongThucThu += thucThu;
                    soLuongHoaDon++;

                    Console.WriteLine($"{hd.MaHoaDon,-12} | {hd.NgayLap:dd/MM/yyyy} | {hd.MaNhanVien,-8} | {hd.TongTienHang,12:N0} | {hd.TienGiamGia,12:N0} | {thucThu,12:N0}");
                }
            }

            InTongHopKetQuaThongKe(soLuongHoaDon, tongDoanhThuGoc, tongGiamGiaKhuyenMai, tongPhiVanChuyen, tongThucThu);
        }

        private void InTieuDeBaoCao(BoLocThongKe boLoc)
        {
            Console.WriteLine("==================================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                              ");
            Console.WriteLine("             BÁO CÁO THỐNG KÊ DOANH THU VÀ KHUYẾN MÃI NHÂN VIÊN                           ");
            Console.WriteLine("==================================================================================");
            Console.WriteLine($"Thời gian: Từ ngày {boLoc.TuNgay:dd/MM/yyyy} đến ngày {boLoc.DenNgay:dd/MM/yyyy}");
            Console.WriteLine($"Nhân viên lọc: {(string.IsNullOrEmpty(boLoc.MaNhanVien) ? "Tất cả nhân viên" : boLoc.MaNhanVien)}");
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        private void InTongHopKetQuaThongKe(int soLuong, double tongGoc, double tongGiam, double tongVC, double tongThucThu)
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"Tổng số hóa đơn thỏa điều kiện:     {soLuong,20} HĐ");
            Console.WriteLine($"Tổng tiền hàng trước giảm giá:       {tongGoc,20:N0} VNĐ");
            Console.WriteLine($"Tổng chiết khấu / Khuyến mãi:       -{tongGiam,20:N0} VNĐ");
            Console.WriteLine($"Tổng chi phí vận chuyển thu thêm:   +{tongVC,20:N0} VNĐ");
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"TỔNG DOANH THU THỰC THU:             {tongThucThu,20:N0} VNĐ");
            Console.WriteLine("==================================================================================");
        }
    }
}
