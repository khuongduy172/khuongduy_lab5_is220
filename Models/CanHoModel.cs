using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeThi.Models
{
    public class CanHoModel
    {
        public string MaCanHo { get; set; }
        public string TenChuHo { get; set; }

        public ICollection<NVBTModel> NVBTs { get; set; }
    }
}
