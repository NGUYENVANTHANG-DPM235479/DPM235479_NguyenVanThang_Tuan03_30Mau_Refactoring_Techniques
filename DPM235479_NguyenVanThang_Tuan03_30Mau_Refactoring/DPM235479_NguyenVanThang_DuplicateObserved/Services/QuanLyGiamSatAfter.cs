using System;

namespace DPM235479_NguyenVanThang_DuplicateObserved.Services
{
    // SAU KHI DUPLICATE OBSERVED DATA
    // Tách riêng Dữ liệu (Domain Object) ra khỏi Giao Diện (GUI).
    // Giao diện (GUI) và Domain Object sẽ được đồng bộ với nhau thông qua Sự kiện (Event/Observer).
    // Khi người dùng gõ vào GUI, GUI lập tức đẩy dữ liệu xuống Domain Object.
    // Domain Object tự động xử lý Logic mà không cần biết GUI là cái gì.

    // 1. TẠO RA DOMAIN OBJECT (Lớp dữ liệu nghiệp vụ riêng biệt)
    public class DuLieuSauBenhDomain
    {
        private int _mucDo;

        // Cơ chế Observer: Khai báo Event để lắng nghe sự thay đổi
        public delegate void DuLieuThayDoiHandler(int mucDoMoi);
        public event DuLieuThayDoiHandler OnDuLieuThayDoi;

        public int MucDoSauBenh
        {
            get { return _mucDo; }
            set 
            { 
                _mucDo = value; 
                // Khi có dữ liệu mới, tự động phát tín hiệu Event cho các bộ phận khác
                OnDuLieuThayDoi?.Invoke(_mucDo);
            }
        }
    }

    // 2. GIAO DIỆN CHỈ LÀM ĐÚNG NHIỆM VỤ CỦA GIAO DIỆN
    public class GiaoDienNhapLieuAfter
    {
        private DuLieuSauBenhDomain _domain;

        public GiaoDienNhapLieuAfter(DuLieuSauBenhDomain domain)
        {
            _domain = domain;
        }

        public void NguoiDungNhapDuLieu(int mucDo)
        {
            Console.WriteLine($"[GUI] Người dùng vừa gõ vào ô Textbox: {mucDo}");
            // Ném dữ liệu cho Domain, GUI không quan tâm logic tính thuốc nữa
            _domain.MucDoSauBenh = mucDo; 
        }
    }

    // 3. LOGIC XỬ LÝ LẮNG NGHE SỰ KIỆN (Không cần biết GUI)
    public class LogicNghiepVuAfter
    {
        public LogicNghiepVuAfter(DuLieuSauBenhDomain domain)
        {
            // Đăng ký (Observe) sự kiện của Domain
            domain.OnDuLieuThayDoi += (mucDo) => 
            {
                Console.WriteLine($"[LOGIC] Nhận được tín hiệu! Lượng thuốc cần phun: {mucDo * 2} Lít.");
            };
        }
    }
}
