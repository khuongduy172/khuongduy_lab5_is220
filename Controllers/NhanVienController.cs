using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDeThi.Models;

namespace TestDeThi.Controllers
{
    public class NhanVienController : Controller
    {
        public IActionResult Index()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(TestDeThi.Models.DataContext)) as DataContext;
            return View(context.sqlListNhanVien());
        }

        public IActionResult LietKe(string manhanvien)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(TestDeThi.Models.DataContext)) as DataContext;
            return View(context.sqlListNVBT(manhanvien));
        }
    }
}
