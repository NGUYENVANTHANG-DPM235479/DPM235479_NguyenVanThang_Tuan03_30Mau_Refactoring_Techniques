using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeUniToBi.Services
{
    // TRƯỚC KHI CHANGE UNIDIRECTIONAL TO BIDIRECTIONAL
    // Liên kết một chiều (Unidirectional). 
    // Từ Nhà Cung Cấp (NhaCungCapBefore), ta có thể truy xuất danh sách Sản Phẩm của họ.
    // NHƯNG, nếu cầm trên tay một Sản Phẩm (SanPhamBefore), ta KHÔNG THỂ nào biết được nó thuộc về Nhà Cung Cấp nào.

    public class SanPhamBefore
    {
        public string TenSP { get; set; }
        
        public SanPhamBefore(string ten)
        {
            TenSP = ten;
        }
        // Vấn đề: Không có đường dẫn ngược về Nhà Cung Cấp
    }

    public class NhaCungCapBefore
    {
        public string TenNCC { get; set; }
        public List<SanPhamBefore> DanhSachSP { get; set; }

        public NhaCungCapBefore(string ten)
        {
            TenNCC = ten;
            DanhSachSP = new List<SanPhamBefore>();
        }

        public void ThemSanPham(SanPhamBefore sp)
        {
            DanhSachSP.Add(sp); // Chỉ có liên kết 1 chiều (NCC -> SP)
        }
    }
}
