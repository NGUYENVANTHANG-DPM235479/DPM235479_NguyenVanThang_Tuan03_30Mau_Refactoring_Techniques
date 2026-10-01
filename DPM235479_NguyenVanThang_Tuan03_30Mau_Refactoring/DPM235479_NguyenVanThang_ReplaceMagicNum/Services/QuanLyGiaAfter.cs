using DPM235479_NguyenVanThang_ReplaceMagicNum.Models;

namespace DPM235479_NguyenVanThang_ReplaceMagicNum.Services
{
    // SAU KHI REPLACE MAGIC NUMBER
    // Kéo những con số ma thuật đó ra, đặt cho chúng một cái Tên (Symbolic Constant) như HESO_KHACH_LE.
    // Nhờ có tên, người đọc code sẽ lập tức hiểu ý nghĩa của con số.
    // Và nếu nhà nước thay đổi mức thuế, ta chỉ cần sửa đúng MỘT CHỖ duy nhất.

    public class QuanLyGiaAfter
    {
        // Khai báo hằng số (Constant) có tên đàng hoàng
        private const double HESO_KHACH_LE = 1.10; // Lãi 10%
        private const double HESO_DAI_LY = 1.05;   // Lãi 5%

        public double TinhGiaBanKhachLe(ThuocTruSau thuoc)
        {
            // Code đọc như văn xuôi, ai cũng hiểu
            return thuoc.GiaGoc * HESO_KHACH_LE; 
        }

        public double TinhGiaBanDaiLy(ThuocTruSau thuoc)
        {
            return thuoc.GiaGoc * HESO_DAI_LY; 
        }
    }
}
