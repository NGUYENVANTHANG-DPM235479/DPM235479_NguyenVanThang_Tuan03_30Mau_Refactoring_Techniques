using System;

namespace DPM235479_NguyenVanThang_DuplicateObserved.Services
{
    // TRƯỚC KHI DUPLICATE OBSERVED DATA
    // Giả sử ta có một Giao Diện Người Dùng (GUI) nhập "Mức độ sâu bệnh" của ruộng.
    // Dữ liệu "Mức độ sâu bệnh" (domain data) lại bị MẮC KẸT bên trong cái Giao Diện.
    // Bất cứ khi nào phần mềm cần tính toán lượng thuốc trừ sâu, nó lại phải chọc vào Giao Diện
    // để lấy dữ liệu. Việc trộn lẫn GUI và Logic là điều cấm kỵ trong lập trình OOP.

    public class GiaoDienNhapLieuBefore
    {
        // Dữ liệu nghiệp vụ (Domain Data) lại nằm cứng trong GUI
        public int MucDoSauBenh_GUI_Field;

        public void NguoiDungNhapDuLieu(int mucDo)
        {
            MucDoSauBenh_GUI_Field = mucDo;
            Console.WriteLine($"[GUI] Đã nhận dữ liệu: {mucDo}");
            
            // GUI lại phải tự gọi Logic tính toán (Coupling quá chặt)
            LogicNghiepVuBefore logic = new LogicNghiepVuBefore();
            logic.TinhToanLuongThuoc(this);
        }
    }

    public class LogicNghiepVuBefore
    {
        public void TinhToanLuongThuoc(GiaoDienNhapLieuBefore gui)
        {
            // Logic phải chọc vào GUI để lấy dữ liệu
            int mucDo = gui.MucDoSauBenh_GUI_Field; 
            Console.WriteLine($"[LOGIC] Lượng thuốc cần phun: {mucDo * 2} Lít.");
        }
    }
}
