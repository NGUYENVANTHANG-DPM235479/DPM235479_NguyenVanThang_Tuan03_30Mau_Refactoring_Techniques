using System;

namespace DPM235479_NguyenVanThang_ReplaceMethod.Services
{
    // SAU KHI REPLACE METHOD WITH METHOD OBJECT
    // Thay vì viết 1 hàm rất dài trong class QuanLyThuong, ta tạo 1 object riêng (BoTinhThuongCuoiNam)
    // chứa các biến cục bộ thành thuộc tính (field) của object đó, từ đó dễ dàng tách các hàm nhỏ.
    
    public class QuanLyThuongAfter
    {
        public double TinhThuongCuoiNam(double luongCoBan, double dtHoaHoc, double dtSinhHoc, int soNgayLam, int diemDanhGia)
        {
            // Gọi Method Object để tính toán
            BoTinhThuongCuoiNam boTinh = new BoTinhThuongCuoiNam(luongCoBan, dtHoaHoc, dtSinhHoc, soNgayLam, diemDanhGia);
            return boTinh.TinhToan();
        }
    }

    public class BoTinhThuongCuoiNam
    {
        private double _luongCoBan;
        private double _dtHoaHoc;
        private double _dtSinhHoc;
        private int _soNgayLam;
        private int _diemDanhGia;

        public BoTinhThuongCuoiNam(double luongCoBan, double dtHoaHoc, double dtSinhHoc, int soNgayLam, int diemDanhGia)
        {
            _luongCoBan = luongCoBan;
            _dtHoaHoc = dtHoaHoc;
            _dtSinhHoc = dtSinhHoc;
            _soNgayLam = soNgayLam;
            _diemDanhGia = diemDanhGia;
        }

        public double TinhToan()
        {
            return _luongCoBan + TinhTongThuong();
        }

        private double TinhTongThuong()
        {
            return (TinhThuongHoaHoc() + TinhThuongSinhHoc()) * TinhHeSoNgayLam() * TinhHeSoKhachHang();
        }

        private double TinhThuongHoaHoc() => _dtHoaHoc * 0.02;
        private double TinhThuongSinhHoc() => _dtSinhHoc * 0.05;
        
        private double TinhHeSoNgayLam()
        {
            if (_soNgayLam > 300) return 1.2;
            if (_soNgayLam < 200) return 0.8;
            return 1.0;
        }
        
        private double TinhHeSoKhachHang() => _diemDanhGia / 100.0;
    }
}
