using Lab4_04_10_2023.Data;
using Lab4_04_10_2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_04_10_2023.Controllers
{
    public class MyController : Controller
    {
        private readonly SchoolContext _schoolContext;

        public MyController(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            List<Course> courses = _schoolContext.Courses.ToList();
            return View(courses);
        }
    }
}
