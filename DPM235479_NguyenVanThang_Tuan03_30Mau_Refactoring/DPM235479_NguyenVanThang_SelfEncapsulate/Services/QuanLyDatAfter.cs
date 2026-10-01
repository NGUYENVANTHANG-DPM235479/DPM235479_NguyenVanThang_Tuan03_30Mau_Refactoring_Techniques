using DPM235479_NguyenVanThang_SelfEncapsulate.Models;
using System;

namespace DPM235479_NguyenVanThang_SelfEncapsulate.Services
{
    // SAU KHI SELF ENCAPSULATE FIELD
    // Ta tự tạo Property Getter/Setter (hoặc hàm Get/Set) cho field _dienTichHa.
    // Và quan trọng nhất: CÁC HÀM BÊN TRONG CLASS CŨNG PHẢI GỌI QUA GETTER/SETTER NÀY, 
    // chứ không được phép chọc trực tiếp vào _dienTichHa nữa.

    public class DatNongNghiepAfter
    {
        private string _tenThuaRuong;
        private double _dienTichHa;

        // TỰ ĐÓNG GÓI CHÍNH MÌNH (Self Encapsulate)
        public double DienTichHa
        {
            get { return _dienTichHa; }
            set 
            { 
                if (value < 0) 
                    throw new ArgumentException("Diện tích đất nông nghiệp không được nhỏ hơn 0.");
                _dienTichHa = value; 
            }
        }

        public DatNongNghiepAfter(string ten, double dienTich)
        {
            _tenThuaRuong = ten;
            DienTichHa = dienTich; // Dùng Setter (Encapsulated)
        }

        public double TinhLuongPhanBon(NongDuoc phanBon)
        {
            // Dùng Getter (DienTichHa) thay vì dùng _dienTichHa trực tiếp
            return DienTichHa * phanBon.LuongBaoCungCapTren1Ha;
        }

        public void CapNhatDienTich(double themDienTich)
        {
            // Dùng Getter và Setter. Nếu số âm, Setter sẽ chặn lại!
            DienTichHa = DienTichHa + themDienTich; 
        }
    }
}
