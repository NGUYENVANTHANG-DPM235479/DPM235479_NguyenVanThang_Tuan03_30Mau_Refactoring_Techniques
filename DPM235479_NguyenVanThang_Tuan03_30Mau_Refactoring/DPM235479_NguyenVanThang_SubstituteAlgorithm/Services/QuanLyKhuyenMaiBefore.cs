using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_SubstituteAlgorithm.Services
{
    public class QuanLyKhuyenMaiBefore
    {
        // TRƯỚC KHI SUBSTITUTE ALGORITHM
        // Sử dụng một đống chuỗi if-else dài thòng để kiểm tra và trả về kết quả
        public string LayQuaTang(string loaiSanPham)
        {
            if (loaiSanPham == "NPK")
            {
                return "Tặng 1 áo thun nông dân";
            }
            else if (loaiSanPham == "Ure")
            {
                return "Tặng 1 nón lá";
            }
            else if (loaiSanPham == "DAP")
            {
                return "Tặng 1 túi xách";
            }
            else if (loaiSanPham == "Kali")
            {
                return "Tặng 1 đôi ủng";
            }
            else if (loaiSanPham == "ThuocTruSau")
            {
                return "Tặng mặt nạ phòng độc";
            }
            
            return "Không có khuyến mãi";
        }
    }
}
