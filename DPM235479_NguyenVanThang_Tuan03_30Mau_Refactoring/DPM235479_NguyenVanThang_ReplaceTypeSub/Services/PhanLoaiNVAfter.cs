namespace DPM235479_NguyenVanThang_ReplaceTypeSub.Services
{
    // SAU KHI REPLACE TYPE CODE WITH SUBCLASSES
    // Vì 'Loại nhân viên' quyết định thuật toán tính lương (Behavior), 
    // nên ta không dùng class đại diện nữa, mà dùng luôn TÍNH KẾ THỪA (Inheritance / Subclasses).
    // Class cha NhanVien thành abstract. Các lớp con sẽ tự Override hàm TinhThucLanh().
    // Xóa sổ hoàn toàn lệnh Switch-Case (Polymorphism).

    // 1. Tạo Class Cha Abstract
    public abstract class NhanVienAfter
    {
        public string TenNV { get; set; }
        public double LuongCoBan { get; set; }

        protected NhanVienAfter(string ten, double luong)
        {
            TenNV = ten;
            LuongCoBan = luong;
        }

        // Bắt buộc các lớp con phải tự tính lương
        public abstract double TinhThucLanh();
    }

    // 2. Tạo các Subclass
    public class KySuNongNghiep : NhanVienAfter
    {
        public KySuNongNghiep(string ten, double luong) : base(ten, luong) { }
        
        public override double TinhThucLanh()
        {
            return LuongCoBan * 1.5;
        }
    }

    public class NhanVienSales : NhanVienAfter
    {
        public NhanVienSales(string ten, double luong) : base(ten, luong) { }

        public override double TinhThucLanh()
        {
            return LuongCoBan + 2000000;
        }
    }

    public class PhanLoaiNVAfter
    {
        // Demo
    }
}
