using DPM235479_NguyenVanThang_ChangeRefToValue.Models;

namespace DPM235479_NguyenVanThang_ChangeRefToValue.Services
{
    // SAU KHI CHANGE REFERENCE TO VALUE
    // XÓA BỎ HOÀN TOÀN TỪ ĐIỂN REGISTRY.
    // Lớp TienTe giờ trở thành "Value Object". Ta cứ thoải mái 'new' nó ra mỗi khi cần dùng.
    // ĐỂ KIỂM SOÁT ĐƯỢC VALUE OBJECT: Ta phải viết đè (Override) hàm Equals() và GetHashCode()
    // để hai đồng tiền "VND" do 2 class new ra vẫn được máy tính coi là 1.

    public class TienTeAfter
    {
        public string MaTienTe { get; private set; } 

        public TienTeAfter(string ma) // Constructor mở lại public
        {
            MaTienTe = ma;
        }

        // BẮT BUỘC: Ghi đè Equals để so sánh "Giá trị" thay vì so sánh "Vùng nhớ"
        public override bool Equals(object obj)
        {
            if (obj is TienTeAfter other)
            {
                return this.MaTienTe == other.MaTienTe;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return MaTienTe.GetHashCode();
        }
    }

    public class SanPhamNongDuocAfter
    {
        public string TenSanPham { get; set; }
        public TienTeAfter DonViTien { get; set; } // Trở thành Value Object

        public SanPhamNongDuocAfter(string ten, string maTienTe)
        {
            TenSanPham = ten;
            // Thoải mái dùng 'new', code trở nên nhẹ nhàng, tự do hơn rất nhiều
            DonViTien = new TienTeAfter(maTienTe); 
        }
    }
}
