namespace DPM235479_NguyenVanThang_ReplaceTypeClass.Services
{
    // SAU KHI REPLACE TYPE CODE WITH CLASS
    // Xóa sổ cái kiểu "int" tối nghĩa kia đi. 
    // Tạo ra hẳn một Class mang tên 'LoaiPhanBonClass' để định nghĩa kiểu dữ liệu.
    // Cung cấp các hằng số (Static Readonly) ngay bên trong class đó.
    // Trình biên dịch C# sẽ bảo vệ Type Safety (An toàn kiểu) một cách tuyệt đối.

    // 1. TẠO CLASS THAY THẾ CHO TYPE CODE
    public class LoaiPhanBonClass
    {
        public int Code { get; private set; }
        
        private LoaiPhanBonClass(int code)
        {
            Code = code;
        }

        // Định nghĩa sẵn các "Lựa chọn hợp lệ"
        public static readonly LoaiPhanBonClass HuuCo = new LoaiPhanBonClass(0);
        public static readonly LoaiPhanBonClass VoCo = new LoaiPhanBonClass(1);
        public static readonly LoaiPhanBonClass SinhHoc = new LoaiPhanBonClass(2);
    }

    public class PhanBonAfter
    {
        public string TenPhanBon { get; set; }
        
        // 2. Dùng CLASS thay vì dùng int
        public LoaiPhanBonClass LoaiPhanBon { get; set; }

        public PhanBonAfter(string ten, LoaiPhanBonClass loai)
        {
            TenPhanBon = ten;
            LoaiPhanBon = loai;
        }
    }

    public class QuanLyNhomMauAfter
    {
        public void TaoPhanBon()
        {
            // Bây giờ, người code BẮT BUỘC phải chấm (Dot) từ LoaiPhanBonClass
            PhanBonAfter p1 = new PhanBonAfter("Đạm Cà Mau", LoaiPhanBonClass.VoCo); 
            
            // Nếu truyền số 999 vào, C# sẽ chửi thẳng vào mặt và Báo Đỏ lỗi biên dịch
            // PhanBonAfter p2 = new PhanBonAfter("Lân Nung chảy", 999); => ERROR
        }
    }
}
