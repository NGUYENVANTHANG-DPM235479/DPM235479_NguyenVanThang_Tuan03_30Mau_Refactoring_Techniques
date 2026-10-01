namespace DPM235479_NguyenVanThang_EncapsulateCol.Models
{
    // Mô hình cho bài toán Encapsulate Collection
    public class DonHang
    {
        public string MaDonHang { get; set; }
        public double TriGia { get; set; }

        public DonHang(string ma, double gia)
        {
            MaDonHang = ma;
            TriGia = gia;
        }
    }
}
