using System;

namespace DPM235479_NguyenVanThang_ReplaceArrayWithObj.Services
{
    // TRƯỚC KHI REPLACE ARRAY WITH OBJECT
    // Lập trình viên đang dùng một Mảng (Array) gồm 3 phần tử kiểu chuỗi (string)
    // để chứa thông tin Đội Ngũ Bán Hàng: [0] Tên, [1] Số lượng bán, [2] Thưởng.
    // Việc này cực kỳ khó hiểu, dễ nhầm lẫn chỉ mục (index), và phải ép kiểu (parse) rất phiền phức.

    public class QuanLyBaoCaoBefore
    {
        public void InThongKeBanHang()
        {
            // Dùng Mảng (Array) để chứa nhiều loại dữ liệu khác nhau
            string[] baoCaoNhanVien = new string[3];
            baoCaoNhanVien[0] = "Nguyễn Văn A"; // Tên
            baoCaoNhanVien[1] = "150";         // Số sản phẩm đã bán
            baoCaoNhanVien[2] = "Nông Dược VN"; // Chi nhánh

            // Code đọc dữ liệu rất "mù mờ", ai đọc cũng phải đoán xem [0], [1] là cái gì
            string ten = baoCaoNhanVien[0];
            int soLuong = int.Parse(baoCaoNhanVien[1]); // Phải ép kiểu từ string sang int
            string chiNhanh = baoCaoNhanVien[2];

            Console.WriteLine($"Nhân viên {ten} ({chiNhanh}) đã bán {soLuong} sản phẩm.");
        }
    }
}
