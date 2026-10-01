using System;

namespace DPM235479_NguyenVanThang_ReplaceMethod.Services
{
    public class QuanLyThuongBefore
    {
        // TRƯỚC KHI REPLACE METHOD WITH METHOD OBJECT
        // Phương thức tính toán quá dài, sử dụng nhiều biến cục bộ xen kẽ nhau.
        // Khó tách hàm (Extract Method) vì phải truyền đi truyền lại quá nhiều tham số.
        public double TinhThuongCuoiNam(double luongCoBan, double dtHoaHoc, double dtSinhHoc, int soNgayLam, int diemDanhGia)
        {
            double thuongDoanhThuHoaHoc = dtHoaHoc * 0.02;
            double thuongDoanhThuSinhHoc = dtSinhHoc * 0.05; // Khuyến khích bán thuốc sinh học
            
            double heSoNgayLam = 1.0;
            if (soNgayLam > 300) heSoNgayLam = 1.2;
            else if (soNgayLam < 200) heSoNgayLam = 0.8;
            
            double heSoKhachHang = diemDanhGia / 100.0;
            
            double tongThuong = (thuongDoanhThuHoaHoc + thuongDoanhThuSinhHoc) * heSoNgayLam * heSoKhachHang;
            
            return luongCoBan + tongThuong;
        }
    }
}
