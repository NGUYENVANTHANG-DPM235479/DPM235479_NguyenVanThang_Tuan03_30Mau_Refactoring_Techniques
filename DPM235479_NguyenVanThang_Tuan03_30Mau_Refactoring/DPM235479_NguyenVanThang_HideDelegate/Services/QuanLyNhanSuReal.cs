using System;

namespace DPM235479_NguyenVanThang_HideDelegate.Services
{
    // THỰC TẾ:
    // Hệ thống quản lý nông dược An Giang, khi xử lý hóa đơn, cần biết tên của Giám Đốc Khu Vực
    // mà Cửa Hàng (Store) đang trực thuộc.
    
    public class GiamDocKhuVuc
    {
        public string TenGiamDoc { get; set; }
        public GiamDocKhuVuc(string ten) => TenGiamDoc = ten;
    }

    public class KhuVucBanHang
    {
        public string TenKhuVuc { get; set; }
        public GiamDocKhuVuc GiamDoc { get; set; }

        public KhuVucBanHang(string tenKhuVuc, GiamDocKhuVuc giamDoc)
        {
            TenKhuVuc = tenKhuVuc;
            GiamDoc = giamDoc;
        }
    }

    public class CuaHangNongDuoc
    {
        public string TenCuaHang { get; set; }
        private KhuVucBanHang _khuVucTrucThuoc;

        public CuaHangNongDuoc(string tenCuaHang, KhuVucBanHang khuVuc)
        {
            TenCuaHang = tenCuaHang;
            _khuVucTrucThuoc = khuVuc;
        }

        // HIDE DELEGATE: Giấu KhuVucBanHang đi, Cửa Hàng tự cung cấp phương thức
        // trả về Tên Giám Đốc của nó.
        public string LayTenGiamDocPhuTrach()
        {
            if (_khuVucTrucThuoc != null && _khuVucTrucThuoc.GiamDoc != null)
                return _khuVucTrucThuoc.GiamDoc.TenGiamDoc;
            return "Không có thông tin";
        }
    }

    public class QuanLyNhanSuReal
    {
        public void InBaoCaoCuaHang(CuaHangNongDuoc ch)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                       BÁO CÁO CƠ CẤU CỬA HÀNG                       ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Cửa hàng: {ch.TenCuaHang}");
            
            // Chỗ này Client sử dụng rất sướng, chỉ cần gọi 1 hàm là ra thông tin,
            // không cần phải chọc ngoáy vào bên trong: ch.KhuVucTrucThuoc.GiamDoc.TenGiamDoc
            Console.WriteLine($"Giám đốc phụ trách chịu trách nhiệm: {ch.LayTenGiamDocPhuTrach()}");
            
            Console.WriteLine("=======================================================================");
        }
    }
}
