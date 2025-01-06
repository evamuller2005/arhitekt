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
    public class ArhitektController : Controller
    {
        private readonly ArhitektContext _context;

        public ArhitektController(ArhitektContext context)
        {
            _context = context;
        }

        // GET: Arhitekt
        public async Task<IActionResult> Index()
        {
            return View(await _context.Architects.ToListAsync());
        }

        // GET: Arhitekt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var architect = await _context.Architects
                .FirstOrDefaultAsync(m => m.ArchitectID == id);
            if (architect == null)
            {
                return NotFound();
            }

            return View(architect);
        }

        // GET: Arhitekt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arhitekt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArchitectID,UserintID")] Architect architect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(architect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(architect);
        }

        // GET: Arhitekt/Edit/5
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
            return View(architect);
        }

        // POST: Arhitekt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArchitectID,UserintID")] Architect architect)
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
            return View(architect);
        }

        // GET: Arhitekt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var architect = await _context.Architects
                .FirstOrDefaultAsync(m => m.ArchitectID == id);
            if (architect == null)
            {
                return NotFound();
            }

            return View(architect);
        }

        // POST: Arhitekt/Delete/5
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
