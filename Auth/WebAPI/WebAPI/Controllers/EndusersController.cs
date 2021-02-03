using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using Microsoft.Data.SqlClient;

namespace WebAPI.Controllers
{
    public class EndusersController : Controller
    {
        private readonly DataAccess _context;
        public EndusersController(DataAccess context)
        {
            _context = context;
        }

        // GET: Endusers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Endusers.ToListAsync());
        }

        // GET: Endusers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enduser = await _context.Endusers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (enduser == null)
            {
                return NotFound();
            }

            return View(enduser);
        }

        // GET: Endusers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Endusers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserFName,UserLName,UserEmail")] Enduser enduser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enduser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enduser);
        }

        // GET: Endusers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enduser = await _context.Endusers.FindAsync(id);
            if (enduser == null)
            {
                return NotFound();
            }
            return View(enduser);
        }

        // POST: Endusers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserFName,UserLName,UserEmail")] Enduser enduser)
        {
            if (id != enduser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enduser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnduserExists(enduser.UserId))
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
            return View(enduser);
        }

        // GET: Endusers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enduser = await _context.Endusers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (enduser == null)
            {
                return NotFound();
            }

            return View(enduser);
        }

        // DELETE: Endusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enduser = await _context.Endusers.FindAsync(id);
            _context.Endusers.Remove(enduser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnduserExists(int id)
        {
            return _context.Endusers.Any(e => e.UserId == id);
        }

        // PUT: Endusers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Put(int id, [Bind("UserId,UserFName,UserLName,UserEmail")] Enduser enduser)
        {
            if (id != enduser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enduser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnduserExists(enduser.UserId))
                    {
                        return RedirectToAction(nameof(Create));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enduser);
        }

        // getValidation(User) : bool
        private bool GetValidation(int id, [Bind("UserId,UserFName,UserLName,UserEmail")] Enduser enduser)
        {
            DataAccess d = new DataAccess();
            bool v  = d.Validate(enduser);
            return v;
        }

        // register (User, out string) : void
        private void Register([Bind("UserId,UserFName,UserLName,UserEmail")] Enduser enduser, 
            [Bind("PasswordNew")] Userpassword userpassword, out string response)
        {
            DataAccess d = new DataAccess();
            d.Register(enduser, userpassword, out response);
        }
    }
}
