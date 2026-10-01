using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_InlineMethod.Services
{
    public class QuanLyThongKeAfter
    {
        public bool KiemTraHopLe(DateTime ngay, DateTime tuNgay, DateTime denNgay)
        {
            // Đã INLINE biểu thức kiểm tra khoảng thời gian
            return ngay >= tuNgay && ngay <= denNgay;
        }

        public double LayThucThu(double tong, double giam)
        {
            // Đã INLINE phép tính
            return tong - giam;
        }
    }
}
