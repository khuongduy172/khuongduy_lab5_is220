using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeThi.Models
{
    public class ThietBiModel
    {
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public ICollection<NVBTModel> NVBTs { get; set; }
    }
}
