using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeBiToUni.Services
{
    // THỰC TẾ:
    // Đại Lý Phân Phối và Hợp Đồng.
    // Một Đại Lý có nhiều Hợp Đồng. Hợp đồng chỉ là tờ giấy vô tri (chỉ lưu mã), 
    // không cần thiết phải "nhớ" thông tin Đại Lý.
    // Ta xóa liên kết ngược để giảm thiểu rác bộ nhớ (Memory Leak).

    public class HopDongNongDuocReal
    {
        public string MaHopDong { get; set; }
        // Đã xóa liên kết ngược về Đại Lý
        
        public HopDongNongDuocReal(string ma)
        {
            MaHopDong = ma;
        }
    }

    public class DaiLyPhanPhoiReal
    {
        public string TenDaiLy { get; set; }
        private List<HopDongNongDuocReal> _danhSachHopDong = new List<HopDongNongDuocReal>();

        public DaiLyPhanPhoiReal(string ten)
        {
            TenDaiLy = ten;
        }

        public void KyKetHopDong(HopDongNongDuocReal hd)
        {
            _danhSachHopDong.Add(hd); // Chỉ lưu 1 chiều
        }

        public void HienThiHopDong()
        {
            Console.WriteLine($"Đại lý [{TenDaiLy}] đang giữ các hợp đồng:");
            foreach(var hd in _danhSachHopDong)
            {
                Console.WriteLine($"- {hd.MaHopDong}");
            }
        }
    }

    public class QuanLyDonHangReal
    {
        public void ThuNghiemMotChieu()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("               CHUYỂN LIÊN KẾT 2 CHIỀU THÀNH 1 CHIỀU                 ");
            Console.WriteLine("=======================================================================");
            
            DaiLyPhanPhoiReal daiLy = new DaiLyPhanPhoiReal("Đại Lý Cấp 1 Tiền Giang");
            
            // Hợp đồng đứng độc lập
            HopDongNongDuocReal hd1 = new HopDongNongDuocReal("HD-2024-001");
            HopDongNongDuocReal hd2 = new HopDongNongDuocReal("HD-2024-002");

            daiLy.KyKetHopDong(hd1);
            daiLy.KyKetHopDong(hd2);

            daiLy.HienThiHopDong();
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("=> Hợp Đồng hiện tại là đối tượng Độc Lập, không chứa tham chiếu về Đại Lý.");
            Console.WriteLine("=> Tránh được lỗi rò rỉ bộ nhớ (Memory Leak) do Circular Reference.");
            Console.WriteLine("=======================================================================");
        }
    }
}
