

namespace WebAsp.Models
{
    public class SinhVien
    {

        public int IdSinhVien { get; set; }
        public string? HoTen { get; set; }
        public string? KhoaHoc { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public float? TBCHT { get; set; }
        public string? Xeploai { get; set; }
        public string? IdNganh { get; set; }

        public SinhVien() { }
    }
}
