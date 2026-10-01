using DPM235479_NguyenVanThang_SelfEncapsulate.Models;
using System;

namespace DPM235479_NguyenVanThang_SelfEncapsulate.Services
{
    // THỰC TẾ:
    // Căn chỉnh số lượng Thuốc trừ sâu cần dùng cho một Thửa ruộng.
    // Lượng thuốc tồn kho (TonKhoLuuTru) cần được Self-Encapsulate 
    // để mỗi lần xài thuốc, ta có thể tự động ghi Log hoặc phát cảnh báo sắp hết hàng.

    public class KhoThuocReal
    {
        public string LoaiThuoc { get; set; }
        private double _soLuongTonKho; // Lít

        // SELF ENCAPSULATE
        public double SoLuongTonKho
        {
            get { return _soLuongTonKho; }
            set 
            {
                _soLuongTonKho = value;
                // Nhờ đóng gói, ta dễ dàng chèn thêm tính năng Cảnh Báo vào Setter!
                if (_soLuongTonKho < 10)
                {
                    Console.WriteLine($"[CẢNH BÁO KHO]: Thuốc {LoaiThuoc} sắp hết, chỉ còn {_soLuongTonKho} Lít. Cần nhập thêm!");
                }
            }
        }

        public KhoThuocReal(string thuoc, double soLuongBanDau)
        {
            LoaiThuoc = thuoc;
            SoLuongTonKho = soLuongBanDau;
        }

        public void XuatKhoPhunThuoc(double luongCanDung)
        {
            if (luongCanDung > SoLuongTonKho) // Dùng Getter
            {
                Console.WriteLine("=> [LỖI]: Kho không đủ thuốc để xuất!");
                return;
            }
            
            // Dùng Setter (nếu sau khi trừ mà số dư < 10, Setter sẽ tự in cảnh báo)
            SoLuongTonKho -= luongCanDung; 
            
            Console.WriteLine($"=> Đã xuất {luongCanDung} Lít. Tồn kho hiện tại: {SoLuongTonKho} Lít.");
        }
    }

    public class QuanLyDatReal
    {
        public void ThucThi()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                       XUẤT KHO THUỐC BẢO VỆ                         ");
            Console.WriteLine("=======================================================================");
            
            KhoThuocReal kho = new KhoThuocReal("Thuốc diệt cỏ ABC", 20);
            
            // Xuất 5 lít, còn 15
            kho.XuatKhoPhunThuoc(5); 
            
            Console.WriteLine("-----------------------------------------------------------------------");
            
            // Xuất tiếp 8 lít, còn 7 (sẽ kích hoạt cảnh báo từ Setter)
            kho.XuatKhoPhunThuoc(8); 
            
            Console.WriteLine("=======================================================================");
        }
    }
}
