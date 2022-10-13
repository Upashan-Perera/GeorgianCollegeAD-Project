using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeorgianCollegeAD_Project.Data;
using GeorgianCollegeAD_Project.Models;

namespace GeorgianCollegeAD_Project.Controllers
{
    public class Employee_TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Employee_TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee_Tasks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employee_Tasks.Include(e => e.Employee).Include(e => e.Task);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employee_Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employee_Tasks == null)
            {
                return NotFound();
            }

            var employee_Task = await _context.Employee_Tasks
                .Include(e => e.Employee)
                .Include(e => e.Task)
                .FirstOrDefaultAsync(m => m.Employee_TaskId == id);
            if (employee_Task == null)
            {
                return NotFound();
            }

            return View(employee_Task);
        }

        // GET: Employee_Tasks/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskName");
            return View();
        }

        // POST: Employee_Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Employee_TaskId,TaskId,EmployeeId,IsCompleted,TimeDate")] Employee_Task employee_Task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee_Task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", employee_Task.EmployeeId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskName", employee_Task.TaskId);
            return View(employee_Task);
        }

        // GET: Employee_Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employee_Tasks == null)
            {
                return NotFound();
            }

            var employee_Task = await _context.Employee_Tasks.FindAsync(id);
            if (employee_Task == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", employee_Task.EmployeeId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskName", employee_Task.TaskId);
            return View(employee_Task);
        }

        // POST: Employee_Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Employee_TaskId,TaskId,EmployeeId,IsCompleted,TimeDate")] Employee_Task employee_Task)
        {
            if (id != employee_Task.Employee_TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee_Task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee_TaskExists(employee_Task.Employee_TaskId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", employee_Task.EmployeeId);
            ViewData["TaskId"] = new SelectList(_context.Tasks, "TaskId", "TaskName", employee_Task.TaskId);
            return View(employee_Task);
        }

        // GET: Employee_Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employee_Tasks == null)
            {
                return NotFound();
            }

            var employee_Task = await _context.Employee_Tasks
                .Include(e => e.Employee)
                .Include(e => e.Task)
                .FirstOrDefaultAsync(m => m.Employee_TaskId == id);
            if (employee_Task == null)
            {
                return NotFound();
            }

            return View(employee_Task);
        }

        // POST: Employee_Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employee_Tasks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employee_Tasks'  is null.");
            }
            var employee_Task = await _context.Employee_Tasks.FindAsync(id);
            if (employee_Task != null)
            {
                _context.Employee_Tasks.Remove(employee_Task);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee_TaskExists(int id)
        {
          return _context.Employee_Tasks.Any(e => e.Employee_TaskId == id);
        }
    }
}
