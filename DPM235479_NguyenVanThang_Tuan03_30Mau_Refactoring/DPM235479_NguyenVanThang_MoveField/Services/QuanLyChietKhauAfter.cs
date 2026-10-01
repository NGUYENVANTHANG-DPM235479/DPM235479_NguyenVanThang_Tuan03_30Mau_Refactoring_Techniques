using System;

namespace DPM235479_NguyenVanThang_MoveField.Services
{
    // SAU KHI MOVE FIELD
    // Đưa _mucChietKhau sang đúng lớp chủ nhân của nó là DaiLyAfter
    // HoaDonBanHang sẽ lấy trực tiếp mức chiết khấu từ đối tượng DaiLy
    
    public class DaiLyAfter
    {
        public string TenDaiLy { get; set; }
        public string LoaiDaiLy { get; set; }
        
        // FIELD ĐƯỢC DI CHUYỂN SANG ĐÂY
        public double MucChietKhau { get; set; } 
    }

    public class HoaDonBanHangAfter
    {
        private DaiLyAfter _daiLy;
        private double _tongTienGoc;

        public HoaDonBanHangAfter(DaiLyAfter daiLy, double tongTienGoc)
        {
            _daiLy = daiLy;
            _tongTienGoc = tongTienGoc;
        }

        public double TinhTienPhaiTra()
        {
            // Lấy trực tiếp chiết khấu từ Đại Lý
            return _tongTienGoc - (_tongTienGoc * _daiLy.MucChietKhau);
        }
    }
}
