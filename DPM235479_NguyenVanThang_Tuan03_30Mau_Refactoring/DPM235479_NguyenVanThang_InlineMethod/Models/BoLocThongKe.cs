using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_InlineMethod.Models
{
    public class BoLocThongKe
    {
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string MaNhanVien { get; set; }

        public BoLocThongKe(DateTime tuNgay, DateTime denNgay, string maNV = null)
        {
            TuNgay = tuNgay;
            DenNgay = denNgay;
            MaNhanVien = maNV;
        }
    }
}
