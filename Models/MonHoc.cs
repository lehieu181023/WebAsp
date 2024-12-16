using System.ComponentModel.DataAnnotations;

namespace WebAsp.Models
{
    public class qlmonhoc
    {
        [Key]
        public int MAMH { get; set; }

        public int TENMH { get; set; }

        public int SOTINCHI { get; set; }
    }
}
