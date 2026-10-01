using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_ReplaceArrayWithObj.Services
{
    // THỰC TẾ:
    // Hệ thống tính điểm chuyên cần và hiệu suất phun thuốc của Kỹ Thuật Viên.
    // Nếu dùng mảng object[] { "Trần B", 20, 9.5 } thì rất dễ lỗi (nhầm thứ tự).
    // Ta bọc nó lại thành lớp HieuSuatKyThuatVien.

    public class HieuSuatKyThuatVien
    {
        public string TenKyThuatVien { get; set; }
        public int SoRuongDaPhun { get; set; }
        public double DiemDanhGia { get; set; } // Thang điểm 10

        public HieuSuatKyThuatVien(string ten, int soRuong, double diem)
        {
            TenKyThuatVien = ten;
            SoRuongDaPhun = soRuong;
            DiemDanhGia = diem;
        }

        public string DanhGiaXepLoai()
        {
            if (DiemDanhGia >= 9) return "Xuất Sắc";
            if (DiemDanhGia >= 7) return "Khá Tốt";
            return "Cần Cố Gắng";
        }
    }

    public class QuanLyBaoCaoReal
    {
        public void InBaoCaoThang()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                  BẢNG ĐÁNH GIÁ HIỆU SUẤT KỸ THUẬT VIÊN              ");
            Console.WriteLine("=======================================================================");
            
            // Thay vì dùng List<object[]> tối nghĩa, ta dùng List chứa các Object rõ ràng
            List<HieuSuatKyThuatVien> danhSachDanhGia = new List<HieuSuatKyThuatVien>
            {
                new HieuSuatKyThuatVien("Lê Trọng Đạt", 45, 9.2),
                new HieuSuatKyThuatVien("Phạm Minh Tiến", 30, 7.5),
                new HieuSuatKyThuatVien("Nguyễn Hữu Tài", 15, 6.0)
            };

            Console.WriteLine(String.Format("{0,-20} | {1,-15} | {2,-10} | {3,-15}", "Họ tên KTV", "Số ruộng phun", "Điểm số", "Xếp loại"));
            Console.WriteLine("-----------------------------------------------------------------------");

            foreach (var ktv in danhSachDanhGia)
            {
                Console.WriteLine(String.Format("{0,-20} | {1,-15} | {2,-10} | {3,-15}", 
                    ktv.TenKyThuatVien, ktv.SoRuongDaPhun, ktv.DiemDanhGia, ktv.DanhGiaXepLoai()));
            }
            Console.WriteLine("=======================================================================");
        }
    }
}
