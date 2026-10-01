using DPM235479_NguyenVanThang_ChangeRefToValue.Models;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeRefToValue.Services
{
    // TRƯỚC KHI CHANGE REFERENCE TO VALUE
    // Lớp TienTe (Currency) đang được thiết kế dưới dạng Reference Object (Thông qua Registry).
    // Tuy nhiên, đối với một đối tượng quá NHỎ và BẤT BIẾN (không bao giờ thay đổi dữ liệu) như Tiền Tệ,
    // việc dùng Registry để quản lý tập trung lại trở nên cồng kềnh, phức tạp một cách dư thừa.

    public class TienTeBefore
    {
        public string MaTienTe { get; private set; } // Ví dụ: "VND", "USD"

        internal TienTeBefore(string ma)
        {
            MaTienTe = ma;
        }
    }

    // Factory/Registry quản lý Reference -> Quá rườm rà cho một đối tượng nhỏ
    public static class TienTeRegistry
    {
        private static Dictionary<string, TienTeBefore> _danhSach = new Dictionary<string, TienTeBefore>();

        public static TienTeBefore GetTienTe(string ma)
        {
            if (!_danhSach.ContainsKey(ma))
                _danhSach[ma] = new TienTeBefore(ma);
            return _danhSach[ma];
        }
    }

    public class SanPhamNongDuocBefore
    {
        public string TenSanPham { get; set; }
        public TienTeBefore DonViTien { get; set; } // Trỏ về Reference

        public SanPhamNongDuocBefore(string ten, string maTienTe)
        {
            TenSanPham = ten;
            // Phải gọi qua Registry rất mệt mỏi
            DonViTien = TienTeRegistry.GetTienTe(maTienTe); 
        }
    }
}
