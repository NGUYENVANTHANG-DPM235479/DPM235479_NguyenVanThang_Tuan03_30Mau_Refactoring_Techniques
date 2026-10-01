using DPM235479_NguyenVanThang_IntroLocalExt.Models;
using System;

namespace DPM235479_NguyenVanThang_IntroLocalExt.Services
{
    // SAU KHI INTRODUCE LOCAL EXTENSION
    // Vì DateTime là struct (không cho kế thừa), cách tốt nhất trong C# là
    // tạo một lớp Wrapper (Bao bọc) hoặc dùng Extension Methods.
    // Dưới đây là cách tạo một lớp Wrapper tên là `ThoiGianNongVu` 
    // để mở rộng tính năng cho DateTime.

    // LOCAL EXTENSION: Lớp mở rộng chuyên dụng cho Nông Vụ
    public class ThoiGianNongVu
    {
        private DateTime _thoiGianGoc; // Chứa đối tượng gốc bên trong

        public ThoiGianNongVu(DateTime thoiGianGoc)
        {
            _thoiGianGoc = thoiGianGoc;
        }

        public DateTime LayNgayGoc() => _thoiGianGoc;

        // Bổ sung hàng loạt tính năng mới mà DateTime không hề có
        public DateTime TinhNgayBonPhanLan1() => _thoiGianGoc.AddDays(7);
        public DateTime TinhNgayPhunThuoc() => _thoiGianGoc.AddDays(15);
        public DateTime TinhNgayThuHoachLuoNuoc() => _thoiGianGoc.AddDays(90);
    }

    public class QuanLyLichThoiVuAfter
    {
        public void LapKeHoachMuaVu(NhatKyDongRuong nhatKy)
        {
            // Bọc DateTime gốc vào Local Extension của chúng ta
            ThoiGianNongVu lich = new ThoiGianNongVu(nhatKy.NgayGieoSap);
            
            // Giờ đây Client sử dụng các tính năng mới cực kỳ dễ dàng
            Console.WriteLine($"Ngày bón phân: {lich.TinhNgayBonPhanLan1().ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Ngày phun thuốc: {lich.TinhNgayPhunThuoc().ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Ngày thu hoạch: {lich.TinhNgayThuHoachLuoNuoc().ToString("dd/MM/yyyy")}");
        }
    }
}
