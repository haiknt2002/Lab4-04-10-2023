using Lab4_04_10_2023.Data;
using Lab4_04_10_2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4_04_10_2023.Controllers
{
    public class MyController : Controller
    {
        private SchoolContext db;
        public MyController(SchoolContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }
    }
}
