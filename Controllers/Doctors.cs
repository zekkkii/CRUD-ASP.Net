using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class Doctors : Controller
    {

        private DoctorContext _context;

        public Doctors(DoctorContext context) {
            _context = context;
        }
        // GET: Doctor
        public async Task<IActionResult> Index()
        {
           

            return View(await _context.Doctors.ToListAsync());
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctor/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public async  Task<IActionResult> Create( Doctor doctor)
        {
          
                 _context.Add(doctor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
           
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();

            var doctor = _context.Doctors.FirstOrDefault(elem => elem.Id == id);

            if (doctor == null)
                return NotFound();
            
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Doctor doctor)
        {

            if (id != null && id == doctor.Id) {
                _context.Update(doctor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return NotFound();

        }

        // GET: Doctor/Delete/5
        public async  Task<ActionResult> Delete(int id)
        {
            Doctor doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if (doctor == null)
                return NotFound();

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                Doctor doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);

                if (doctor == null)
                    return NotFound();

                _context.Remove(doctor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
