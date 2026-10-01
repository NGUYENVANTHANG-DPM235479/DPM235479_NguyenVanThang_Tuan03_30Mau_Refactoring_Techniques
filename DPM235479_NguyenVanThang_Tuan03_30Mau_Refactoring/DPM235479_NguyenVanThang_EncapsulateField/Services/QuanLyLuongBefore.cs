using DPM235479_NguyenVanThang_EncapsulateField.Models;

namespace DPM235479_NguyenVanThang_EncapsulateField.Services
{
    // TRƯỚC KHI ENCAPSULATE FIELD
    // (Lưu ý: Mẫu này rất giống Self Encapsulate Field, nhưng đây là góc nhìn từ BÊN NGOÀI Class).
    // Có một Field (biến) public tên là `LuongCoBan` nằm tơ hơ trong class NhanVien.
    // Lớp QuanLyLuongBefore thoải mái truy cập và chỉnh sửa trực tiếp biến này.
    // Lỡ có ông nào truyền vào lương ÂM thì công ty sập tiệm.

    public class QuanLyLuongBefore
    {
        public void TangLuongChoNhanVien(NhanVien nv, double tienTangThangNay)
        {
            // Truy cập TRỰC TIẾP vào Field (Biến) của lớp khác
            // Mùi code rất hôi vì ta phá vỡ tính đóng gói của OOP
            nv.LuongCoBan = nv.LuongCoBan + tienTangThangNay;
        }
    }
}
