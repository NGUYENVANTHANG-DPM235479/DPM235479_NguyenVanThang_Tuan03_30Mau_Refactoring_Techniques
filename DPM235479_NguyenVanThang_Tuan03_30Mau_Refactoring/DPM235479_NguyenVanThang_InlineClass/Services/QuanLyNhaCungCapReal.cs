using DPM235479_NguyenVanThang_InlineClass.Models;
using System;

namespace DPM235479_NguyenVanThang_InlineClass.Services
{
    // THỰC TẾ: 
    // Trong công ty Nông Dược An Giang, hệ thống quản lý Đối Tác (DoiTacNongDuocReal)
    // trước đây có tạo riêng một lớp `DiaChiDoiTac`. 
    // Nhưng vì cả công ty chỉ quản lý đúng 1 chuỗi địa chỉ liên lạc duy nhất cho mỗi đối tác,
    // Việc phải gọi DoiTac.DiaChi.ThongTinDiaChi là dư thừa. 
    // => Mình áp dụng Inline Class dồn hết vào lớp Đối Tác.

    public class DoiTacNongDuocReal
    {
        public string TenCongTy { get; set; }
        public string LinhVucCungCap { get; set; }

        // INLINE CLASS: Gộp 2 field này từ class cũ DiaChiDoiTac
        public string DiaChiTruSo { get; set; }
        public string KhuVucGiaoHang { get; set; }

        public DoiTacNongDuocReal(string tenCongTy, string linhVuc, string diaChi, string khuVuc)
        {
            TenCongTy = tenCongTy;
            LinhVucCungCap = linhVuc;
            DiaChiTruSo = diaChi;
            KhuVucGiaoHang = khuVuc;
        }
    }

    public class QuanLyNhaCungCapReal
    {
        public void InBaoCaoHopDong(DoiTacNongDuocReal doiTac, SanPhamNhapKhau sanPham)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                      HỢP ĐỒNG NHẬP NGUYÊN LIỆU                      ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Bên cung cấp: {doiTac.TenCongTy}");
            Console.WriteLine($"Lĩnh vực cung cấp chính: {doiTac.LinhVucCungCap}");
            
            // Có thể truy xuất trực tiếp địa chỉ mà không qua lớp trung gian nào
            Console.WriteLine($"Trụ sở liên lạc: {doiTac.DiaChiTruSo}");
            Console.WriteLine($"Khu vực kho bãi nhận hàng: {doiTac.KhuVucGiaoHang}");
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"Đăng ký nhập khẩu mặt hàng: {sanPham.TenSanPham} (Loại: {sanPham.LoaiThuoc})");
            Console.WriteLine("=======================================================================");
        }
    }
}
