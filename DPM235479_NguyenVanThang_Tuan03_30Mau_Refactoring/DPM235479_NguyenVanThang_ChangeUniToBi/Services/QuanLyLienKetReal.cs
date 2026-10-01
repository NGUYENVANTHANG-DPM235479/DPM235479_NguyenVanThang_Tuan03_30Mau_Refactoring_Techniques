using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeUniToBi.Services
{
    // THỰC TẾ:
    // Quản lý Đại Lý Phân Phối và Nông Dân.
    // Một Đại Lý có nhiều Nông Dân đăng ký mua nợ.
    // Đồng thời, khi đi thu tiền một Nông Dân (đang ở ngoài đồng), nhân viên chỉ biết Nông Dân đó,
    // và cần phải truy ngược ra Đại Lý để báo cáo doanh thu.
    // Bắt buộc phải dùng Liên Kết 2 Chiều.

    public class NongDanReal
    {
        public string TenNongDan { get; set; }
        public DaiLyReal DaiLyBaoLanh { get; private set; } // Liên kết ngược

        public NongDanReal(string ten) => TenNongDan = ten;

        internal void DatDaiLy(DaiLyReal dl) => DaiLyBaoLanh = dl;
    }

    public class DaiLyReal
    {
        public string TenDaiLy { get; set; }
        private List<NongDanReal> _dsNongDan = new List<NongDanReal>();

        public DaiLyReal(string ten) => TenDaiLy = ten;

        public void DangKyNongDan(NongDanReal nd)
        {
            _dsNongDan.Add(nd);
            nd.DatDaiLy(this); // Thiết lập 2 chiều
        }
    }

    public class QuanLyLienKetReal
    {
        public void ThuNghiemHaiChieu()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                  QUẢN LÝ LIÊN KẾT ĐẠI LÝ - NÔNG DÂN                 ");
            Console.WriteLine("=======================================================================");
            
            DaiLyReal daiLy = new DaiLyReal("Đại Lý Hữu Trí - Long Xuyên");
            NongDanReal nongDan1 = new NongDanReal("Chú Sáu");
            NongDanReal nongDan2 = new NongDanReal("Anh Bảy");

            // Đăng ký 1 chiều từ Đại Lý
            daiLy.DangKyNongDan(nongDan1);
            daiLy.DangKyNongDan(nongDan2);

            // THỬ NGHIỆM CHIỀU NGƯỢC LẠI
            // Nếu chỉ có 1 chiều, ta sẽ không thể gọi nongDan1.DaiLyBaoLanh
            Console.WriteLine($"Nông dân: {nongDan1.TenNongDan}");
            Console.WriteLine($"=> Chịu sự quản lý của (truy xuất ngược): {nongDan1.DaiLyBaoLanh.TenDaiLy}");
            
            Console.WriteLine("-----------------------------------------------------------------------");
            
            Console.WriteLine($"Nông dân: {nongDan2.TenNongDan}");
            Console.WriteLine($"=> Chịu sự quản lý của (truy xuất ngược): {nongDan2.DaiLyBaoLanh.TenDaiLy}");
            
            Console.WriteLine("=======================================================================");
        }
    }
}
