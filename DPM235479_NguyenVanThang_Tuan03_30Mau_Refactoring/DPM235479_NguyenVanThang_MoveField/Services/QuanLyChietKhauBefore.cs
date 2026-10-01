using DPM235479_NguyenVanThang_MoveField.Models;
using System;

namespace DPM235479_NguyenVanThang_MoveField.Services
{
    // TRƯỚC KHI MOVE FIELD
    // Thuộc tính _mucChietKhau (Mức chiết khấu) đang được đặt ở lớp HoaDonBanHang
    // Tuy nhiên, chiết khấu lại phụ thuộc hoàn toàn vào Đại lý (DaiLy) mua hàng
    // và thường được tính toán khi lập danh sách chiết khấu, dẫn tới việc truyền _mucChietKhau rất bất tiện.

    public class HoaDonBanHangBefore
    {
        private DaiLy _daiLy;
        private double _mucChietKhau; // Thuộc tính đang ở nhầm chỗ
        private double _tongTienGoc;

        public HoaDonBanHangBefore(DaiLy daiLy, double mucChietKhau, double tongTienGoc)
        {
            _daiLy = daiLy;
            _mucChietKhau = mucChietKhau;
            _tongTienGoc = tongTienGoc;
        }

        public double TinhTienPhaiTra()
        {
            return _tongTienGoc - (_tongTienGoc * _mucChietKhau);
        }
    }
}
