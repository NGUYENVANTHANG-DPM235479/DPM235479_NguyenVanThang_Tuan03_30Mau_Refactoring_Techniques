using System;

namespace DPM235479_NguyenVanThang_ChangeRefToValue.Services
{
    // THỰC TẾ:
    // So sánh đồng tiền thanh toán của Khách Hàng nước ngoài và trong nước.
    // Dù tạo bằng toán tử 'new' 2 lần khác nhau (khác vùng nhớ RAM),
    // nhưng nhờ kỹ thuật Change Ref To Value (Override Equals), 
    // máy tính vẫn biết đó là cùng một loại tiền tệ.

    public class DonViTienTeReal
    {
        public string Code { get; private set; }

        public DonViTienTeReal(string code) => Code = code;

        public override bool Equals(object obj)
        {
            if (obj is DonViTienTeReal other)
                return this.Code == other.Code;
            return false;
        }

        public override int GetHashCode() => Code.GetHashCode();
    }

    public class GiaoDichNongDuoc
    {
        public string TenGiaoDich { get; set; }
        public DonViTienTeReal TienTeThanhToan { get; set; }

        public GiaoDichNongDuoc(string ten, string maTien)
        {
            TenGiaoDich = ten;
            TienTeThanhToan = new DonViTienTeReal(maTien); // Thoải mái new
        }
    }

    public class QuanLyTienTeReal
    {
        public void KiemTraTienTe()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                KIỂM TRA GIAO DỊCH (VALUE OBJECT BẤT BIẾN)           ");
            Console.WriteLine("=======================================================================");
            
            // Hai giao dịch này tự 'new' ra 2 object tiền tệ khác nhau
            GiaoDichNongDuoc gd1 = new GiaoDichNongDuoc("Mua phân bón", "VND");
            GiaoDichNongDuoc gd2 = new GiaoDichNongDuoc("Thuốc trừ sâu", "VND");

            Console.WriteLine($"Giao dịch 1 trả bằng: {gd1.TienTeThanhToan.Code}");
            Console.WriteLine($"Giao dịch 2 trả bằng: {gd2.TienTeThanhToan.Code}");
            
            Console.WriteLine("-----------------------------------------------------------------------");
            
            // Dù là 2 object được 'new' độc lập, nhưng Equals đã được ghi đè
            bool cungLoaiTien = gd1.TienTeThanhToan.Equals(gd2.TienTeThanhToan);
            
            if (cungLoaiTien)
            {
                Console.WriteLine("=> HỆ THỐNG: Hai giao dịch sử dụng CÙNG một loại tiền tệ (Đúng như mong đợi).");
            }
            else
            {
                Console.WriteLine("=> HỆ THỐNG: Khác loại tiền tệ.");
            }
            Console.WriteLine("=======================================================================");
        }
    }
}
