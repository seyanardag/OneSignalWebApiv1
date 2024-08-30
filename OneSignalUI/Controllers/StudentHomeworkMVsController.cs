using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneSignalWebApiv1.Context;
using OneSignalWebApiv1.Entities;

namespace OneSignalUI.Controllers
{
    public class StudentHomeworkMVsController : Controller
    {
        private readonly OneSignalDbContext _context;

        public StudentHomeworkMVsController(OneSignalDbContext context)
        {
            _context = context;
        }

        // GET: StudentHomeworkMVs
        public async Task<IActionResult> Index()
        {
            var oneSignalDbContext = _context.StudentHomeworkMVs.Include(s => s.Homework).Include(s => s.Student);
            return View(await oneSignalDbContext.ToListAsync());
        }

        // GET: StudentHomeworkMVs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentHomeworkMV = await _context.StudentHomeworkMVs
                .Include(s => s.Homework)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentHomeworkMV == null)
            {
                return NotFound();
            }

            return View(studentHomeworkMV);
        }

        // GET: StudentHomeworkMVs/Create
        public IActionResult Create()
        {
            ViewData["HomeworkId"] = new SelectList(_context.Homeworks, "GUID", "HomeworkTitle");
            ViewData["StudentId"] = new SelectList(_context.Students, "GUID", "StudentName");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,HomeworkId")] StudentHomeworkMV studentHomeworkMV)
        {
            if (ModelState.IsValid)
            {
                var newitem = new StudentHomeworkMV();
                newitem.StudentId = studentHomeworkMV.StudentId;
                newitem.HomeworkId = studentHomeworkMV.HomeworkId;                

                _context.Add(newitem);
                await _context.SaveChangesAsync();

                // TODO: newitem.StudentId nolu öğrenciye "Yeni ödeviniz var" bildiriminin gönderilmesi

                return RedirectToAction(nameof(Index));
            }
            ViewData["HomeworkId"] = new SelectList(_context.Homeworks, "GUID", "HomeworkTitle", studentHomeworkMV.HomeworkId);
            ViewData["StudentId"] = new SelectList(_context.Students, "GUID", "StudentName", studentHomeworkMV.StudentId);
            return View(studentHomeworkMV);
        }

        // GET: StudentHomeworkMVs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentHomeworkMV = await _context.StudentHomeworkMVs.FindAsync(id);
            if (studentHomeworkMV == null)
            {
                return NotFound();
            }
            ViewData["HomeworkId"] = new SelectList(_context.Homeworks, "GUID", "HomeworkTitle", studentHomeworkMV.HomeworkId);
            ViewData["StudentId"] = new SelectList(_context.Students, "GUID", "StudentName", studentHomeworkMV.StudentId);
            return View(studentHomeworkMV);
        }

        // POST: StudentHomeworkMVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StudentId,HomeworkId")] StudentHomeworkMV studentHomeworkMV)
        {
            if (id != studentHomeworkMV.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentHomeworkMV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentHomeworkMVExists(studentHomeworkMV.StudentId))
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
            ViewData["HomeworkId"] = new SelectList(_context.Homeworks, "GUID", "HomeworkTitle", studentHomeworkMV.HomeworkId);
            ViewData["StudentId"] = new SelectList(_context.Students, "GUID", "StudentName", studentHomeworkMV.StudentId);
            return View(studentHomeworkMV);
        }

        // GET: StudentHomeworkMVs/Delete/5
        public async Task<IActionResult> Delete(string id, string id2 )
        {
            var studentId = Guid.Parse(id);
            var homeworkId= Guid.Parse(id2);

            if (studentId == null || homeworkId==null)
            {
                return NotFound();
            }

            var studentHomeworkMV = await _context.StudentHomeworkMVs
                .Include(s => s.Homework)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentId == studentId && m.HomeworkId == homeworkId);
            if (studentHomeworkMV == null)
            {
                return NotFound();
            }
            _context.StudentHomeworkMVs.Remove(studentHomeworkMV);
            await _context.SaveChangesAsync();

            //return View(studentHomeworkMV);
            return RedirectToAction("Index");
        }

        // POST: StudentHomeworkMVs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var studentHomeworkMV = await _context.StudentHomeworkMVs.FindAsync(id);
        //    if (studentHomeworkMV != null)
        //    {
        //        _context.StudentHomeworkMVs.Remove(studentHomeworkMV);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool StudentHomeworkMVExists(Guid id)
        {
            return _context.StudentHomeworkMVs.Any(e => e.StudentId == id);
        }
    }
}
