using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarService.Context;
using CarService.Models;

namespace CarService.Controllers
{
    public class CarPartsController : Controller
    {
        private readonly CarContext _context;

        public CarPartsController(CarContext context)
        {
            _context = context;
        }

        // GET: CarParts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarParts.ToListAsync());
        }

        // GET: CarParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPart = await _context.CarParts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carPart == null)
            {
                return NotFound();
            }

            return View(carPart);
        }

        // GET: CarParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CarPartName,CarPartManufactureDate,ManufacturerID")] CarPart carPart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carPart);
        }

        // GET: CarParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPart = await _context.CarParts.FindAsync(id);
            if (carPart == null)
            {
                return NotFound();
            }
            return View(carPart);
        }

        // POST: CarParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CarPartName,CarPartManufactureDate,ManufacturerID")] CarPart carPart)
        {
            if (id != carPart.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarPartExists(carPart.ID))
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
            return View(carPart);
        }

        // GET: CarParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carPart = await _context.CarParts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carPart == null)
            {
                return NotFound();
            }

            return View(carPart);
        }

        // POST: CarParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carPart = await _context.CarParts.FindAsync(id);
            _context.CarParts.Remove(carPart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarPartExists(int id)
        {
            return _context.CarParts.Any(e => e.ID == id);
        }
    }
}
