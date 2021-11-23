using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeThi.Models
{
    public class NhanVienModel
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public bool GioiTinh { get; set; }
        public ICollection<NVBTModel> NVBTs { get; set; }
    }
}
