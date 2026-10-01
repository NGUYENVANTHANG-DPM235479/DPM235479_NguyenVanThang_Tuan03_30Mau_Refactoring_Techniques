using System;

namespace DPM235479_NguyenVanThang_IntroForeignMethod.Services
{
    // THỰC TẾ:
    // Hệ thống Nông Dược An Giang quy định: Hàng Nông Dược bị thu hồi (Recall) 
    // nếu như ngày hiện tại đã vượt qua 3 tháng tính từ Ngày Hết Hạn.
    // Việc tính toán "Ngày Hết Hạn Thu Hồi" đòi hỏi dùng DateTime, ta áp dụng Introduce Foreign Method.

    public class LoThuocTruSau
    {
        public string MaLo { get; set; }
        public DateTime NgayHetHanThuoc { get; set; }
        
        public LoThuocTruSau(string ma, DateTime ngayHetHan)
        {
            MaLo = ma;
            NgayHetHanThuoc = ngayHetHan;
        }
    }

    public class QuanLyThoiHanReal
    {
        // FOREIGN METHOD: Viết phương thức bổ trợ cho đối tượng DateTime
        public static DateTime TinhNgayKiemDinhThuHoi(DateTime ngayHetHanThuoc)
        {
            // Cộng thêm 3 tháng để xác định ngày bắt buộc phải thu hồi và tiêu hủy
            return ngayHetHanThuoc.AddMonths(3);
        }

        public void InBaoCaoKiemDinh(LoThuocTruSau loThuoc)
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                     BÁO CÁO KIỂM ĐỊNH THU HỒI LÔ                    ");
            Console.WriteLine("=======================================================================");
            
            Console.WriteLine($"Lô thuốc: {loThuoc.MaLo}");
            Console.WriteLine($"Ngày hết hạn sử dụng: {loThuoc.NgayHetHanThuoc.ToString("dd/MM/yyyy")}");
            
            // Tái sử dụng lại Foreign Method ở bất kì đâu một cách dễ dàng
            DateTime ngayThuHoi = TinhNgayKiemDinhThuHoi(loThuoc.NgayHetHanThuoc);
            
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"Hạn chót bắt buộc thu hồi khỏi đại lý: {ngayThuHoi.ToString("dd/MM/yyyy")}");
            
            if (DateTime.Now > ngayThuHoi)
            {
                Console.WriteLine("=> [CẢNH BÁO]: Lô thuốc đã quá hạn thu hồi, yêu cầu xử lý ngay!");
            }
            else
            {
                Console.WriteLine("=> [AN TOÀN]: Lô thuốc vẫn đang trong thời hạn lưu kho an toàn.");
            }
            Console.WriteLine("=======================================================================");
        }
    }
}
