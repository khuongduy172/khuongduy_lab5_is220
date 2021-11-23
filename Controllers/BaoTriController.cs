using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDeThi.Models;

namespace TestDeThi.Controllers
{
    public class BaoTriController : Controller
    {
        public IActionResult LocBaoTri()
        {
            return View();
        }

        public IActionResult LietKe(int solan)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(TestDeThi.Models.DataContext)) as DataContext;
            return View(context.sqlLocBaoTri(solan));
        }
        public IActionResult ChiTiet([FromQuery] string manv, [FromQuery] string matb, [FromQuery] string mach, [FromQuery] int lanthu)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(TestDeThi.Models.DataContext)) as DataContext;
            return View(context.sqlGetNVBTByKey(manv, matb, mach, lanthu));
        }

        [HttpGet]
        public IActionResult Delete([FromQuery] string manv, [FromQuery] string matb, [FromQuery] string mach, [FromQuery] int lanthu)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(TestDeThi.Models.DataContext)) as DataContext;
            int a = context.sqlDeleteBaotri(manv, matb, mach, lanthu);
            return View("Views/Home/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Update([FromQuery] string manv, [FromQuery] string matb, [FromQuery] string mach, [FromQuery] int lanthu1, string MaCanHo, int LanThu, DateTime NgayBaoTri)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(TestDeThi.Models.DataContext)) as DataContext;
            int a = context.sqlDeleteBaotri(manv, matb, mach, lanthu1);
            int b = context.sqlUpdateBaotri(manv, matb, MaCanHo, LanThu, NgayBaoTri);
            return View("Views/Home/Index.cshtml");
        }
    }
}
