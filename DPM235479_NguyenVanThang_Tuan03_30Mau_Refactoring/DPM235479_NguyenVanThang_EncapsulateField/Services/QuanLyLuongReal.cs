using System;

namespace DPM235479_NguyenVanThang_EncapsulateField.Services
{
    // THỰC TẾ:
    // Nông dân đến Đại Lý để trả nợ một phần tiền phân bón.
    // Số Nợ (SoNo) phải được Encapsulate Field để kiểm soát 
    // không cho phép Nợ bị gán thành số âm (trả lố).

    public class HoNongDanReal
    {
        public string TenChuHo { get; set; }
        
        // Private field
        private double _tienNoDaiLy; 

        // Encapsulate Field
        public double TienNoDaiLy
        {
            get { return _tienNoDaiLy; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("=> [LỖI TÀI CHÍNH]: Số nợ không thể âm. Tiền thừa sẽ được thối lại, nợ bằng 0.");
                    _tienNoDaiLy = 0;
                }
                else
                {
                    _tienNoDaiLy = value;
                }
            }
        }

        public HoNongDanReal(string ten, double noBanDau)
        {
            TenChuHo = ten;
            TienNoDaiLy = noBanDau;
        }
    }

    public class QuanLyLuongReal
    {
        public void ThuTienNongDan()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("                  CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG                 ");
            Console.WriteLine("                      QUẢN LÝ THU HỒI CÔNG NỢ                        ");
            Console.WriteLine("=======================================================================");
            
            HoNongDanReal nongDan = new HoNongDanReal("Chú Tư Lúa", 5000000); // Nợ 5 triệu

            Console.WriteLine($"Nông dân: {nongDan.TenChuHo} - Đang nợ: {nongDan.TienNoDaiLy:N0} VNĐ");
            
            // Trả 2 triệu
            double tienTra = 2000000;
            Console.WriteLine($"\n[Giao Dịch 1] Chú Tư trả {tienTra:N0} VNĐ.");
            nongDan.TienNoDaiLy -= tienTra;
            Console.WriteLine($"-> Nợ còn lại: {nongDan.TienNoDaiLy:N0} VNĐ");

            // Trả 4 triệu (Đang nợ 3, trả 4 => Lố 1 triệu)
            double tienTraLan2 = 4000000;
            Console.WriteLine($"\n[Giao Dịch 2] Chú Tư trúng mùa, trả hẳn {tienTraLan2:N0} VNĐ.");
            
            // Nếu không Encapsulate, Nợ sẽ bị âm 1 triệu. 
            // Nhờ Encapsulate, Property sẽ tự cản lại và đưa Nợ về 0.
            nongDan.TienNoDaiLy -= tienTraLan2; 
            
            Console.WriteLine($"-> Nợ còn lại: {nongDan.TienNoDaiLy:N0} VNĐ");
            Console.WriteLine("=======================================================================");
        }
    }
}
