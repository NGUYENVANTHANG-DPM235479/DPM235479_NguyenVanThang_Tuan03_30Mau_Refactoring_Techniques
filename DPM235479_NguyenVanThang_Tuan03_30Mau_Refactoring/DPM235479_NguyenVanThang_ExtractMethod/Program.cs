using DPM235479_NguyenVanThang_ExtractMethod.Models;
using DPM235479_NguyenVanThang_ExtractMethod.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_ExtractMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. CHẠY THỬ MẪU TỔNG QUÁT LÝ THUYẾT (BEFORE & AFTER)
            Console.WriteLine("--- 1. DEMO REFACTORING LÝ THUYẾT ---");
            QuanLyHoaDonAfter serviceAfter = new QuanLyHoaDonAfter();
            serviceAfter.PrintReceipt("Nguyen Van A", 500000);

            Console.WriteLine("\n");

            // 2. CHẠY THỬ LỚP ÁP DỤNG THỰC TẾ VÀO ĐỒ ÁN CÔNG TY NÔNG DƯỢC AN GIANG[cite: 9]
            Console.WriteLine("--- 2. DEMO ÁP DỤNG THỰC TẾ ĐỒ ÁN NÔNG DƯỢC AN GIANG ---");

            HoaDon hoaDonNongDuoc = new HoaDon(
                maHD: "HD2026-AG01",
                tenKH: "Đại lý Vật tư Nông nghiệp An Phú",
                ngayLap: DateTime.Now,
                maNV: "NV01_NguyenVanThang",       // Nhân viên lập[cite: 10]
                chietKhau: 0.05,                   // Chiết khấu 5%[cite: 9]
                vanChuyen: 150000,                 // Phí vận chuyển phụ[cite: 9]
                dichVuPhu: 50000                   // Chi phí dịch vụ phụ[cite: 9]
            );

            // Thêm các sản phẩm nông dược bán theo lô và ngày hết hạn[cite: 9]
            hoaDonNongDuoc.DanhSachChiTiet.Add(new ChiTietHoaDon("ND01", "Thuốc trừ sâu Anagro", "LÔ-2026A", new DateTime(2027, 12, 31), 20, 85000));
            hoaDonNongDuoc.DanhSachChiTiet.Add(new ChiTietHoaDon("ND02", "Phân bón lá AG-Grow", "LÔ-2026B", new DateTime(2026, 11, 15), 10, 120000));

            QuanLyHoaDonReal serviceReal = new QuanLyHoaDonReal();
            serviceReal.XulyLapVaInHoaDon(hoaDonNongDuoc);

            Console.ReadLine();
        }
    }
}
