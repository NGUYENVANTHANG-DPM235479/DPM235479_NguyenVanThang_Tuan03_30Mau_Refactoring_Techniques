using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ChangeValueToRef.Services
{
    // THỰC TẾ:
    // Hệ thống bán buôn Nông Dược. Khách hàng "Đại Lý Cấp 1 Tiền Giang" có thể có 500 cái Đơn Hàng.
    // Bỗng một ngày Đại Lý Cấp 1 này dời địa chỉ kho bãi.
    // Nhờ áp dụng Change Value to Reference (Dùng Factory), ta chỉ cần đổi địa chỉ đúng 1 lần,
    // toàn bộ 500 phiếu giao hàng (đang đợi giao) tự động cập nhật địa chỉ mới.

    public class DaiLyNongDuocReal
    {
        public string TenDaiLy { get; private set; }
        public string DiaChiKho { get; set; }

        internal DaiLyNongDuocReal(string ten) => TenDaiLy = ten;
    }

    public static class QuanLyDaiLyFactory
    {
        private static Dictionary<string, DaiLyNongDuocReal> _cacDaiLy = new Dictionary<string, DaiLyNongDuocReal>();

        public static DaiLyNongDuocReal GetDaiLy(string ten)
        {
            if (!_cacDaiLy.ContainsKey(ten))
                _cacDaiLy[ten] = new DaiLyNongDuocReal(ten);
            return _cacDaiLy[ten];
        }
    }

    public class PhieuGiaoHangReal
    {
        public string MaPhieu { get; set; }
        public DaiLyNongDuocReal DaiLyNhan { get; set; } // Reference

        public PhieuGiaoHangReal(string ma, string tenDaiLy)
        {
            MaPhieu = ma;
            DaiLyNhan = QuanLyDaiLyFactory.GetDaiLy(tenDaiLy);
        }
    }

    public class QuanLyKhachHangReal
    {
        public void ThuNghiemThayDoiDiaChi()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                 TEST: ĐỔI ĐỊA CHỈ TRÊN ĐỐI TƯỢNG REFERENCE          ");
            Console.WriteLine("=======================================================================");
            
            // Tạo 2 phiếu giao hàng cho CÙNG 1 Đại Lý
            PhieuGiaoHangReal phieu1 = new PhieuGiaoHangReal("PX-001", "Đại Lý Tiền Giang");
            PhieuGiaoHangReal phieu2 = new PhieuGiaoHangReal("PX-002", "Đại Lý Tiền Giang");
            
            // Cập nhật địa chỉ kho cho Đại Lý (thông qua phiếu 1)
            phieu1.DaiLyNhan.DiaChiKho = "Kho Mới - KCN Mỹ Tho";

            Console.WriteLine($"Phiếu 1 (PX-001) sẽ giao tới: {phieu1.DaiLyNhan.DiaChiKho}");
            
            // ĐIỀU KỲ DIỆU XẢY RA: Phiếu 2 tự động có địa chỉ mới mà ta không hề đụng tới nó!
            Console.WriteLine($"Phiếu 2 (PX-002) sẽ giao tới: {phieu2.DaiLyNhan.DiaChiKho}");
            
            Console.WriteLine("=> Kết luận: Cả 2 phiếu đều TRỎ (Reference) vào cùng 1 object Đại Lý duy nhất.");
            Console.WriteLine("=======================================================================");
        }
    }
}
