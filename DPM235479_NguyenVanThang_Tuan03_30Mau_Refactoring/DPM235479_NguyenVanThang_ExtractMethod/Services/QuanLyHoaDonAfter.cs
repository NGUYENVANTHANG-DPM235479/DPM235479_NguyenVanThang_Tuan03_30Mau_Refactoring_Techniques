using DPM235479_NguyenVanThang_ExtractMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235479_NguyenVanThang_ExtractMethod.Services
{
    public class QuanLyHoaDonAfter
    {
        public void PrintReceipt(string customerName, double amount)
        {
            PrintHeader();
            PrintDetails(customerName, amount);
        }

        private void PrintHeader()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("        HOA DON BAN HANG        ");
            Console.WriteLine("=================================");
        }

        private void PrintDetails(string customerName, double amount)
        {
            Console.WriteLine($"Khach hang: {customerName}");
            Console.WriteLine($"So tien: {amount:N0} VNĐ");
            Console.WriteLine("Cam on quy khach!");
        }
    }
}
