namespace DPM235479_NguyenVanThang_ReplaceTemp.Services
{
    public class QuanLyGiaAfter
    {
        private int _soLuong;
        private double _donGia;

        public QuanLyGiaAfter(int soLuong, double donGia)
        {
            _soLuong = soLuong;
            _donGia = donGia;
        }

        // SAU KHI REPLACE TEMP WITH QUERY
        // Biến tạm được thay bằng lời gọi hàm (Query method) BasePrice().
        // Giúp phương thức TinhTienThanhToan gọn hơn và BasePrice() có thể được tái sử dụng ở nơi khác.
        public double TinhTienThanhToan()
        {
            if (BasePrice() > 50000000)
            {
                return BasePrice() * 0.90;
            }
            else
            {
                return BasePrice() * 0.95;
            }
        }

        private double BasePrice()
        {
            return _soLuong * _donGia;
        }
    }
}
