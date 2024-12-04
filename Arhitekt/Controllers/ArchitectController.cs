using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Arhitekt.Data;
using Arhitekt.Models;

namespace Arhitekt.Controllers
{
    public class ArchitectController : Controller
    {
        private readonly ArhitektContext _context;

        public ArchitectController(ArhitektContext context)
        {
            _context = context;
        }

        // GET: Architect
        public async Task<IActionResult> Index()
        {
            var arhitektContext = _context.Architects.Include(a => a.User);
            return View(await arhitektContext.ToListAsync());
        }

        // GET: Architect/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var architect = await _context.Architects
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ArchitectID == id);
            if (architect == null)
            {
                return NotFound();
            }

            return View(architect);
        }

        // GET: Architect/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID");
            return View();
        }

        // POST: Architect/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArchitectID,UserID")] Architect architect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(architect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", architect.UserID);
            return View(architect);
        }

        // GET: Architect/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var architect = await _context.Architects.FindAsync(id);
            if (architect == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", architect.UserID);
            return View(architect);
        }

        // POST: Architect/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArchitectID,UserID")] Architect architect)
        {
            if (id != architect.ArchitectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(architect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchitectExists(architect.ArchitectID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", architect.UserID);
            return View(architect);
        }

        // GET: Architect/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var architect = await _context.Architects
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ArchitectID == id);
            if (architect == null)
            {
                return NotFound();
            }

            return View(architect);
        }

        // POST: Architect/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var architect = await _context.Architects.FindAsync(id);
            if (architect != null)
            {
                _context.Architects.Remove(architect);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchitectExists(int id)
        {
            return _context.Architects.Any(e => e.ArchitectID == id);
        }
    }
}
