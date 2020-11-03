using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BariiLiii.Data;
using BariiLiii.Models;
using BariiLiii.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace BariiLiii.Controllers
{
    public class PatientsController : Controller
    {
        private readonly BariiLiiiContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<BariiLiiiUser> _userManager;
        private readonly SignInManager<BariiLiiiUser> _signInManager;

        public PatientsController(BariiLiiiContext context,
            Microsoft.AspNetCore.Identity.UserManager<BariiLiiiUser> userManager,
            SignInManager<BariiLiiiUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Serach patiens
        public async Task<IActionResult> IndexAsync(string PatientId, string Gender, string Location)
        {
            var searchPatients = from p in _context.Patients
                                 select p;

            if (!String.IsNullOrEmpty(PatientId))
            {
                searchPatients = searchPatients.Where(S => S.PatientId.Contains(PatientId));
            }


            if (!String.IsNullOrEmpty(Gender))
            {
                searchPatients = searchPatients.Where(S => S.Gender.Contains(Gender));
            }

            if (!String.IsNullOrEmpty(Location))
            {
                searchPatients = searchPatients.Where(S => S.Location.Contains(Location));
            }

            return View(await searchPatients.ToListAsync());
        }

        // GET: Patients
        //public async Task<IActionResult> Index()
        //{
        //    var PatientScheduler = _context.Patients
        //       .Join(_context.Appointments,
        //       Ps => Ps.PatientId,
        //       Av => Av.PatientId,
        //       (Ps, Av) => new { Pat = Ps, Ava = Av })
        //       .Where(DsAv => DsAv.Pat.PatientId.Equals(DsAv.Ava.PatientId));

        //    return View(await _context.Patients.ToListAsync());
        //}

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,Gender,Location")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PatientId,Gender,Location")] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientId))
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
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(string id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }
    }
}