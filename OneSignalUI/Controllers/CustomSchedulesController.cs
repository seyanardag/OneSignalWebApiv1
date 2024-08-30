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
    public class CustomSchedulesController : Controller
    {
        private readonly OneSignalDbContext _context;

        public CustomSchedulesController(OneSignalDbContext context)
        {
            _context = context;
        }

        // GET: CustomSchedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomSchedules.ToListAsync());
        }

        // GET: CustomSchedules/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customSchedule = await _context.CustomSchedules
                .FirstOrDefaultAsync(m => m.GUID == id);
            if (customSchedule == null)
            {
                return NotFound();
            }

            return View(customSchedule);
        }

        // GET: CustomSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonName,ScheduleDate,GUID,CREATEDDATE,CREATEDTIME")] CustomSchedule customSchedule)
        {
            if (ModelState.IsValid)
            {
                customSchedule.GUID = Guid.NewGuid();
                _context.Add(customSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customSchedule);
        }

        // GET: CustomSchedules/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customSchedule = await _context.CustomSchedules.FindAsync(id);
            if (customSchedule == null)
            {
                return NotFound();
            }
            return View(customSchedule);
        }

        // POST: CustomSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("LessonName,ScheduleDate,GUID,CREATEDDATE,CREATEDTIME")] CustomSchedule customSchedule)
        {
            if (id != customSchedule.GUID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomScheduleExists(customSchedule.GUID))
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
            return View(customSchedule);
        }

        // GET: CustomSchedules/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customSchedule = await _context.CustomSchedules
                .FirstOrDefaultAsync(m => m.GUID == id);
            if (customSchedule == null)
            {
                return NotFound();
            }

            return View(customSchedule);
        }

        // POST: CustomSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customSchedule = await _context.CustomSchedules.FindAsync(id);
            if (customSchedule != null)
            {
                _context.CustomSchedules.Remove(customSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomScheduleExists(Guid id)
        {
            return _context.CustomSchedules.Any(e => e.GUID == id);
        }
    }
}
