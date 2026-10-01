namespace DPM235479_NguyenVanThang_EncapsulateField.Services
{
    // SAU KHI ENCAPSULATE FIELD
    // Đổi biến public thành private, và cung cấp hàm Getter/Setter (hoặc Property trong C#).

    public class NhanVienAfter
    {
        public string TenNhanVien { get; set; }
        
        // 1. Giấu biến này đi (private)
        private double _luongCoBan;

        // 2. Cung cấp "Cánh cổng" (Property) để bên ngoài đi qua
        public double LuongCoBan
        {
            get { return _luongCoBan; }
            set 
            { 
                if (value < 4000000) 
                    throw new System.Exception("Lương cơ bản không được thấp hơn mức tối thiểu vùng 4tr!");
                _luongCoBan = value; 
            }
        }
    }

    public class QuanLyLuongAfter
    {
        public void TangLuongChoNhanVien(NhanVienAfter nv, double tienTangThangNay)
        {
            // Bây giờ ta gọi thông qua Property. 
            // Bên trong Property đã có sẵn ổ khóa bảo vệ (if value < 4tr).
            nv.LuongCoBan = nv.LuongCoBan + tienTangThangNay;
        }
    }
}
