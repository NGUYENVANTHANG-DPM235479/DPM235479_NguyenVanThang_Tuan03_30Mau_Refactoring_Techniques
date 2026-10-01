using System;

namespace DPM235479_NguyenVanThang_MoveField.Services
{
    // THỰC TẾ: 
    // Hệ thống bán hàng của Công ty Nông Dược An Giang quy định:
    // Chiết khấu (DiscountRate) không nằm lẻ tẻ trong các Hóa đơn (Order),
    // mà là đặc quyền thuộc về Phân loại khách hàng (CustomerType).
    // => Áp dụng Move Field chuyển DiscountRate sang CustomerType.

    public class PhanLoaiKhachHangNongDuoc
    {
        public string TenPhanLoai { get; set; } // Vd: VIP, Thường
        
        // MOVE FIELD: Field _tyLeGiamGia được gắn cứng cho từng Phân Loại
        private double _tyLeGiamGia; 

        public PhanLoaiKhachHangNongDuoc(string tenPhanLoai, double tyLeGiamGia)
        {
            TenPhanLoai = tenPhanLoai;
            _tyLeGiamGia = tyLeGiamGia;
        }

        public double LayTyLeGiamGia()
        {
            return _tyLeGiamGia;
        }
    }

    public class KhachHangReal
    {
        public string TenKhach { get; set; }
        public PhanLoaiKhachHangNongDuoc LoaiKhach { get; set; }

        public KhachHangReal(string tenKhach, PhanLoaiKhachHangNongDuoc loaiKhach)
        {
            TenKhach = tenKhach;
            LoaiKhach = loaiKhach;
        }
    }

    public class QuanLyChietKhauReal
    {
        public void ThanhToanHoaDon(KhachHangReal kh, double tienPhanBon)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                       XUẤT HÓA ĐƠN BÁN HÀNG                         ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Khách hàng: {kh.TenKhach} | Hạng: {kh.LoaiKhach.TenPhanLoai}");
            Console.WriteLine($"Tổng tiền phân bón (chưa giảm): {tienPhanBon:N0} VNĐ");
            
            // Lấy tỷ lệ giảm giá trực tiếp từ đối tượng Phân Loại Khách Hàng (Move Field)
            double giamGia = kh.LoaiKhach.LayTyLeGiamGia();
            double tienPhaiTra = tienPhanBon - (tienPhanBon * giamGia);
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"Chiết khấu áp dụng: {giamGia * 100}%");
            Console.WriteLine($"SỐ TIỀN THANH TOÁN CUỐI CÙNG: {tienPhaiTra:N0} VNĐ");
            Console.WriteLine("=======================================================================");
        }
    }
}
