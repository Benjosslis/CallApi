using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CallApi.Api.Data;
using CallApi.Api.Models;

namespace CallApi.Api.Controllers
{
    public class ApiModelsController : Controller
    {
        private readonly CallApiApiContext _context;

        public ApiModelsController(CallApiApiContext context)
        {
            _context = context;
        }

        // GET: ApiModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApiModels.ToListAsync());
        }

        // GET: ApiModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiModels = await _context.ApiModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apiModels == null)
            {
                return NotFound();
            }

            return View(apiModels);
        }

        // GET: ApiModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApiModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ApiModels apiModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apiModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apiModels);
        }

        // GET: ApiModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiModels = await _context.ApiModels.FindAsync(id);
            if (apiModels == null)
            {
                return NotFound();
            }
            return View(apiModels);
        }

        // POST: ApiModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ApiModels apiModels)
        {
            if (id != apiModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apiModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApiModelsExists(apiModels.Id))
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
            return View(apiModels);
        }

        // GET: ApiModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiModels = await _context.ApiModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apiModels == null)
            {
                return NotFound();
            }

            return View(apiModels);
        }

        // POST: ApiModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apiModels = await _context.ApiModels.FindAsync(id);
            if (apiModels != null)
            {
                _context.ApiModels.Remove(apiModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApiModelsExists(int id)
        {
            return _context.ApiModels.Any(e => e.Id == id);
        }
    }
}
