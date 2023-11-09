using Lab4_04_10_2023.Data;
using Lab4_04_10_2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab4_04_10_2023.Controllers
{
    public class MyController : Controller
    {
        private int pageSize = 3;
        private SchoolContext db;
        public MyController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index(int? mid)
        {
            var learners = (IQueryable<Learner>)db.Learners.Include(m => m.Major);
            if(mid != null)
            {
                learners = (IQueryable<Learner>)db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major);
            }
            //tinh so trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            //tra ve so trang ve View de hien thi nav-trang
            ViewBag.PageNum = pageNum;
            //lay du lieu trang dau
            var result = learners.Take(pageSize).ToList();
            return View(result);
        }

        public IActionResult LearnerFilter(int? mid, string? keyword, int? pageIndex)
        {
            //lay toan bo learners trong dbset chuyen ve IQuerrable<Learner> de query
            var learners = (IQueryable<Learner>)db.Learners;
            //lay chi so trang, neu chi so trang null thi gan ngam dinh bang 1
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            //neu co mid thi loc leaner theo mid
            if(mid != null)
            {
                //loc
                learners = learners.Where(l => l.MajorID == mid);
                //gui mid ve view de ghi lai tren nav-phantrang
                ViewBag.mid = mid;
            }
            if(keyword != null)
            {
                //tim kiem
                learners = learners.Where(l => l.FirstMidName.ToLower().Contains(keyword.ToLower()));
                //gui keyword ve view de ghi tren nav-phantrang
                ViewBag.keyWord = keyword; 
            }
            //tinh so trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            //gui so trang ve view de ghi tren nav-phantrang
            ViewBag.pageNum = pageNum;
            //chon du lieu trong trang hien tai
            var result = learners.Skip(pageSize * (page - 1)).Take(pageSize).Include(m => m.Major);
            return PartialView("LearnerTable", result);
        }
        public IActionResult Create()
        {
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");  //cach2
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")]
            Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == 0 || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,
            [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound(id);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }
        private bool LearnerExists(int id)
        {
            return (db.Learners?.Any(e => e.LearnerID == id)).GetValueOrDefault();
        }
        public IActionResult Delete(int id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerID == id);
            if (learner == null)
            {
                return NotFound();
            }
            if (learner.Enrollments.Count > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }
            return View(learner);
        }

        // post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null");
            }
            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult LearnerByMajorID(int mid)
        {
            var learner = db.Learners
                .Where(l => l.MajorID == mid)
                .Include(m => m.Major).ToList();
            return PartialView("LearnerTable", learner);
        }
    }
}