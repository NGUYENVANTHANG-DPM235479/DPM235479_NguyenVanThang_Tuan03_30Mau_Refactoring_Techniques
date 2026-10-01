namespace DPM235479_NguyenVanThang_ReplaceTemp.Services
{
    public class QuanLyGiaBefore
    {
        private int _soLuong;
        private double _donGia;

        public QuanLyGiaBefore(int soLuong, double donGia)
        {
            _soLuong = soLuong;
            _donGia = donGia;
        }

        // TRƯỚC KHI REPLACE TEMP WITH QUERY
        // Có biến tạm basePrice được sử dụng nhiều lần để kiểm tra và tính toán.
        public double TinhTienThanhToan()
        {
            double basePrice = _soLuong * _donGia;
            if (basePrice > 50000000)
            {
                return basePrice * 0.90; // Chiết khấu 10% cho đơn trên 50 triệu
            }
            else
            {
                return basePrice * 0.95; // Chiết khấu 5%
            }
        }
    }
}
