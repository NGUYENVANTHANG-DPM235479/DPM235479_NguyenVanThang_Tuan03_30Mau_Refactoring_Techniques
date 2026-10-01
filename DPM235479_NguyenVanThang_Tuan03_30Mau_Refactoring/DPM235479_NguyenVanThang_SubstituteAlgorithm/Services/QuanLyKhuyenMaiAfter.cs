using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_SubstituteAlgorithm.Services
{
    public class QuanLyKhuyenMaiAfter
    {
        // SAU KHI SUBSTITUTE ALGORITHM
        // Thay thế toàn bộ khối if-else cồng kềnh bằng thuật toán lookup Dictionary.
        // Nhanh, dễ đọc và dễ bảo trì (thêm/sửa/xóa khuyến mãi dễ dàng).
        public string LayQuaTang(string loaiSanPham)
        {
            var danhSachKhuyenMai = new Dictionary<string, string>
            {
                { "NPK", "Tặng 1 áo thun nông dân" },
                { "Ure", "Tặng 1 nón lá" },
                { "DAP", "Tặng 1 túi xách" },
                { "Kali", "Tặng 1 đôi ủng" },
                { "ThuocTruSau", "Tặng mặt nạ phòng độc" }
            };

            if (danhSachKhuyenMai.ContainsKey(loaiSanPham))
            {
                return danhSachKhuyenMai[loaiSanPham];
            }
            
            return "Không có khuyến mãi";
        }
    }
}
