using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UsersessionsController : Controller
    {
        private readonly DataAccess _context;

        public UsersessionsController(DataAccess context)
        {
            _context = context;
        }

        // GET: Usersessions
        public async Task<IActionResult> Index()
        {
            var dataAccess = _context.Usersessions.Include(u => u.User);
            return View(await dataAccess.ToListAsync());
        }

        // GET: Usersessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersession = await _context.Usersessions
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (usersession == null)
            {
                return NotFound();
            }

            return View(usersession);
        }

        // GET: Usersessions/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Endusers, "UserId", "UserEmail");
            return View();
        }

        // POST: Usersessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionId,UserId,SessionDate,SessionStatus,SessionToken")] Usersession usersession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Endusers, "UserId", "UserEmail", usersession.UserId);
            return View(usersession);
        }

        // GET: Usersessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersession = await _context.Usersessions.FindAsync(id);
            if (usersession == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Endusers, "UserId", "UserEmail", usersession.UserId);
            return View(usersession);
        }

        // POST: Usersessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessionId,UserId,SessionDate,SessionStatus,SessionToken")] Usersession usersession)
        {
            if (id != usersession.SessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersessionExists(usersession.SessionId))
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
            ViewData["UserId"] = new SelectList(_context.Endusers, "UserId", "UserEmail", usersession.UserId);
            return View(usersession);
        }

        // GET: Usersessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersession = await _context.Usersessions
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (usersession == null)
            {
                return NotFound();
            }

            return View(usersession);
        }

        // POST: Usersessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usersession = await _context.Usersessions.FindAsync(id);
            _context.Usersessions.Remove(usersession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersessionExists(int id)
        {
            return _context.Usersessions.Any(e => e.SessionId == id);
        }
    }
}
