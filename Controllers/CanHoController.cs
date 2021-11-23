using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDeThi.Models;

namespace TestDeThi.Controllers
{
    public class CanHoController : Controller
    {
        public IActionResult ThemCanHo()
        {
            return View();
        }

        [HttpPost]
        public string AddCH (CanHoModel canho)
        {
            int count;
            DataContext context = HttpContext.RequestServices.GetService(typeof(TestDeThi.Models.DataContext)) as DataContext;
            count = context.sqlThemCH(canho);
            if (count == 1)
                return "Thêm Thành Công!";
            else
                return "Thêm Thất Bại!!!";
        }
    }
}
