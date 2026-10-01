using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_InlineMethod.Services
{
    public class QuanLyThongKeBefore
    {
        public bool KiemTraHopLe(DateTime ngay, DateTime tuNgay, DateTime denNgay)
        {
            return IsTrongKhoangThoiGian(ngay, tuNgay, denNgay);
        }

        // Hàm quá đơn giản chỉ chứa 1 dòng so sánh -> Cần INLINE METHOD
        private bool IsTrongKhoangThoiGian(DateTime ngay, DateTime tuNgay, DateTime denNgay)
        {
            return ngay >= tuNgay && ngay <= denNgay;
        }

        public double LayThucThu(double tong, double giam)
        {
            return TinhHieu(tong, giam);
        }

        // Hàm 1 dòng thừa thãi -> Cần INLINE METHOD
        private double TinhHieu(double a, double b)
        {
            return a - b;
        }
    }
}
