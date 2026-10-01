using DPM235479_NguyenVanThang_ReplaceMethod.Models;
using System;

namespace DPM235479_NguyenVanThang_ReplaceMethod.Services
{
    public class QuanLyThuongReal
    {
        // THỰC TẾ: Tính toán thưởng cho nhân viên bán thuốc bảo vệ thực vật 
        // của Công ty Cổ phần Nông dược An Giang.
        
        public void XuatBaoCaoThuongNhanVien(NhanVienBanHang nv, double luongCoBanThang)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                   BÁO CÁO THƯỞNG CUỐI NĂM NHÂN VIÊN                 ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Nhân viên: {nv.TenNhanVien} (Mã NV: {nv.MaNhanVien})");
            
            // Sử dụng Method Object để thực hiện logic tính toán phức tạp
            PhanMemTinhThuongNongDuoc phanMemTinhToan = new PhanMemTinhThuongNongDuoc(nv, luongCoBanThang);
            double tongThuong = phanMemTinhToan.TinhTongThuongNhanVien();
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"Lương cơ bản 1 tháng: {luongCoBanThang:N0} VNĐ");
            Console.WriteLine($"TỔNG LƯƠNG & THƯỞNG NHẬN ĐƯỢC: {tongThuong:N0} VNĐ");
            Console.WriteLine("=======================================================================");
        }
    }

    // Lớp Method Object chịu trách nhiệm tính toán thưởng
    public class PhanMemTinhThuongNongDuoc
    {
        private NhanVienBanHang _nv;
        private double _luongCoBan;

        public PhanMemTinhThuongNongDuoc(NhanVienBanHang nv, double luongCoBan)
        {
            _nv = nv;
            _luongCoBan = luongCoBan;
        }

        public double TinhTongThuongNhanVien()
        {
            double thuongHoaHoc = _nv.DoanhThuThuocHoaHoc * 0.01; 
            double thuongSinhHoc = _nv.DoanhThuThuocSinhHoc * 0.08; // Cực kỳ khuyến khích bán phân bón/thuốc sinh học an toàn
            
            double heSoChuyenCan = TinhHeSoChuyenCan();
            double heSoDanhGia = _nv.DiemDanhGiaKhachHang / 100.0;
            
            return _luongCoBan * 12 + ((thuongHoaHoc + thuongSinhHoc) * heSoChuyenCan * heSoDanhGia);
        }

        private double TinhHeSoChuyenCan()
        {
            if (_nv.SoNgayLamViec >= 310) return 1.5;
            if (_nv.SoNgayLamViec >= 280) return 1.2;
            if (_nv.SoNgayLamViec < 200) return 0.5; // Nghỉ nhiều bị giảm thưởng
            return 1.0;
        }
    }
}
