using DPM235479_NguyenVanThang_ReplaceMagicNum.Models;

namespace DPM235479_NguyenVanThang_ReplaceMagicNum.Services
{
    // TRƯỚC KHI REPLACE MAGIC NUMBER
    // Trong hàm TinhGiaBan, lập trình viên sử dụng trực tiếp con số 1.05 và 1.10.
    // Những con số trần trụi này được gọi là "Magic Number" (Con số ma thuật) vì chả ai hiểu nó từ đâu ra.
    // Tháng sau sếp yêu cầu đổi thuế thành 8% (1.08), ta phải đi dò mẫm tìm tất cả số 1.05 để sửa. Rất nguy hiểm!

    public class QuanLyGiaBefore
    {
        public double TinhGiaBanKhachLe(ThuocTruSau thuoc)
        {
            // Số 1.10 là cái quái gì? Ai mà biết!
            return thuoc.GiaGoc * 1.10; 
        }

        public double TinhGiaBanDaiLy(ThuocTruSau thuoc)
        {
            // Số 1.05 là cái gì? Chắc là thuế? Hay là chiết khấu? 
            return thuoc.GiaGoc * 1.05; 
        }
    }
}
