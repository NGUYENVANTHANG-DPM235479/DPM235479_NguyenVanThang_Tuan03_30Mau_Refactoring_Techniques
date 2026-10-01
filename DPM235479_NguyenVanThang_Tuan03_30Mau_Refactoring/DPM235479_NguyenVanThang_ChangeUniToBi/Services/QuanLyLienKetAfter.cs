using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeUniToBi.Services
{
    // SAU KHI CHANGE UNIDIRECTIONAL TO BIDIRECTIONAL
    // Thiết lập liên kết HAI CHIỀU (Bidirectional).
    // Bổ sung thuộc tính tham chiếu ngược từ Sản Phẩm về Nhà Cung Cấp.
    // LƯU Ý: Phải cẩn thận để tránh vòng lặp vô hạn (Infinite loop) khi thêm liên kết.

    public class SanPhamAfter
    {
        public string TenSP { get; set; }
        
        // Bổ sung liên kết ngược (Back-reference)
        public NhaCungCapAfter NhaCungCapCuaToi { get; set; }

        public SanPhamAfter(string ten)
        {
            TenSP = ten;
        }
        
        // Hàm thiết lập liên kết từ phía Sản Phẩm (Bắt buộc dùng internal để class kia gọi)
        internal void SetNhaCungCap(NhaCungCapAfter ncc)
        {
            NhaCungCapCuaToi = ncc;
        }
    }

    public class NhaCungCapAfter
    {
        public string TenNCC { get; set; }
        public List<SanPhamAfter> DanhSachSP { get; set; }

        public NhaCungCapAfter(string ten)
        {
            TenNCC = ten;
            DanhSachSP = new List<SanPhamAfter>();
        }

        public void ThemSanPham(SanPhamAfter sp)
        {
            // Liên kết chiều đi: (NCC -> SP)
            DanhSachSP.Add(sp); 
            
            // Liên kết chiều về: (SP -> NCC). Cực kỳ quan trọng để thành 2 chiều.
            sp.SetNhaCungCap(this); 
        }
    }
}
