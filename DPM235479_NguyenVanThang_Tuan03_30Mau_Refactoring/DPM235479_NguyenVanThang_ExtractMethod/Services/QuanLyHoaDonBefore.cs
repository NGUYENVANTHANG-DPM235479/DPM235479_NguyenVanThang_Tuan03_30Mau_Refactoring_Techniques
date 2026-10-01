using DPM235479_NguyenVanThang_ExtractMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_ExtractMethod.Services
{
    public class QuanLyHoaDonBefore
    {
        public void PrintReceipt(string customerName, double amount)
        {
            // In banner
            Console.WriteLine("=================================");
            Console.WriteLine("        HOA DON BAN HANG        ");
            Console.WriteLine("=================================");

            // In thông tin
            Console.WriteLine($"Khach hang: {customerName}");
            Console.WriteLine($"So tien: {amount:N0} VNĐ");
            Console.WriteLine("Cam on quy khach!");
        }
    }
}
