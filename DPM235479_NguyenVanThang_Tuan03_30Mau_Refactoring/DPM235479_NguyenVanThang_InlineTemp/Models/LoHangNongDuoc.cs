using System;

namespace DPM235479_NguyenVanThang_InlineTemp.Models
{
    public class LoHangNongDuoc
    {
        public string MaLo { get; set; }
        public string TenThuoc { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public int HanSuDungThang { get; set; }
        public int SoLuongTon { get; set; }
        
        // Phương thức hỗ trợ
        public bool SapHetHan()
        {
            DateTime ngayHetHan = NgaySanXuat.AddMonths(HanSuDungThang);
            return (ngayHetHan - DateTime.Now).TotalDays <= 30; // Dưới 30 ngày là sắp hết hạn
        }
    }
}
