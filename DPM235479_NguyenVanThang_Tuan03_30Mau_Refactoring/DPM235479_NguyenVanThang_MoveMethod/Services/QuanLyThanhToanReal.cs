using System;
using System.Collections.Generic;

namespace DPM235479_NguyenVanThang_MoveMethod.Services
{
    // THỰC TẾ: Chuyển các hàm xử lý tính toán phí lưu kho từ lớp QuanLyKho 
    // sang chính lớp LoHang để phù hợp với nguyên lý hướng đối tượng.

    public class LoHangNongDuoc
    {
        public string MaLo { get; set; }
        public DateTime NgayNhapKho { get; set; }
        public int SoLuongThung { get; set; }
        public double PhiLuuKhoMoiThung { get; set; }

        // MOVE METHOD: Hàm tính phí được chuyển từ lớp QuanLyKho sang đây.
        public double TinhTongPhiLuuKho()
        {
            int soNgayLuu = (int)(DateTime.Now - NgayNhapKho).TotalDays;
            if (soNgayLuu < 0) soNgayLuu = 0; // Đề phòng ngày tương lai
            
            return soNgayLuu * SoLuongThung * PhiLuuKhoMoiThung;
        }
    }

    public class QuanLyThanhToanReal
    {
        public void InBaoCaoChiPhiLuuKho(List<LoHangNongDuoc> danhSachLoHang)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                   BÁO CÁO TỔNG CHI PHÍ LƯU KHO BÃI                  ");
            Console.WriteLine("=======================================================================");
            
            double tongCong = 0;

            foreach (var lo in danhSachLoHang)
            {
                // Thay vì tự tính toán (vi phạm Encapsulation), gọi hàm từ object
                double phiLuuKho = lo.TinhTongPhiLuuKho();
                tongCong += phiLuuKho;
                
                Console.WriteLine($"Mã lô hàng: {lo.MaLo, -10} | Phí phải trả: {phiLuuKho:N0} VNĐ");
            }

            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"TỔNG CỘNG TOÀN BỘ KHO: {tongCong:N0} VNĐ");
            Console.WriteLine("=======================================================================");
        }
    }
}
