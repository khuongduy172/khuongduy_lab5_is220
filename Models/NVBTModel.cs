using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeThi.Models
{
    public class NVBTModel
    {
        public string MaCanHo { get; set; }
        public string MaNhanVien { get; set; }
        public string MaThietBi { get; set; }
        public int LanThu { get; set; }
        public DateTime NgayBaoTri { get; set; }

        public CanHoModel CanHo { get; set; }
        public NhanVienModel NhanVien { get; set; }
        public ThietBiModel ThietBi { get; set; }
    }
}
