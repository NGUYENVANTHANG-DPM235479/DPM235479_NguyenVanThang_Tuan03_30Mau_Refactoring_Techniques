namespace DPM235479_NguyenVanThang_ReplaceTypeClass.Services
{
    // TRƯỚC KHI REPLACE TYPE CODE WITH CLASS
    // Lập trình viên đang dùng Số nguyên (int) để đại diện cho Loại phân bón.
    // VD: 0 là Hữu cơ, 1 là Vô cơ, 2 là Sinh học.
    // Điều này cực kỳ rủi ro (Type Code). Nếu lỡ tay truyền vào số 99, 
    // trình biên dịch C# không hề báo lỗi, nhưng logic công ty sẽ sụp đổ.

    public class PhanBonBefore
    {
        // Type Codes
        public const int HUU_CO = 0;
        public const int VO_CO = 1;
        public const int SINH_HOC = 2;

        public string TenPhanBon { get; set; }
        public int LoaiPhanBon; // Dùng int (Type Code)

        public PhanBonBefore(string ten, int loai)
        {
            TenPhanBon = ten;
            LoaiPhanBon = loai; // Nguy hiểm, có thể gán LoaiPhanBon = 99
        }
    }

    public class QuanLyNhomMauBefore
    {
        public void TaoPhanBon()
        {
            PhanBonBefore p1 = new PhanBonBefore("Đạm Cà Mau", PhanBonBefore.VO_CO); // Hợp lệ
            PhanBonBefore p2 = new PhanBonBefore("Lân Nung chảy", 999); // C# không báo lỗi, nhưng SAI NGHIỆP VỤ!
        }
    }
}
