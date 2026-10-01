using DPM235479_NguyenVanThang_SelfEncapsulate.Models;
using System;

namespace DPM235479_NguyenVanThang_SelfEncapsulate.Services
{
    // TRƯỚC KHI SELF ENCAPSULATE FIELD
    // Lớp DatNongNghiepBefore truy cập TRỰC TIẾP vào thuộc tính (field) _dienTichHa.
    // Nếu tương lai ta muốn thêm logic kiểm tra "Diện tích không được âm" 
    // thì ta phải đi sửa lại tất cả những chỗ có sử dụng _dienTichHa, rất dễ gây lỗi sót.

    public class DatNongNghiepBefore
    {
        private string _tenThuaRuong;
        private double _dienTichHa; // Field đang được xài trực tiếp

        public DatNongNghiepBefore(string ten, double dienTich)
        {
            _tenThuaRuong = ten;
            _dienTichHa = dienTich;
        }

        // Truy cập trực tiếp _dienTichHa
        public double TinhLuongPhanBon(NongDuoc phanBon)
        {
            return _dienTichHa * phanBon.LuongBaoCungCapTren1Ha;
        }

        // Truy cập trực tiếp _dienTichHa
        public void CapNhatDienTich(double themDienTich)
        {
            _dienTichHa += themDienTich; // Không có hàm chặn lỗi số âm
        }
    }
}
