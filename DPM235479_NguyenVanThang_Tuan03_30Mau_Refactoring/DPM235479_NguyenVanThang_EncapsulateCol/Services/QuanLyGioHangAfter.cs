using DPM235479_NguyenVanThang_EncapsulateCol.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DPM235479_NguyenVanThang_EncapsulateCol.Services
{
    // SAU KHI ENCAPSULATE COLLECTION
    // Thay vì trả về bản gốc của List (để người ta tha hồ .Add, .Clear),
    // ta trả về một danh sách CHỈ ĐỌC (ReadOnlyCollection).
    // Nếu ai muốn Thêm hoặc Xóa đơn hàng, họ PHẢI dùng hàm ThemDonHang() hoặc XoaDonHang() 
    // mà ta cung cấp. Qua đó ta có quyền kiểm duyệt dữ liệu (Ví dụ: Đơn giá phải > 0 mới cho thêm).

    public class DaiLyAfter
    {
        public string TenDaiLy { get; set; }
        
        // 1. Giấu cái List gốc đi
        private List<DonHang> _danhSachDonHang;

        public DaiLyAfter(string ten)
        {
            TenDaiLy = ten;
            _danhSachDonHang = new List<DonHang>();
        }

        // 2. Trả về một List rỗng quyền lực (Read Only) để đọc
        public ReadOnlyCollection<DonHang> DanhSachDonHang
        {
            get { return _danhSachDonHang.AsReadOnly(); }
        }

        // 3. Cung cấp hàm Add để kiểm soát quyền Thêm
        public void ThemDonHang(DonHang don)
        {
            if (don.TriGia <= 0)
                throw new System.Exception("Trị giá đơn hàng phải lớn hơn 0");
            _danhSachDonHang.Add(don);
        }

        // 4. Cung cấp hàm Remove để kiểm soát quyền Xóa
        public void XoaDonHang(DonHang don)
        {
            _danhSachDonHang.Remove(don);
        }
    }

    public class QuanLyGioHangAfter
    {
        public void XyLyDonHang(DaiLyAfter daiLy)
        {
            // Client giờ phải thông qua hàm của Class cha, không thể tự ý .Add() vào List nữa
            daiLy.ThemDonHang(new DonHang("DH01", 500000));
            daiLy.ThemDonHang(new DonHang("DH02", 700000));
            
            // Nếu Client cố tình gọi daiLy.DanhSachDonHang.Add() thì Visual Studio sẽ báo lỗi Đỏ rực!
            // daiLy.DanhSachDonHang.Clear(); // => LỖI NGAY TỨC KHẮC
        }
    }
}
