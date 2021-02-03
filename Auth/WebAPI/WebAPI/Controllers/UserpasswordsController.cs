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
    public class UserpasswordsController : Controller
    {
        private readonly DataAccess _context;

        public UserpasswordsController(DataAccess context)
        {
            _context = context;
        }

        // GET: Userpasswords
        public async Task<IActionResult> Index()
        {
            var dataAccess = _context.Userpasswords.Include(u => u.User);
            return View(await dataAccess.ToListAsync());
        }

        // GET: Userpasswords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userpassword = await _context.Userpasswords
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.PasswordId == id);
            if (userpassword == null)
            {
                return NotFound();
            }

            return View(userpassword);
        }

        // GET: Userpasswords/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Endusers, "UserId", "UserEmail");
            return View();
        }

        // POST: Userpasswords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PasswordId,UserId,PasswordOld,PasswordNew,PasswordDateChanged")] Userpassword userpassword)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userpassword);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Endusers, "UserId", "UserEmail", userpassword.UserId);
            return View(userpassword);
        }

        // GET: Userpasswords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userpassword = await _context.Userpasswords.FindAsync(id);
            if (userpassword == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Endusers, "UserId", "UserEmail", userpassword.UserId);
            return View(userpassword);
        }

        // POST: Userpasswords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PasswordId,UserId,PasswordOld,PasswordNew,PasswordDateChanged")] Userpassword userpassword)
        {
            if (id != userpassword.PasswordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userpassword);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserpasswordExists(userpassword.PasswordId))
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
            ViewData["UserId"] = new SelectList(_context.Endusers, "UserId", "UserEmail", userpassword.UserId);
            return View(userpassword);
        }

        // GET: Userpasswords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userpassword = await _context.Userpasswords
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.PasswordId == id);
            if (userpassword == null)
            {
                return NotFound();
            }

            return View(userpassword);
        }

        // POST: Userpasswords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userpassword = await _context.Userpasswords.FindAsync(id);
            _context.Userpasswords.Remove(userpassword);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserpasswordExists(int id)
        {
            return _context.Userpasswords.Any(e => e.PasswordId == id);
        }
    }
}
