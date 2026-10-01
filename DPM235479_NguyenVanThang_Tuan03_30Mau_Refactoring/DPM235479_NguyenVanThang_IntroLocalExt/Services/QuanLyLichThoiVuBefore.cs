using DPM235479_NguyenVanThang_IntroLocalExt.Models;
using System;

namespace DPM235479_NguyenVanThang_IntroLocalExt.Services
{
    // TRƯỚC KHI INTRODUCE LOCAL EXTENSION
    // Ta đang xài thư viện DateTime. Tuy nhiên trong nông nghiệp, ta cần RẤT NHIỀU hàm phụ trợ
    // như: TinhNgayBonPhan, TinhNgayPhunThuoc, TinhNgayThuHoach...
    // Nếu dùng "Foreign Method", ta sẽ làm phình to class QuanLyLichThoiVuBefore này một cách đáng sợ.

    public class QuanLyLichThoiVuBefore
    {
        public void LapKeHoachMuaVu(NhatKyDongRuong nhatKy)
        {
            DateTime ngayGieo = nhatKy.NgayGieoSap;
            
            // Lại phải tự viết logic cộng ngày ở đây
            DateTime ngayBonPhanLan1 = ngayGieo.AddDays(7);
            DateTime ngayPhunThuocSND = ngayGieo.AddDays(15);
            DateTime ngayThuHoach = ngayGieo.AddDays(90);

            Console.WriteLine($"Ngày bón phân: {ngayBonPhanLan1.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Ngày phun thuốc: {ngayPhunThuocSND.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Ngày thu hoạch: {ngayThuHoach.ToString("dd/MM/yyyy")}");
        }
        
        // Nếu dùng Foreign Method thì phải viết cả chục hàm như vầy ở đây => Class rất lộn xộn.
        // private DateTime TinhNgayBonPhan(DateTime d) { ... }
        // private DateTime TinhNgayPhunThuoc(DateTime d) { ... }
    }
}
