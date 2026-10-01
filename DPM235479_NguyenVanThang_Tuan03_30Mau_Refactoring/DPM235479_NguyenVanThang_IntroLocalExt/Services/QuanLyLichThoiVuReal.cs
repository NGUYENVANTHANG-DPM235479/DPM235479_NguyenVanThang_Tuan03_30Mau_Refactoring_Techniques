using System;

namespace DPM235479_NguyenVanThang_IntroLocalExt.Services
{
    // THỰC TẾ:
    // Áp dụng Local Extension theo phong cách hiện đại của C# (Extension Method).
    // Kỹ thuật này giúp ta gọi trực tiếp các hàm nông nghiệp ngay trên biến kiểu DateTime.
    
    // ĐÂY LÀ LOCAL EXTENSION (MỞ RỘNG CỤC BỘ)
    public static class DateTimeNongNghiepExtension
    {
        // Chữ 'this' biến hàm này thành hàm mở rộng của kiểu DateTime
        public static string XacDinhMuaVu(this DateTime dt)
        {
            int thang = dt.Month;
            if (thang >= 2 && thang <= 4) return "Vụ Đông Xuân";
            if (thang >= 5 && thang <= 8) return "Vụ Hè Thu";
            if (thang >= 9 && thang <= 11) return "Vụ Thu Đông";
            return "Vụ Mùa Phụ";
        }

        public static DateTime TinhNgayCachLyAnToan(this DateTime ngayPhun, int soNgayCachLy)
        {
            return ngayPhun.AddDays(soNgayCachLy);
        }
    }

    public class PhunThuocBVTV
    {
        public string TenThuoc { get; set; }
        public int ThoiGianCachLy { get; set; } // Tính bằng ngày
    }

    public class QuanLyLichThoiVuReal
    {
        public void InBaoCaoPhunThuoc(PhunThuocBVTV thuoc, DateTime ngayThucHien)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                       BÁO CÁO PHUN THUỐC BVTV                       ");
            Console.WriteLine("=======================================================================");
            
            // Nhờ Local Extension, ta gọi thẳng .XacDinhMuaVu() từ kiểu DateTime
            Console.WriteLine($"Thời điểm phun thuốc: {ngayThucHien.ToString("dd/MM/yyyy")} (Thuộc {ngayThucHien.XacDinhMuaVu()})");
            Console.WriteLine($"Sử dụng hóa chất: {thuoc.TenThuoc}");
            
            // Gọi thẳng .TinhNgayCachLyAnToan()
            DateTime ngayAnToan = ngayThucHien.TinhNgayCachLyAnToan(thuoc.ThoiGianCachLy);
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"YÊU CẦU: Phải cách ly đến ngày {ngayAnToan.ToString("dd/MM/yyyy")} mới được thu hoạch.");
            Console.WriteLine("=======================================================================");
        }
    }
}
