using System;

namespace DPM235479_NguyenVanThang_DuplicateObserved.Services
{
    // THỰC TẾ:
    // Cảm biến nhiệt độ nhà màng Nông Dược.
    // Cảm biến (GUI/Sensor) ghi nhận nhiệt độ thay đổi.
    // Object Domain "NhietDoNhaMang" lưu trữ và phát Event.
    // Hai hệ thống khác nhau (Hệ thống Bơm Nước, Hệ thống Cảnh Báo SMS) cùng lắng nghe Event này.

    public class NhietDoDomain
    {
        private double _nhietDo;
        public event Action<double> NhietDoThayDoi;

        public double NhietDo
        {
            get => _nhietDo;
            set
            {
                _nhietDo = value;
                NhietDoThayDoi?.Invoke(_nhietDo); // Phát sóng (Broadcast)
            }
        }
    }

    public class CamBienNhietDoSensor
    {
        private NhietDoDomain _domain;
        public CamBienNhietDoSensor(NhietDoDomain domain) => _domain = domain;

        public void DocNhietDoMoi(double temp)
        {
            Console.WriteLine($"\n[CẢM BIẾN] Phát hiện nhiệt độ: {temp}°C");
            _domain.NhietDo = temp; // Đồng bộ (Duplicate Observed Data)
        }
    }

    public class QuanLyGiamSatReal
    {
        public void ChayHeThong()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("               HỆ THỐNG GIÁM SÁT NHIỆT ĐỘ (OBSERVER PATTERN)         ");
            Console.WriteLine("=======================================================================");
            
            // 1. Tạo Domain Object lưu dữ liệu
            NhietDoDomain domain = new NhietDoDomain();

            // 2. Các module Logic đăng ký lắng nghe (Subscribe)
            domain.NhietDoThayDoi += (temp) => {
                if (temp > 35) Console.WriteLine("   -> [MÁY BƠM]: Kích hoạt phun sương giảm nhiệt độ!");
            };
            domain.NhietDoThayDoi += (temp) => {
                if (temp > 40) Console.WriteLine("   -> [SMS ALARM]: Gửi tin nhắn khẩn cấp cho Kỹ sư trưởng!");
            };

            // 3. Sensor (GUI) hoạt động độc lập
            CamBienNhietDoSensor sensor = new CamBienNhietDoSensor(domain);
            
            // Mô phỏng nhiệt độ thay đổi
            sensor.DocNhietDoMoi(32); // Bình thường
            sensor.DocNhietDoMoi(36); // Kích hoạt máy bơm
            sensor.DocNhietDoMoi(41); // Kích hoạt cả máy bơm + SMS

            Console.WriteLine("=======================================================================");
        }
    }
}
