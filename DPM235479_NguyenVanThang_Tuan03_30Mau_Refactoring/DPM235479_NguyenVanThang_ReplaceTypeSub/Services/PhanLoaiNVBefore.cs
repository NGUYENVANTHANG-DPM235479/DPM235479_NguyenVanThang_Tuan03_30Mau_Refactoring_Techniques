namespace DPM235479_NguyenVanThang_ReplaceTypeSub.Services
{
    // TRƯỚC KHI REPLACE TYPE CODE WITH SUBCLASSES
    // Tương tự mẫu trước, nhưng lần này Loại Nhân Viên ẢNH HƯỞNG TỚI LOGIC (Ví dụ: Tính Lương).
    // Người ta dùng một biến int (Type Code) và viết một đống Switch-Case dài thòng 
    // bên trong hàm TinhLuong(). Code rất xấu và khó bảo trì.

    public class NhanVienBefore
    {
        public const int KI_SU = 0;
        public const int NHAN_VIEN_BAN_HANG = 1;
        public const int GIAO_HANG = 2;

        public string TenNV { get; set; }
        private int _loai; // Type Code
        public double LuongCoBan { get; set; }

        public NhanVienBefore(string ten, int loai, double luong)
        {
            TenNV = ten;
            _loai = loai;
            LuongCoBan = luong;
        }

        public double TinhThucLanh()
        {
            // Vi phạm nguyên tắc Open/Closed. Mỗi lần có loại NV mới là phải sửa hàm này.
            switch (_loai)
            {
                case KI_SU:
                    return LuongCoBan * 1.5; // Kỹ sư hệ số 1.5
                case NHAN_VIEN_BAN_HANG:
                    return LuongCoBan + 2000000; // Sales thưởng 2tr
                case GIAO_HANG:
                    return LuongCoBan + 1000000; // Giao hàng thưởng 1tr
                default:
                    return LuongCoBan;
            }
        }
    }

    public class PhanLoaiNVBefore
    {
        // Demo
    }
}
