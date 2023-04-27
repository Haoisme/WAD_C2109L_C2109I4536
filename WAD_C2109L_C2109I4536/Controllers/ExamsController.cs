using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WAD_C2109L_C2109I4536.Models;
using X.PagedList;


namespace WAD_C2109L_C2109I4536.Controllers
{
    public class ExamsController : Controller
    {
        int pageSize = 3;

        private readonly DataContext _context;

        public ExamsController(DataContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index(string search,int? subjectId,int? page = 1  ) 
        {

            var exams = _context.Exams.Include(e => e.Student).Include(e => e.Subject).Select(x => x);
            if(!string.IsNullOrEmpty(search))
                exams= exams.Where(x=> x.Student.StudentName.Contains(search));
            if (subjectId.HasValue && subjectId.Value>0)
                exams = exams.Where(x => x.Subject.SubjectId == subjectId.Value);
            var subjects = _context.Subjects.ToList();
            subjects.Insert(0, new Subject { SubjectId = 0, SubjectName = "All Subject" });
            ViewData["Subjects"] = new SelectList(subjects, "SubjectId", "SubjectName", subjectId);
            ViewData["Search"] = search;
            ViewData["SubjectId"] = subjectId;
            return View(await exams.ToPagedListAsync(page,pageSize));
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId== null ||  _context.Exams == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(m => m.StudentId == studentId && m.SubjectId== subjectId);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,SubjectId,Mark")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", exam.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        [Authorize]
        public IActionResult Edit(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null || _context.Exams == null)
            {
                return NotFound();

            }

            var exam = _context.Exams.FirstOrDefault(m => m.SubjectId == subjectId && m.StudentId == studentId);
            if (exam == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", exam.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", exam.SubjectId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,SubjectId,Mark")] Exam exam)
        {
            if (id != exam.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.StudentId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", exam.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null || _context.Exams == null)
            {
                return NotFound();

            }

            var exam = await _context.Exams
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(m => m.StudentId == studentId && m.SubjectId==subjectId);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exams == null)
            {
                return Problem("Entity set 'DataContext.Exams'  is null.");
            }
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
          return (_context.Exams?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
